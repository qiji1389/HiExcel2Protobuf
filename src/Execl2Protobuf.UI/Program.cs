/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiProtobuf
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiFramework.Log;

namespace Excel2Protobuf.UI
{
    static class Program
    {
        /// <summary>
        /// Excel2Protobuf Main
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.LogHandler = new Logger();
            Config.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Excel2ProtobufTool());
        }
    }
}
