using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel2Protobuf.Lib;
using HiFramework.Log;

namespace Excel2Protobuf.UI
{
    public partial class Excel2ProtobufTool : Form
    {
        public Excel2ProtobufTool()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Settings.ProtobufOutput_Folder)) txtOutputProtobufDir.Text = Settings.ProtobufOutput_Folder;
            if (!string.IsNullOrEmpty(Settings.SourceExcel_Folder)) txtSrcExcelDir.Text = Settings.SourceExcel_Folder;
            if (!string.IsNullOrEmpty(Settings.Compiler_Path)) txtCSharpCompiler.Text = Settings.Compiler_Path;
            Log.OnInfo += (x) =>
            {
                txtConsole.Text = Logger.Log;
            };
            Log.OnWarning += (x) =>
            {
                txtConsole.Text = Logger.Log;
            };
            Log.OnError += (x) =>
            {
                txtConsole.Text = Logger.Log;
            };
        }

        private void btnSelectOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputProtobufDir.Text = dialog.SelectedPath;
                Settings.ProtobufOutput_Folder = txtOutputProtobufDir.Text;
            }
        }
        private void txtSelectOutputDirectory_TextChanged(object sender, EventArgs e)
        {
            Settings.ProtobufOutput_Folder = txtOutputProtobufDir.Text;
        }

        private void btnSelectSrcExcelDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSrcExcelDir.Text = dialog.SelectedPath;
                Settings.SourceExcel_Folder = txtSrcExcelDir.Text;
            }
        }
        private void txtSrcExcelDir_TextChanged(object sender, EventArgs e)
        {
            Settings.SourceExcel_Folder = txtSrcExcelDir.Text;
        }
        
        private void btnSelectCSharpCompiler_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "csc(*.exe)|*.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtCSharpCompiler.Text = dialog.FileName;
                Settings.Compiler_Path = txtCSharpCompiler.Text;
            }
        }

        private void txtCSharpCompiler_TextChanged(object sender, EventArgs e)
        {
            Settings.Compiler_Path = txtCSharpCompiler.Text;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Log.Info("Exporting...");
            Manager.Export();
            Log.Info("Done exporting.");
            Config.Save();
        }
    }
}
