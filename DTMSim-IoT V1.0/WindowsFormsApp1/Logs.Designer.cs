namespace WindowsFormsApp1
{
    partial class Logs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logs));
            this.logs_btn = new System.Windows.Forms.Button();
            this.trustTableGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.staticLogRadio = new System.Windows.Forms.RadioButton();
            this.logDynamicRadio = new System.Windows.Forms.RadioButton();
            this.tablesGrid = new System.Windows.Forms.DataGridView();
            this.drawChart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.exportCsvBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trustTableGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // logs_btn
            // 
            this.logs_btn.BackColor = System.Drawing.Color.Black;
            this.logs_btn.FlatAppearance.BorderSize = 0;
            this.logs_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logs_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logs_btn.Image = ((System.Drawing.Image)(resources.GetObject("logs_btn.Image")));
            this.logs_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logs_btn.Location = new System.Drawing.Point(931, 10);
            this.logs_btn.Name = "logs_btn";
            this.logs_btn.Size = new System.Drawing.Size(155, 40);
            this.logs_btn.TabIndex = 1;
            this.logs_btn.Text = "Network Logs";
            this.logs_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logs_btn.UseVisualStyleBackColor = false;
            this.logs_btn.Click += new System.EventHandler(this.logs_btn_Click);
            // 
            // trustTableGridView
            // 
            this.trustTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trustTableGridView.Location = new System.Drawing.Point(0, 27);
            this.trustTableGridView.Name = "trustTableGridView";
            this.trustTableGridView.Size = new System.Drawing.Size(1307, 692);
            this.trustTableGridView.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
            this.groupBox1.Controls.Add(this.staticLogRadio);
            this.groupBox1.Controls.Add(this.logDynamicRadio);
            this.groupBox1.Controls.Add(this.tablesGrid);
            this.groupBox1.Controls.Add(this.trustTableGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(34, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1313, 715);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logs";
            // 
            // staticLogRadio
            // 
            this.staticLogRadio.AutoSize = true;
            this.staticLogRadio.Location = new System.Drawing.Point(401, 0);
            this.staticLogRadio.Name = "staticLogRadio";
            this.staticLogRadio.Size = new System.Drawing.Size(67, 21);
            this.staticLogRadio.TabIndex = 5;
            this.staticLogRadio.Text = "Static";
            this.staticLogRadio.UseVisualStyleBackColor = true;
            // 
            // logDynamicRadio
            // 
            this.logDynamicRadio.AutoSize = true;
            this.logDynamicRadio.Checked = true;
            this.logDynamicRadio.Location = new System.Drawing.Point(254, -2);
            this.logDynamicRadio.Name = "logDynamicRadio";
            this.logDynamicRadio.Size = new System.Drawing.Size(87, 21);
            this.logDynamicRadio.TabIndex = 4;
            this.logDynamicRadio.TabStop = true;
            this.logDynamicRadio.Text = "Dynamic";
            this.logDynamicRadio.UseVisualStyleBackColor = true;
            this.logDynamicRadio.CheckedChanged += new System.EventHandler(this.logDynamicRadio_CheckedChanged);
            // 
            // tablesGrid
            // 
            this.tablesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablesGrid.Location = new System.Drawing.Point(0, 27);
            this.tablesGrid.Name = "tablesGrid";
            this.tablesGrid.Size = new System.Drawing.Size(1307, 810);
            this.tablesGrid.TabIndex = 3;
            // 
            // drawChart
            // 
            this.drawChart.BackColor = System.Drawing.Color.Black;
            this.drawChart.FlatAppearance.BorderSize = 0;
            this.drawChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawChart.Image = ((System.Drawing.Image)(resources.GetObject("drawChart.Image")));
            this.drawChart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.drawChart.Location = new System.Drawing.Point(1101, 10);
            this.drawChart.Name = "drawChart";
            this.drawChart.Size = new System.Drawing.Size(130, 40);
            this.drawChart.TabIndex = 7;
            this.drawChart.Text = "View Graph";
            this.drawChart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.drawChart.UseVisualStyleBackColor = false;
            this.drawChart.Click += new System.EventHandler(this.drawChart_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(774, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Trust Table";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exportCsvBtn
            // 
            this.exportCsvBtn.BackColor = System.Drawing.Color.Black;
            this.exportCsvBtn.FlatAppearance.BorderSize = 0;
            this.exportCsvBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportCsvBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportCsvBtn.Image = ((System.Drawing.Image)(resources.GetObject("exportCsvBtn.Image")));
            this.exportCsvBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportCsvBtn.Location = new System.Drawing.Point(1247, 10);
            this.exportCsvBtn.Name = "exportCsvBtn";
            this.exportCsvBtn.Size = new System.Drawing.Size(100, 40);
            this.exportCsvBtn.TabIndex = 8;
            this.exportCsvBtn.Text = "Export";
            this.exportCsvBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportCsvBtn.UseVisualStyleBackColor = false;
            this.exportCsvBtn.Click += new System.EventHandler(this.ExportCsvBtn_Click);
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(1359, 749);
            this.Controls.Add(this.exportCsvBtn);
            this.Controls.Add(this.drawChart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logs_btn);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Logs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distributed Trust Management  IoT Network Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.trustTableGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logs_btn;
        private System.Windows.Forms.DataGridView trustTableGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tablesGrid;
        private System.Windows.Forms.RadioButton staticLogRadio;
        private System.Windows.Forms.RadioButton logDynamicRadio;
        private System.Windows.Forms.Button drawChart;
        private System.Windows.Forms.Button exportCsvBtn;
    }
}