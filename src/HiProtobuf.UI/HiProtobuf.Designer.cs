namespace HiProtobuf.UI
{
    partial class HiProtobuf
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectOutputProtobufDir = new System.Windows.Forms.Button();
            this.txtOutputProtobufDir = new System.Windows.Forms.TextBox();
            this.txtSrcExcelDir = new System.Windows.Forms.TextBox();
            this.btnSelectSrcExcelDir = new System.Windows.Forms.Button();
            this.txtCSharpCompiler = new System.Windows.Forms.TextBox();
            this.btnSelectCSharpCompiler = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblOutputProtobufDir = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSrcExcelDir = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCSharpCompilerDir = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectOutputProtobufDir
            // 
            this.btnSelectOutputProtobufDir.Location = new System.Drawing.Point(828, 27);
            this.btnSelectOutputProtobufDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectOutputProtobufDir.Name = "btnSelectOutputProtobufDir";
            this.btnSelectOutputProtobufDir.Size = new System.Drawing.Size(100, 29);
            this.btnSelectOutputProtobufDir.TabIndex = 0;
            this.btnSelectOutputProtobufDir.Text = "Select";
            this.btnSelectOutputProtobufDir.UseVisualStyleBackColor = true;
            this.btnSelectOutputProtobufDir.Click += new System.EventHandler(this.btnSelectOutputDir_Click);
            // 
            // txtOutputProtobufDir
            // 
            this.txtOutputProtobufDir.Location = new System.Drawing.Point(4, 31);
            this.txtOutputProtobufDir.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputProtobufDir.Name = "txtOutputProtobufDir";
            this.txtOutputProtobufDir.Size = new System.Drawing.Size(816, 25);
            this.txtOutputProtobufDir.TabIndex = 1;
            this.txtOutputProtobufDir.Text = "Please select the output directory";
            this.txtOutputProtobufDir.TextChanged += new System.EventHandler(this.txtSelectOutputDirectory_TextChanged);
            // 
            // txtSrcExcelDir
            // 
            this.txtSrcExcelDir.Location = new System.Drawing.Point(4, 31);
            this.txtSrcExcelDir.Margin = new System.Windows.Forms.Padding(4);
            this.txtSrcExcelDir.Name = "txtSrcExcelDir";
            this.txtSrcExcelDir.Size = new System.Drawing.Size(816, 25);
            this.txtSrcExcelDir.TabIndex = 2;
            this.txtSrcExcelDir.Text = "Please select the source excel directory";
            this.txtSrcExcelDir.TextChanged += new System.EventHandler(this.txtSrcExcelDir_TextChanged);
            // 
            // btnSelectSrcExcelDir
            // 
            this.btnSelectSrcExcelDir.Location = new System.Drawing.Point(828, 27);
            this.btnSelectSrcExcelDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectSrcExcelDir.Name = "btnSelectSrcExcelDir";
            this.btnSelectSrcExcelDir.Size = new System.Drawing.Size(100, 29);
            this.btnSelectSrcExcelDir.TabIndex = 3;
            this.btnSelectSrcExcelDir.Text = "Select";
            this.btnSelectSrcExcelDir.UseVisualStyleBackColor = true;
            this.btnSelectSrcExcelDir.Click += new System.EventHandler(this.btnSelectSrcExcelDir_Click);
            // 
            // txtCSharpCompiler
            // 
            this.txtCSharpCompiler.Location = new System.Drawing.Point(4, 31);
            this.txtCSharpCompiler.Margin = new System.Windows.Forms.Padding(4);
            this.txtCSharpCompiler.Name = "txtCSharpCompiler";
            this.txtCSharpCompiler.Size = new System.Drawing.Size(816, 25);
            this.txtCSharpCompiler.TabIndex = 6;
            this.txtCSharpCompiler.Text = "CSharp Compiler Directory (\"C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\csc.e" +
    "xe\")";
            this.txtCSharpCompiler.TextChanged += new System.EventHandler(this.txtCSharpCompiler_TextChanged);
            // 
            // btnSelectCSharpCompiler
            // 
            this.btnSelectCSharpCompiler.Location = new System.Drawing.Point(828, 27);
            this.btnSelectCSharpCompiler.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectCSharpCompiler.Name = "btnSelectCSharpCompiler";
            this.btnSelectCSharpCompiler.Size = new System.Drawing.Size(100, 29);
            this.btnSelectCSharpCompiler.TabIndex = 9;
            this.btnSelectCSharpCompiler.Text = "Select";
            this.btnSelectCSharpCompiler.UseVisualStyleBackColor = true;
            this.btnSelectCSharpCompiler.Click += new System.EventHandler(this.btnSelectCSharpCompiler_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(358, 22);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(213, 34);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(22, 338);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox6.Size = new System.Drawing.Size(958, 285);
            this.textBox6.TabIndex = 11;
            // 
            // lblOutputProtobufDir
            // 
            this.lblOutputProtobufDir.AutoSize = true;
            this.lblOutputProtobufDir.Location = new System.Drawing.Point(3, 12);
            this.lblOutputProtobufDir.Name = "lblOutputProtobufDir";
            this.lblOutputProtobufDir.Size = new System.Drawing.Size(223, 15);
            this.lblOutputProtobufDir.TabIndex = 12;
            this.lblOutputProtobufDir.Text = "Output Protobuf Directory: ";
            this.lblOutputProtobufDir.Click += new System.EventHandler(this.label1_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Controls.Add(this.panel1);
            this.flowLayoutPanel.Controls.Add(this.panel2);
            this.flowLayoutPanel.Controls.Add(this.panel3);
            this.flowLayoutPanel.Controls.Add(this.panel4);
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(49, 66);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(958, 266);
            this.flowLayoutPanel.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelectOutputProtobufDir);
            this.panel2.Controls.Add(this.txtOutputProtobufDir);
            this.panel2.Controls.Add(this.lblOutputProtobufDir);
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 60);
            this.panel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSrcExcelDir);
            this.panel1.Controls.Add(this.txtSrcExcelDir);
            this.panel1.Controls.Add(this.btnSelectSrcExcelDir);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 60);
            this.panel1.TabIndex = 14;
            // 
            // lblSrcExcelDir
            // 
            this.lblSrcExcelDir.AutoSize = true;
            this.lblSrcExcelDir.Location = new System.Drawing.Point(3, 13);
            this.lblSrcExcelDir.Name = "lblSrcExcelDir";
            this.lblSrcExcelDir.Size = new System.Drawing.Size(191, 15);
            this.lblSrcExcelDir.TabIndex = 13;
            this.lblSrcExcelDir.Text = "Source Excel Directory:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCSharpCompilerDir);
            this.panel3.Controls.Add(this.txtCSharpCompiler);
            this.panel3.Controls.Add(this.btnSelectCSharpCompiler);
            this.panel3.Location = new System.Drawing.Point(3, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(950, 60);
            this.panel3.TabIndex = 14;
            // 
            // lblCSharpCompilerDir
            // 
            this.lblCSharpCompilerDir.AutoSize = true;
            this.lblCSharpCompilerDir.Location = new System.Drawing.Point(3, 12);
            this.lblCSharpCompilerDir.Name = "lblCSharpCompilerDir";
            this.lblCSharpCompilerDir.Size = new System.Drawing.Size(215, 15);
            this.lblCSharpCompilerDir.TabIndex = 14;
            this.lblCSharpCompilerDir.Text = "CSharp Compiler Directory:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Location = new System.Drawing.Point(3, 201);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(950, 60);
            this.panel4.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Location = new System.Drawing.Point(27, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 648);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel2Protobuf Tool";
            // 
            // HiProtobuf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1067, 703);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HiProtobuf";
            this.Text = "HiProtobuf";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectOutputProtobufDir;
        private System.Windows.Forms.TextBox txtOutputProtobufDir;
        private System.Windows.Forms.TextBox txtSrcExcelDir;
        private System.Windows.Forms.Button btnSelectSrcExcelDir;
        private System.Windows.Forms.TextBox txtCSharpCompiler;
        private System.Windows.Forms.Button btnSelectCSharpCompiler;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lblOutputProtobufDir;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSrcExcelDir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCSharpCompilerDir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

