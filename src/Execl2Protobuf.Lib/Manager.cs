using HiFramework.Log;

namespace Excel2Protobuf.Lib
{
    public static class Manager
    {
        public static void Export()
        {
            if (string.IsNullOrEmpty(Settings.ProtobufOutput_Folder))
            {
                Log.Error("Invalid Protobuf output folder path.");
                return;
            }
            if (string.IsNullOrEmpty(Settings.SourceExcel_Folder))
            {
                Log.Error("Invalid source Excel folder path");
                return;
            }
            if (string.IsNullOrEmpty(Settings.Compiler_Path))
            {
                Log.Error("Invalid .Net compiler path");
                return;
            }
            Log.Info("Generating Protobuf...");
            new ExcelToProtobuf().Generate();
            Log.Info("Done generating Protobuf.");
            Log.Info("Generating Protobuf API code...");
            new CodeGenerater().Generate();
            Log.Info("Done generating Protobuf API code.");
            Log.Info("Compiling code...");
            new Compiler().Porcess();
            Log.Info("Done compiling code.");
            Log.Info("Generating Protobuf data...");
            //new DataHandler().Process();
            Log.Info("Done generating Protobuf data.");
        }
    }
}
