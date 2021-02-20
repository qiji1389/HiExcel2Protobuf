using HiFramework.Log;
using System.IO;

namespace Excel2Protobuf.Lib
{
    internal class CodeGenerater
    {
        private string codeOutputFolder;
        public void Generate()
        {
            codeOutputFolder = Settings.ProtobufOutput_Folder + Settings.code_folder;
            if (Directory.Exists(codeOutputFolder))
            {
                Directory.Delete(codeOutputFolder, true);
            }
            Directory.CreateDirectory(codeOutputFolder);

            var protoFolder = Settings.ProtobufOutput_Folder + Settings.proto_folder;
            generateCSharp(protoFolder);
            generateCPP(protoFolder);
            generateGO(protoFolder);
            generateJava(protoFolder);
            generatePython(protoFolder);
        }

        private void generateCSharp(string protoPath)
        {
            var outputFolder = codeOutputFolder + Settings.csharp_folder;
            Directory.CreateDirectory(outputFolder);
            
            string[] protoFiles = Directory.GetFiles(protoPath, "*.proto", SearchOption.AllDirectories);
            for (int i = 0; i < protoFiles.Length; i++)
            {
                var protoFile = protoFiles[i];
                var command = Settings.Protoc_Path + string.Format(" -I={0} --csharp_out={1} {2}", protoPath, outputFolder, protoFile);
                var log = Common.Cmd(command);
            }
        }

        private void generateCPP(string protoPath)
        {
            var outputFolder = codeOutputFolder + Settings.cpp_folder;
            Directory.CreateDirectory(outputFolder);
            
            string[] protoFiles = Directory.GetFiles(protoPath, "*.proto", SearchOption.AllDirectories);
            for (int i = 0; i < protoFiles.Length; i++)
            {
                var protoFile = protoFiles[i];
                var command = Settings.Protoc_Path + string.Format(" -I={0} --cpp_out={1} {2}", protoPath, outputFolder, protoFile);
                var log = Common.Cmd(command);
            }
        }

        private void generateGO(string protoPath)
        {
            var outputFolder = codeOutputFolder + Settings.go_folder;
            Directory.CreateDirectory(outputFolder);
            
            string[] protoFiles = Directory.GetFiles(protoPath, "*.proto", SearchOption.AllDirectories);
            for (int i = 0; i < protoFiles.Length; i++)
            {
                var protoFile = protoFiles[i];
                var command = Settings.Protoc_Path + string.Format(" -I={0} --go_out={1} {2}", protoPath, outputFolder, protoFile);
                var log = Common.Cmd(command);
            }
        }

        private void generateJava(string protoPath)
        {
            var outputFolder = codeOutputFolder + Settings.java_folder;
            Directory.CreateDirectory(outputFolder);
            
            string[] protoFiles = Directory.GetFiles(protoPath, "*.proto", SearchOption.AllDirectories);
            for (int i = 0; i < protoFiles.Length; i++)
            {
                var protoFile = protoFiles[i];
                var command = Settings.Protoc_Path + string.Format(" -I={0} --java_out={1} {2}", protoPath, outputFolder, protoFile);
                var log = Common.Cmd(command);
            }
        }

        private void generatePython(string protoPath)
        {
            var outputFolder = codeOutputFolder + Settings.python_folder;
            Directory.CreateDirectory(outputFolder);
            
            string[] protoFiles = Directory.GetFiles(protoPath, "*.proto", SearchOption.AllDirectories);
            for (int i = 0; i < protoFiles.Length; i++)
            {
                var protoFile = protoFiles[i];
                var command = Settings.Protoc_Path + string.Format(" -I={0} --python_out={1} {2}", protoPath, outputFolder, protoFile);
                var log = Common.Cmd(command);
            }
        }
    }
}
