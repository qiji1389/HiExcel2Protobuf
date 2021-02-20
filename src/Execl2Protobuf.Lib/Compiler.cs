/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiProtobuf
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel2Protobuf.Lib
{
    internal class Compiler
    {
        public static readonly string DllName = "/Excel2Protobuf.csharp.dll";

        public Compiler()
        {
            var folder = Settings.ProtobufOutput_Folder + Settings.code_folder + Settings.csharp_dll_folder;
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            Directory.CreateDirectory(folder);
        }

        public void Porcess()
        {
            var command = @"-target:library -out:{0} -reference:{1} -recurse:{2}\*.cs";
            var dllPath = Settings.ProtobufOutput_Folder + Settings.code_folder + Settings.csharp_dll_folder + DllName;
            var csharpFolder = Settings.ProtobufOutput_Folder + Settings.code_folder + Settings.csharp_folder;
            command = Settings.Compiler_Path + " " + string.Format(command, dllPath, Settings.Protobuf_Dll_Path, csharpFolder);
            Common.Cmd(command);
        }
    }
}
