using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiProtobuf.Lib;
using HiFramework.Log;

namespace HiProtobuf.UI
{
    public partial class HiProtobuf : Form
    {
        public HiProtobuf()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Settings.ProtobufOutput_Folder)) txtOutputProtobufDir.Text = Settings.ProtobufOutput_Folder;
            if (!string.IsNullOrEmpty(Settings.SourceExcel_Folder)) txtSrcExcelDir.Text = Settings.SourceExcel_Folder;
            if (!string.IsNullOrEmpty(Settings.Compiler_Path)) txtCSharpCompiler.Text = Settings.Compiler_Path;
            Log.OnInfo += (x) =>
            {
                textBox6.Text = Logger.Log;
            };
            Log.OnWarning += (x) =>
            {
                textBox6.Text = Logger.Log;
            };
            Log.OnError += (x) =>
            {
                textBox6.Text = Logger.Log;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
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
            Log.Info("导出结束");
            Config.Save();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
