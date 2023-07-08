namespace budget_management_app
{
    partial class StartPageForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel_account = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_summary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Button_add = new Guna.UI2.WinForms.Guna2TileButton();
            this.label_rec_trns = new System.Windows.Forms.Label();
            this.chart_rec_exp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_main = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel_top7 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_summary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_rec_exp)).BeginInit();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel2.Controls.Add(this.label_exit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 50);
            this.panel2.TabIndex = 30;
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI Black", 19.25F, System.Drawing.FontStyle.Bold);
            this.label_exit.ForeColor = System.Drawing.Color.White;
            this.label_exit.Location = new System.Drawing.Point(550, 0);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(33, 36);
            this.label_exit.TabIndex = 37;
            this.label_exit.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(250, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 29);
            this.label2.TabIndex = 36;
            this.label2.Text = "Home";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel1.Location = new System.Drawing.Point(-1, 732);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 22);
            this.panel1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 32;
            this.label1.Text = "Accounts";
            // 
            // flowLayoutPanel_account
            // 
            this.flowLayoutPanel_account.AutoScroll = true;
            this.flowLayoutPanel_account.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flowLayoutPanel_account.Location = new System.Drawing.Point(8, 42);
            this.flowLayoutPanel_account.Name = "flowLayoutPanel_account";
            this.flowLayoutPanel_account.Size = new System.Drawing.Size(548, 75);
            this.flowLayoutPanel_account.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 28);
            this.label3.TabIndex = 34;
            this.label3.Text = "Summary";
            // 
            // chart_summary
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_summary.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_summary.Legends.Add(legend1);
            this.chart_summary.Location = new System.Drawing.Point(8, 176);
            this.chart_summary.Name = "chart_summary";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series1.Legend = "Legend1";
            series1.Name = "DataSeries";
            this.chart_summary.Series.Add(series1);
            this.chart_summary.Size = new System.Drawing.Size(548, 203);
            this.chart_summary.TabIndex = 35;
            // 
            // Button_add
            // 
            this.Button_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_add.BorderThickness = 1;
            this.Button_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_add.FillColor = System.Drawing.Color.Transparent;
            this.Button_add.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.Button_add.ForeColor = System.Drawing.Color.Black;
            this.Button_add.Location = new System.Drawing.Point(8, 385);
            this.Button_add.Name = "Button_add";
            this.Button_add.Size = new System.Drawing.Size(119, 25);
            this.Button_add.TabIndex = 59;
            this.Button_add.Text = "Show More";
            // 
            // label_rec_trns
            // 
            this.label_rec_trns.AutoSize = true;
            this.label_rec_trns.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_rec_trns.Location = new System.Drawing.Point(3, 439);
            this.label_rec_trns.Name = "label_rec_trns";
            this.label_rec_trns.Size = new System.Drawing.Size(290, 28);
            this.label_rec_trns.TabIndex = 60;
            this.label_rec_trns.Text = "Expenses for the last 7 days";
            // 
            // chart_rec_exp
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_rec_exp.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_rec_exp.Legends.Add(legend2);
            this.chart_rec_exp.Location = new System.Drawing.Point(8, 484);
            this.chart_rec_exp.Name = "chart_rec_exp";
            this.chart_rec_exp.Size = new System.Drawing.Size(435, 116);
            this.chart_rec_exp.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(5, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "LAST 30 DAYS";
            // 
            // panel_main
            // 
            this.panel_main.AutoScroll = true;
            this.panel_main.Controls.Add(this.label6);
            this.panel_main.Controls.Add(this.guna2TileButton1);
            this.panel_main.Controls.Add(this.flowLayoutPanel_top7);
            this.panel_main.Controls.Add(this.label5);
            this.panel_main.Controls.Add(this.flowLayoutPanel_account);
            this.panel_main.Controls.Add(this.label4);
            this.panel_main.Controls.Add(this.label1);
            this.panel_main.Controls.Add(this.chart_rec_exp);
            this.panel_main.Controls.Add(this.label3);
            this.panel_main.Controls.Add(this.label_rec_trns);
            this.panel_main.Controls.Add(this.chart_summary);
            this.panel_main.Controls.Add(this.Button_add);
            this.panel_main.Location = new System.Drawing.Point(0, 52);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(582, 680);
            this.panel_main.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 616);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 28);
            this.label5.TabIndex = 63;
            this.label5.Text = "Recent Transactions";
            // 
            // flowLayoutPanel_top7
            // 
            this.flowLayoutPanel_top7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_top7.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.flowLayoutPanel_top7.Location = new System.Drawing.Point(8, 663);
            this.flowLayoutPanel_top7.Name = "flowLayoutPanel_top7";
            this.flowLayoutPanel_top7.Size = new System.Drawing.Size(548, 288);
            this.flowLayoutPanel_top7.TabIndex = 34;
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.guna2TileButton1.BorderThickness = 1;
            this.guna2TileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.guna2TileButton1.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton1.Location = new System.Drawing.Point(8, 969);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.Size = new System.Drawing.Size(119, 25);
            this.guna2TileButton1.TabIndex = 64;
            this.guna2TileButton1.Text = "Show More";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(506, 997);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 28);
            this.label6.TabIndex = 65;
            this.label6.Text = "END";
            // 
            // StartPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartPageForm";
            this.Load += new System.EventHandler(this.StartPageForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_summary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_rec_exp)).EndInit();
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_account;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_summary;
        private Guna.UI2.WinForms.Guna2TileButton Button_add;
        private System.Windows.Forms.Label label_rec_trns;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_rec_exp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_top7;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
        private System.Windows.Forms.Label label6;
    }
}