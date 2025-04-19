namespace WindowsFormsApp1
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createNetworkBtn = new System.Windows.Forms.Button();
            this.gbNodes = new System.Windows.Forms.GroupBox();
            this.nodeInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.detail_lbl = new System.Windows.Forms.Label();
            this.logTitle = new System.Windows.Forms.Label();
            this.loglbl = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbNodes_static = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkBox = new System.Windows.Forms.PictureBox();
            this.getInfoBox = new System.Windows.Forms.PictureBox();
            this.requestServiceBox = new System.Windows.Forms.PictureBox();
            this.serviceEvaluationBox = new System.Windows.Forms.PictureBox();
            this.computeTrustBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nodeInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getInfoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestServiceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceEvaluationBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computeTrustBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // createNetworkBtn
            // 
            this.createNetworkBtn.Enabled = false;
            this.createNetworkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNetworkBtn.Location = new System.Drawing.Point(73, 118);
            this.createNetworkBtn.Margin = new System.Windows.Forms.Padding(4);
            this.createNetworkBtn.Name = "createNetworkBtn";
            this.createNetworkBtn.Size = new System.Drawing.Size(129, 28);
            this.createNetworkBtn.TabIndex = 0;
            this.createNetworkBtn.Text = "Create Network";
            this.createNetworkBtn.UseVisualStyleBackColor = true;
            this.createNetworkBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbNodes
            // 
            this.gbNodes.BackColor = System.Drawing.Color.White;
            this.gbNodes.Location = new System.Drawing.Point(4, 4);
            this.gbNodes.Margin = new System.Windows.Forms.Padding(4);
            this.gbNodes.Name = "gbNodes";
            this.gbNodes.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gbNodes.Size = new System.Drawing.Size(1124, 510);
            this.gbNodes.TabIndex = 1;
            this.gbNodes.TabStop = false;
            // 
            // nodeInput
            // 
            this.nodeInput.Location = new System.Drawing.Point(16, 52);
            this.nodeInput.Margin = new System.Windows.Forms.Padding(4);
            this.nodeInput.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nodeInput.Name = "nodeInput";
            this.nodeInput.Size = new System.Drawing.Size(186, 23);
            this.nodeInput.TabIndex = 3;
            this.nodeInput.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Total Nodes";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(73, 211);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Get Initial Info";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(73, 306);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 28);
            this.button3.TabIndex = 6;
            this.button3.Text = "Request Service";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(73, 495);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 28);
            this.button4.TabIndex = 7;
            this.button4.Text = "Compute Trust";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(73, 405);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 28);
            this.button5.TabIndex = 8;
            this.button5.Text = "Service Evaln.";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(799, 28);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(397, 28);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(683, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Processing...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 600);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.detail_lbl);
            this.groupBox1.Controls.Add(this.logTitle);
            this.groupBox1.Controls.Add(this.loglbl);
            this.groupBox1.Location = new System.Drawing.Point(238, 629);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1132, 108);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Logs";
            // 
            // detail_lbl
            // 
            this.detail_lbl.AutoSize = true;
            this.detail_lbl.Location = new System.Drawing.Point(6, 67);
            this.detail_lbl.Name = "detail_lbl";
            this.detail_lbl.Size = new System.Drawing.Size(0, 17);
            this.detail_lbl.TabIndex = 2;
            // 
            // logTitle
            // 
            this.logTitle.AutoSize = true;
            this.logTitle.Location = new System.Drawing.Point(6, 24);
            this.logTitle.Name = "logTitle";
            this.logTitle.Size = new System.Drawing.Size(0, 17);
            this.logTitle.TabIndex = 1;
            // 
            // loglbl
            // 
            this.loglbl.AutoSize = true;
            this.loglbl.Location = new System.Drawing.Point(6, 41);
            this.loglbl.Name = "loglbl";
            this.loglbl.Size = new System.Drawing.Size(0, 17);
            this.loglbl.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(238, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1372, 545);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbNodes);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1364, 516);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dynamic TMS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbNodes_static);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1364, 516);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Static TMS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbNodes_static
            // 
            this.gbNodes_static.Location = new System.Drawing.Point(0, 3);
            this.gbNodes_static.Name = "gbNodes_static";
            this.gbNodes_static.Size = new System.Drawing.Size(1100, 517);
            this.gbNodes_static.TabIndex = 0;
            this.gbNodes_static.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // preToolStripMenuItem
            // 
            this.preToolStripMenuItem.Name = "preToolStripMenuItem";
            this.preToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.preToolStripMenuItem.Text = "Preferences";
            this.preToolStripMenuItem.Click += new System.EventHandler(this.preToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logsToolStripMenuItem.Text = "Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // networkBox
            // 
            this.networkBox.Location = new System.Drawing.Point(16, 108);
            this.networkBox.Name = "networkBox";
            this.networkBox.Size = new System.Drawing.Size(50, 50);
            this.networkBox.TabIndex = 16;
            this.networkBox.TabStop = false;
            // 
            // getInfoBox
            // 
            this.getInfoBox.Location = new System.Drawing.Point(16, 200);
            this.getInfoBox.Name = "getInfoBox";
            this.getInfoBox.Size = new System.Drawing.Size(50, 50);
            this.getInfoBox.TabIndex = 17;
            this.getInfoBox.TabStop = false;
            // 
            // requestServiceBox
            // 
            this.requestServiceBox.Location = new System.Drawing.Point(16, 297);
            this.requestServiceBox.Name = "requestServiceBox";
            this.requestServiceBox.Size = new System.Drawing.Size(50, 50);
            this.requestServiceBox.TabIndex = 18;
            this.requestServiceBox.TabStop = false;
            // 
            // serviceEvaluationBox
            // 
            this.serviceEvaluationBox.Location = new System.Drawing.Point(16, 396);
            this.serviceEvaluationBox.Name = "serviceEvaluationBox";
            this.serviceEvaluationBox.Size = new System.Drawing.Size(50, 50);
            this.serviceEvaluationBox.TabIndex = 19;
            this.serviceEvaluationBox.TabStop = false;
            // 
            // computeTrustBox
            // 
            this.computeTrustBox.Location = new System.Drawing.Point(16, 483);
            this.computeTrustBox.Name = "computeTrustBox";
            this.computeTrustBox.Size = new System.Drawing.Size(50, 50);
            this.computeTrustBox.TabIndex = 20;
            this.computeTrustBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.computeTrustBox);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.createNetworkBtn);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.serviceEvaluationBox);
            this.groupBox2.Controls.Add(this.networkBox);
            this.groupBox2.Controls.Add(this.nodeInput);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.requestServiceBox);
            this.groupBox2.Controls.Add(this.getInfoBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 545);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Network Operations";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "DDTMS IoT Network Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nodeInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.networkBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getInfoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestServiceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceEvaluationBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computeTrustBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createNetworkBtn;
        private System.Windows.Forms.GroupBox gbNodes;
        private System.Windows.Forms.NumericUpDown nodeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label loglbl;
        private System.Windows.Forms.Label logTitle;
        private System.Windows.Forms.Label detail_lbl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbNodes_static;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox networkBox;
        private System.Windows.Forms.PictureBox getInfoBox;
        private System.Windows.Forms.PictureBox requestServiceBox;
        private System.Windows.Forms.PictureBox serviceEvaluationBox;
        private System.Windows.Forms.PictureBox computeTrustBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

