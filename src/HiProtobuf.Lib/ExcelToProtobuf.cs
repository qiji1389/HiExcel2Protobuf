using System;
using HiFramework.Assert;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HiProtobuf.Lib
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
            string[] excelFiles = Directory.GetFiles(Settings.SourceExcel_Folder, "*.xlsx", SearchOption.AllDirectories);
            for (int i = 0; i < excelFiles.Length; i++)
            {
                var excelFilePath = excelFiles[i];
                if (excelFilePath.Contains("~$"))//It's an already opened excel
                {
                    continue;
                }
                ProcessExcel(excelFilePath);
            }
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
                var name = Path.GetFileNameWithoutExtension(excelFilePath);
                new ProtoGenerator(name, usedRange).Generate();
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
    }
}
