using Google.Protobuf;
using Google.Protobuf.Collections;
using HiFramework.Assert;
using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Excel2Protobuf.Lib
{
    internal class DataParser
    {
        private static string[] excludedProtos = { "AllTemplates" };
        private static string allTemplatesName = "AllTemplates";

        private Assembly _assembly;
        private Dictionary<string, object> _protoDataMap;

        public DataParser() 
        {
            var folder = Settings.ProtobufOutput_Folder + Settings.data_folder;
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            Directory.CreateDirectory(folder); 
        }

        public void Process()
        {
            var dllPath = Settings.ProtobufOutput_Folder + Settings.code_folder + Settings.csharp_dll_folder + Compiler.DllName;
            _assembly = Assembly.LoadFrom(dllPath);
            _protoDataMap = new Dictionary<string, object>();
            var protoFolder = Settings.ProtobufOutput_Folder + Settings.proto_folder;
            string[] files = Directory.GetFiles(protoFolder, "*.proto", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                string protoPath = files[i];
                string protoName = Path.GetFileNameWithoutExtension(protoPath);

                bool excluded = false;
                foreach (var excludedProto in excludedProtos)
                {
                    if (excludedProto == protoName)
                    {
                        excluded = true;
                        break;
                    }
                }
                if (excluded) continue;

                string protoObjName = "cjProtobuf.Excel_" + protoName;
                var protoDataInstance = _assembly.CreateInstance(protoObjName);
                string excelPath = Settings.SourceExcel_Folder + "/" + protoName + ".xlsx";
                ProcessData(protoDataInstance, excelPath);
            }

            Pack();
        }

        public void Pack()
        {
            string allTemplatesProtoName = "cjProtobuf." + allTemplatesName;
            var allTemplatesInstance = _assembly.CreateInstance(allTemplatesProtoName);
            var allTemplatesType = allTemplatesInstance.GetType();

            foreach (var keyValuePair in _protoDataMap)
            {
                var dataName = keyValuePair.Key;
                var dataValue = keyValuePair.Value;
                var dataType = dataValue.GetType();
                string dataMapPropName = dataName + "Data";
                var dataMapPropInfo = allTemplatesType.GetProperty(dataMapPropName);
                // type of pbc::MapField<TKey, TValue>
                var dataMapPropValue = dataMapPropInfo.GetValue(allTemplatesInstance);
                var dataMapPropType = dataMapPropInfo.PropertyType;
                var dataEntryInstance = _assembly.CreateInstance("cjProtobuf." + dataName);
                var dataEntryType = dataEntryInstance.GetType();
                
                var addMethod = dataMapPropType.GetMethod("Add", new Type[] { dataMapPropType });
                addMethod.Invoke(dataMapPropValue, new[] { dataValue });
            }

            Serialize(allTemplatesInstance);
        }

        private void ProcessData(object protoDataInstance, string excelPath)
        {
            AssertThat.IsTrue(File.Exists(excelPath), "Failed to find the Excel file: "+excelPath);
            var protoName = Path.GetFileNameWithoutExtension(excelPath);
            var excelApp = new Application();
            var workbooks = excelApp.Workbooks.Open(excelPath);
            try
            {
                var sheet = workbooks.Sheets[1];
                AssertThat.IsNotNull(sheet, "Excel's sheet is null");
                Worksheet worksheet = sheet as Worksheet;
                AssertThat.IsNotNull(sheet, "Excel's worksheet is null");
                var usedRange = worksheet.UsedRange;
                int rowCount = usedRange.Rows.Count;
                int colCount = usedRange.Columns.Count;

                var protoDataType = protoDataInstance.GetType();
                // the excel data type must have a property called "Data"
                // get the "Data" PropertyInfo from the protoType. 
                var dataMapPropInfo = protoDataType.GetProperty("Data");
                // get the "Data" property value from the protoObj instance.
                // "Data" property value is a reference to a dictionary of cjProtobuf.<protoName>
                var dataMapProp = dataMapPropInfo.GetValue(protoDataInstance); // this is equivalent to var dataMapProp = _protoObj.Data
                // the type of "Data" property is Dictionary<int, cjProtobuf.<protoName>>
                var dataMapType = dataMapPropInfo.PropertyType;
                var dataEntry = _assembly.CreateInstance("cjProtobuf." + protoName);
                var addMethod = dataMapType.GetMethod("Add", new Type[] { typeof(int), dataEntry.GetType() });
                // the excel data section always starts from the fourth row
                for (int i = 4; i <= rowCount; i++)
                {
                    int tid = (int) ((Range) usedRange.Cells[i, 1]).Value2;
                    addMethod.Invoke(dataMapProp, new[] {tid, dataEntry});  // this is equivalent to dataMapProp.Add(tid, dataEntry)
                    for (int j = 1; j <= colCount; j++)
                    {
                        var variableType = ((Range) usedRange.Cells[2, j]).Text.ToString();
                        var variableName = ((Range) usedRange.Cells[3, j]).Text.ToString();
                        var variableValueStr = ((Range) usedRange.Cells[i, j]).Text.ToString();
                        var dataEntryType = dataEntry.GetType();
                        var fieldName = variableName + "_"; // the field name follows protobuf convention
                        FieldInfo fieldInfo =
                            dataEntryType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
                        var variableValue = ParseVariableValue(variableType, variableValueStr);
                        fieldInfo.SetValue(dataEntry, variableValue);
                    }
                }
                _protoDataMap.Add(protoName, dataMapProp);
                Serialize(protoDataInstance);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                workbooks.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        object ParseVariableValue(string type, string value)
        {
            if (type == Common.double_)
                return double.Parse(value);
            if (type == Common.float_)
                return float.Parse(value);
            if (type == Common.int32_)
                return int.Parse(value);
            if (type == Common.int64_)
                return long.Parse(value);
            if (type == Common.uint32_)
                return uint.Parse(value);
            if (type == Common.uint64_)
                return ulong.Parse(value);
            if (type == Common.sint32_)
                return int.Parse(value);
            if (type == Common.sint64_)
                return long.Parse(value);
            if (type == Common.fixed32_)
                return uint.Parse(value);
            if (type == Common.fixed64_)
                return ulong.Parse(value);
            if (type == Common.sfixed32_)
                return int.Parse(value);
            if (type == Common.sfixed64_)
                return long.Parse(value);
            if (type == Common.bool_)
                return value == "1";
            if (type == Common.string_)
                return value.ToString();
            if (type == Common.bytes_)
                return ByteString.CopyFromUtf8(value.ToString());
            if (type == Common.double_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<double> newValue = new RepeatedField<double>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(double.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.float_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<float> newValue = new RepeatedField<float>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(float.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.int32_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<int> newValue = new RepeatedField<int>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(int.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.int64_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<long> newValue = new RepeatedField<long>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(long.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.uint32_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<uint> newValue = new RepeatedField<uint>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(uint.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.uint64_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<ulong> newValue = new RepeatedField<ulong>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(ulong.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.sint32_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<int> newValue = new RepeatedField<int>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(int.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.sint64_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<long> newValue = new RepeatedField<long>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(long.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.fixed32_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<uint> newValue = new RepeatedField<uint>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(uint.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.fixed64_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<ulong> newValue = new RepeatedField<ulong>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(ulong.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.sfixed32_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<int> newValue = new RepeatedField<int>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(int.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.sfixed64_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<long> newValue = new RepeatedField<long>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(long.Parse(datas[i]));
                }
                return newValue;
            }
            if (type == Common.bool_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<bool> newValue = new RepeatedField<bool>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(datas[i] == "1");
                }
                return newValue;
            }
            if (type == Common.string_s)
            {
                string data = value.Trim('"');
                string[] datas = data.Split('|');
                RepeatedField<string> newValue = new RepeatedField<string>();
                for (int i = 0; i < datas.Length; i++)
                {
                    newValue.Add(datas[i]);
                }
                return newValue;
            }
            AssertThat.Fail("Type error");
            return null;
        }

        void Serialize(object obj)
        {
            var type = obj.GetType();
            var dataFilePath = Settings.ProtobufOutput_Folder + Settings.data_folder + "\\" + type.Name + ".dat";
            var jsonFilePath = Settings.ProtobufOutput_Folder + Settings.data_folder + "\\" + type.Name + ".json";
            using (var dataFileOutput = File.Create(dataFilePath))
            {
                MessageExtensions.WriteTo((IMessage)obj, dataFileOutput);
            }

            
            var jsonFormatter = new JsonFormatter(JsonFormatter.Settings.Default);
            var json = jsonFormatter.Format((IMessage)obj);
            var prettyJson = JsonPrettyPrint(json);

            File.WriteAllText(jsonFilePath, prettyJson);
        }

        private string JsonPrettyPrint(string json)
        {
            var jsonObj = JsonConvert.DeserializeObject(json);
            var prettyJson = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

            return prettyJson;
        }
    }
}