using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HiFramework.Assert;
using Microsoft.Office.Interop.Excel;

namespace Excel2Protobuf.Lib
{
    internal class ProtoGenerator
    {
        private string _protoName;

        private int _rowCount;
        private int _colCount;
        private Range _range;

        private string _outputPath;
        private int _protoIndex;
        public ProtoGenerator(string protoName, Range range)
        {
            _protoName = protoName;
            _rowCount = range.Rows.Count;
            _colCount = range.Columns.Count;
            _range = range;
            _protoIndex = 0;

            _outputPath = Settings.ProtobufOutput_Folder + Settings.proto_folder + "\\" + protoName + ".proto";
        }

        public void Generate()
        {
            generateHeader();
            generateVariables();
            generateMap();
        }

        void generateHeader()
        {
            var header = @"
// Do not modify
// This is an auto generated protobuf declaration file

// [BEG declaration]
syntax = ""proto3"";
package cjProtoBuf;
// [END declaration]

// [BEG java_declaration]
option java_package = ""com.cj.protobuf"";
option java_outer_classname = ""{0}"";
// [END java_declaration]

// [START csharp_declaration]
option csharp_namespace = ""cjProtobuf""; 
// [END csharp_declaration]
";
            header = string.Format(header, _protoName + "_classname");
            try
            {
                using (var sw = File.AppendText(_outputPath))
                {
                    sw.WriteLine(header);
                    sw.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        void generateVariables()
        {
            StringBuilder sb = new StringBuilder("message " + _protoName + " {\n");
            for (int col = 1; col <= _colCount; col++)
            {
                var type = (_range.Cells[2, col]).Value2.ToString();
                var name = (_range.Cells[3, col]).Value2.ToString();
                sb.Append(GenerateVariableString(type, name));
            }
            sb.Append("}");

            using (var sw = File.AppendText(_outputPath))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// Generate protobuf variable declaration from the variable string
        /// </summary>
        /// <param name="infos"></param>
        private string GenerateVariableString(string type, string name)
        {
            AssertThat.IsTrue(Common.VariableType.Contains(type), "Type define error");

            _protoIndex++;//从1开始定义
            StringBuilder sb = new StringBuilder();
            // incase the type is a list
            if (type.Contains("[]")) 
            {
                // convert to "repeated xxx"
                type = "repeated " + type.Split('[')[0];
            }
            string str = string.Format("  {0} {1} = {2};\n", type, name, _protoIndex);
            return str;
        }

        private void generateMap()
        {
            string str = @"
message Excel_{0} 
{{
    map<int32,{1}> {2} = 1;
}}";
            str = string.Format(str, _protoName, _protoName, "Data");
            var sw = File.AppendText(_outputPath);
            sw.WriteLine(str);
            sw.Close();
        }
    }
}
