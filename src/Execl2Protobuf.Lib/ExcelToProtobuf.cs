using System;
using HiFramework.Assert;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Excel2Protobuf.Lib
{
    internal class ExcelToProtobuf
    {
        public ExcelToProtobuf()
        {
            var path = Settings.ProtobufOutput_Folder + Settings.proto_folder;
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
        }

        public void Generate()
        {
            List<string> templateProtoList = new List<string>();

            string[] excelFiles = Directory.GetFiles(Settings.SourceExcel_Folder, "*.xlsx", SearchOption.AllDirectories);
            for (int i = 0; i < excelFiles.Length; i++)
            {
                var excelFilePath = excelFiles[i];
                if (excelFilePath.Contains("~$"))//It's an already opened excel
                {
                    continue;
                }
                ProcessExcel(excelFilePath);

                var protoName = Path.GetFileNameWithoutExtension(excelFilePath);
                templateProtoList.Add(protoName);
            }

            generateAllTemplatesProto(templateProtoList);
        }

        void ProcessExcel(string excelFilePath)
        {
            AssertThat.IsNotNullOrEmpty(excelFilePath);
            var excelApp = new Application();
            var workbooks = excelApp.Workbooks.Open(excelFilePath);
            try
            {
                var sheet = workbooks.Sheets[1];
                AssertThat.IsNotNull(sheet, "Excel's sheet is null");
                Worksheet worksheet = sheet as Worksheet;
                AssertThat.IsNotNull(sheet, "Excel's worksheet is null");
                var usedRange = worksheet.UsedRange;
                //int rowCount = usedRange.Rows.Count;
                //int colCount = usedRange.Columns.Count;
                //for (int i = 1; i <= rowCount; i++)
                //{
                //    for (int j = 1; j <= colCount; j++)
                //    {
                //        var value = ((Range)usedRange.Cells[i, j]).Value2;
                //        var str = value.ToString();
                //    }
                //}
                var protoName = Path.GetFileNameWithoutExtension(excelFilePath);
                new ProtoGenerator(protoName, usedRange).Generate();
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

        private void generateAllTemplatesProto(List<string> templateProtoList)
        {
            var allTemplatesProtoFilePath = Settings.ProtobufOutput_Folder + Settings.proto_folder + "\\AllTemplates.proto";
            var header = @"
// Do not modify
// This is an auto generated protobuf declaration file

// [BEG declaration]
syntax = ""proto3"";
package cjProtoBuf;
// [END declaration]

// [START csharp_declaration]
option csharp_namespace = ""cjProtobuf""; 
// [END csharp_declaration]
";
            try
            {
                using (var sw = File.AppendText(allTemplatesProtoFilePath))
                {
                    // header
                    sw.WriteLine(header);

                    // imports
                    var importStr = @"import ""{0}.proto"";";
                    foreach (var templateProto in templateProtoList)
                    {
                        var importStatement = string.Format(importStr, templateProto);
                        sw.WriteLine(importStatement);
                    }

                    sw.WriteLine();

                    // message
                    int protoIndex = 0;
                    var fieldStr = @"map<int32, {0}> {1}Data = {2};";
                    StringBuilder sb = new StringBuilder("message AllTemplates {\n");
                    foreach(var templateProto in templateProtoList)
                    {
                        protoIndex++;
                        var fieldDeclaration = string.Format(fieldStr, templateProto, templateProto, protoIndex);
                        sb.Append(fieldDeclaration);
                        sb.Append("\n");
                    }
                    sb.Append("}");

                    sw.Write(sb.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
