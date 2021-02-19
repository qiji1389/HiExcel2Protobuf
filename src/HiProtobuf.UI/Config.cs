using Excel2Protobuf.Lib;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Excel2Protobuf.UI
{
    internal static class Config
    {
        private static string _configFilePath = Environment.CurrentDirectory + "\\Config.xml";

        internal static void Load()
        {
            if (File.Exists(_configFilePath))
            {
                XmlSerializer xs = XmlSerializer.FromTypes(new Type[] { typeof(PathConfig) })[0];
                Stream stream = new FileStream(_configFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                PathConfig pathCfg = xs.Deserialize(stream) as PathConfig;
                Settings.ProtobufOutput_Folder = pathCfg.Export_Folder;
                Settings.SourceExcel_Folder = pathCfg.Excel_Folder;
                Settings.Compiler_Path = pathCfg.Compiler_Path;
                stream.Close();
            }
        }

        internal static void Save()
        {
            if (File.Exists(_configFilePath)) File.Delete(_configFilePath);
            var pathCfg = new PathConfig();
            pathCfg.Export_Folder = Settings.ProtobufOutput_Folder;
            pathCfg.Excel_Folder = Settings.SourceExcel_Folder;
            pathCfg.Compiler_Path = Settings.Compiler_Path;
            XmlSerializer xs = XmlSerializer.FromTypes(new Type[] { typeof(PathConfig) })[0];
            Stream stream = new FileStream(_configFilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
            xs.Serialize(stream, pathCfg);
            stream.Close();
        }
    }
    public class PathConfig
    {
        public string Export_Folder;
        public string Excel_Folder;
        public string Compiler_Path;
    }
}
