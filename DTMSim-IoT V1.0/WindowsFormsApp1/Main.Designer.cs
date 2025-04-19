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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.createNetworkBtn = new System.Windows.Forms.Button();
            this.nodeInfoBox = new System.Windows.Forms.GroupBox();
            this.neighbourlbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.trustlbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.serviceslbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IDlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.staticButton = new System.Windows.Forms.RadioButton();
            this.dynamicButton = new System.Windows.Forms.RadioButton();
            this.computeTrustBox = new System.Windows.Forms.PictureBox();
            this.serviceEvaluationBox = new System.Windows.Forms.PictureBox();
            this.networkBox = new System.Windows.Forms.PictureBox();
            this.requestServiceBox = new System.Windows.Forms.PictureBox();
            this.getInfoBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.multicastBox = new System.Windows.Forms.PictureBox();
            this.blackListlbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbNodes_static = new System.Windows.Forms.Panel();
            this.gbNodes = new System.Windows.Forms.Panel();
            this.screenshotBox = new System.Windows.Forms.PictureBox();
            this.nodeInfoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computeTrustBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceEvaluationBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestServiceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getInfoBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multicastBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenshotBox)).BeginInit();
            this.SuspendLayout();
            // 
            // createNetworkBtn
            // 
            this.createNetworkBtn.BackColor = System.Drawing.Color.Black;
            this.createNetworkBtn.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.createNetworkBtn, "createNetworkBtn");
            this.createNetworkBtn.ForeColor = System.Drawing.Color.White;
            this.createNetworkBtn.Name = "createNetworkBtn";
            this.createNetworkBtn.UseVisualStyleBackColor = false;
            this.createNetworkBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // nodeInfoBox
            // 
            this.nodeInfoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
            this.nodeInfoBox.Controls.Add(this.neighbourlbl);
            this.nodeInfoBox.Controls.Add(this.label10);
            this.nodeInfoBox.Controls.Add(this.trustlbl);
            this.nodeInfoBox.Controls.Add(this.label8);
            this.nodeInfoBox.Controls.Add(this.serviceslbl);
            this.nodeInfoBox.Controls.Add(this.label6);
            this.nodeInfoBox.Controls.Add(this.IDlbl);
            this.nodeInfoBox.Controls.Add(this.label3);
            this.nodeInfoBox.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.nodeInfoBox, "nodeInfoBox");
            this.nodeInfoBox.Name = "nodeInfoBox";
            this.nodeInfoBox.TabStop = false;
            // 
            // neighbourlbl
            // 
            resources.ApplyResources(this.neighbourlbl, "neighbourlbl");
            this.neighbourlbl.Name = "neighbourlbl";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // trustlbl
            // 
            resources.ApplyResources(this.trustlbl, "trustlbl");
            this.trustlbl.Name = "trustlbl";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // serviceslbl
            // 
            resources.ApplyResources(this.serviceslbl, "serviceslbl");
            this.serviceslbl.Name = "serviceslbl";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // IDlbl
            // 
            resources.ApplyResources(this.IDlbl, "IDlbl");
            this.IDlbl.Name = "IDlbl";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // nodeInput
            // 
            resources.ApplyResources(this.nodeInput, "nodeInput");
            this.nodeInput.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nodeInput.Name = "nodeInput";
            this.nodeInput.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button5, "button5");
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
            this.groupBox1.Controls.Add(this.detail_lbl);
            this.groupBox1.Controls.Add(this.logTitle);
            this.groupBox1.Controls.Add(this.loglbl);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // detail_lbl
            // 
            resources.ApplyResources(this.detail_lbl, "detail_lbl");
            this.detail_lbl.Name = "detail_lbl";
            // 
            // logTitle
            // 
            resources.ApplyResources(this.logTitle, "logTitle");
            this.logTitle.Name = "logTitle";
            // 
            // loglbl
            // 
            resources.ApplyResources(this.loglbl, "loglbl");
            this.loglbl.Name = "loglbl";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // preToolStripMenuItem
            // 
            this.preToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.preToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.preToolStripMenuItem.Name = "preToolStripMenuItem";
            resources.ApplyResources(this.preToolStripMenuItem, "preToolStripMenuItem");
            this.preToolStripMenuItem.Click += new System.EventHandler(this.preToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.logsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            resources.ApplyResources(this.logsToolStripMenuItem, "logsToolStripMenuItem");
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.manualToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            resources.ApplyResources(this.manualToolStripMenuItem, "manualToolStripMenuItem");
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
            this.groupBox2.Controls.Add(this.staticButton);
            this.groupBox2.Controls.Add(this.dynamicButton);
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
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // staticButton
            // 
            resources.ApplyResources(this.staticButton, "staticButton");
            this.staticButton.Name = "staticButton";
            this.staticButton.TabStop = true;
            this.staticButton.UseVisualStyleBackColor = true;
            this.staticButton.CheckedChanged += new System.EventHandler(this.staticButton_CheckedChanged);
            // 
            // dynamicButton
            // 
            resources.ApplyResources(this.dynamicButton, "dynamicButton");
            this.dynamicButton.Checked = true;
            this.dynamicButton.Name = "dynamicButton";
            this.dynamicButton.TabStop = true;
            this.dynamicButton.UseVisualStyleBackColor = true;
            this.dynamicButton.CheckedChanged += new System.EventHandler(this.dynamicButton_CheckedChanged);
            // 
            // computeTrustBox
            // 
            resources.ApplyResources(this.computeTrustBox, "computeTrustBox");
            this.computeTrustBox.Name = "computeTrustBox";
            this.computeTrustBox.TabStop = false;
            // 
            // serviceEvaluationBox
            // 
            resources.ApplyResources(this.serviceEvaluationBox, "serviceEvaluationBox");
            this.serviceEvaluationBox.Name = "serviceEvaluationBox";
            this.serviceEvaluationBox.TabStop = false;
            // 
            // networkBox
            // 
            resources.ApplyResources(this.networkBox, "networkBox");
            this.networkBox.Name = "networkBox";
            this.networkBox.TabStop = false;
            // 
            // requestServiceBox
            // 
            resources.ApplyResources(this.requestServiceBox, "requestServiceBox");
            this.requestServiceBox.Name = "requestServiceBox";
            this.requestServiceBox.TabStop = false;
            // 
            // getInfoBox
            // 
            resources.ApplyResources(this.getInfoBox, "getInfoBox");
            this.getInfoBox.Name = "getInfoBox";
            this.getInfoBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
            this.groupBox3.Controls.Add(this.multicastBox);
            this.groupBox3.Controls.Add(this.blackListlbl);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // multicastBox
            // 
            this.multicastBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
            resources.ApplyResources(this.multicastBox, "multicastBox");
            this.multicastBox.Name = "multicastBox";
            this.multicastBox.TabStop = false;
            this.multicastBox.Click += new System.EventHandler(this.multicastBox_Click);
            // 
            // blackListlbl
            // 
            resources.ApplyResources(this.blackListlbl, "blackListlbl");
            this.blackListlbl.Name = "blackListlbl";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // gbNodes_static
            // 
            this.gbNodes_static.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.gbNodes_static, "gbNodes_static");
            this.gbNodes_static.Name = "gbNodes_static";
            // 
            // gbNodes
            // 
            this.gbNodes.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.gbNodes, "gbNodes");
            this.gbNodes.Name = "gbNodes";
            // 
            // screenshotBox
            // 
            resources.ApplyResources(this.screenshotBox, "screenshotBox");
            this.screenshotBox.Name = "screenshotBox";
            this.screenshotBox.TabStop = false;
            this.screenshotBox.Click += new System.EventHandler(this.screenshotBox_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbNodes_static);
            this.Controls.Add(this.gbNodes);
            this.Controls.Add(this.nodeInfoBox);
            this.Controls.Add(this.screenshotBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.nodeInfoBox.ResumeLayout(false);
            this.nodeInfoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computeTrustBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceEvaluationBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.networkBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestServiceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getInfoBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multicastBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenshotBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createNetworkBtn;
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
        private System.Windows.Forms.RadioButton staticButton;
        private System.Windows.Forms.RadioButton dynamicButton;
        private System.Windows.Forms.GroupBox nodeInfoBox;
        private System.Windows.Forms.Label neighbourlbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label trustlbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label serviceslbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label IDlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label blackListlbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox multicastBox;
        private System.Windows.Forms.Panel gbNodes;
        private System.Windows.Forms.Panel gbNodes_static;
        private System.Windows.Forms.PictureBox screenshotBox;
    }
}

