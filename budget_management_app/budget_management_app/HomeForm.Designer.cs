﻿namespace budget_management_app
{
    partial class HomeForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
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
            this.label6 = new System.Windows.Forms.Label();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.flowLayoutPanel_top7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_Sidebar = new System.Windows.Forms.Panel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox_menu = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_settings = new System.Windows.Forms.Button();
            this.button_acc = new System.Windows.Forms.Button();
            this.button_lim = new System.Windows.Forms.Button();
            this.button_cat = new System.Windows.Forms.Button();
            this.button_stat = new System.Windows.Forms.Button();
            this.button_trns = new System.Windows.Forms.Button();
            this.button_home = new System.Windows.Forms.Button();
            this.sidebar_timer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_summary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_rec_exp)).BeginInit();
            this.panel_main.SuspendLayout();
            this.panel_Sidebar.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_menu)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel2.Controls.Add(this.label_exit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(58, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 50);
            this.panel2.TabIndex = 30;
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI Black", 19.25F, System.Drawing.FontStyle.Bold);
            this.label_exit.ForeColor = System.Drawing.Color.White;
            this.label_exit.Location = new System.Drawing.Point(491, 0);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(33, 36);
            this.label_exit.TabIndex = 37;
            this.label_exit.Text = "X";
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click);
            this.label_exit.MouseEnter += new System.EventHandler(this.label_exit_MouseEnter);
            this.label_exit.MouseLeave += new System.EventHandler(this.label_exit_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(221, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 29);
            this.label2.TabIndex = 36;
            this.label2.Text = "Home";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel1.Location = new System.Drawing.Point(58, 732);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 22);
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
            this.flowLayoutPanel_account.Size = new System.Drawing.Size(459, 75);
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
            chartArea3.Name = "ChartArea1";
            this.chart_summary.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart_summary.Legends.Add(legend3);
            this.chart_summary.Location = new System.Drawing.Point(8, 176);
            this.chart_summary.Name = "chart_summary";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series2.Legend = "Legend1";
            series2.Name = "DataSeries";
            this.chart_summary.Series.Add(series2);
            this.chart_summary.Size = new System.Drawing.Size(459, 203);
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
            chartArea4.Name = "ChartArea1";
            this.chart_rec_exp.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_rec_exp.Legends.Add(legend4);
            this.chart_rec_exp.Location = new System.Drawing.Point(8, 484);
            this.chart_rec_exp.Name = "chart_rec_exp";
            this.chart_rec_exp.Size = new System.Drawing.Size(459, 116);
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
            this.panel_main.Location = new System.Drawing.Point(76, 52);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(501, 680);
            this.panel_main.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(369, 997);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 28);
            this.label6.TabIndex = 65;
            this.label6.Text = "END";
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
            // flowLayoutPanel_top7
            // 
            this.flowLayoutPanel_top7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_top7.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.flowLayoutPanel_top7.Location = new System.Drawing.Point(8, 663);
            this.flowLayoutPanel_top7.Name = "flowLayoutPanel_top7";
            this.flowLayoutPanel_top7.Size = new System.Drawing.Size(459, 288);
            this.flowLayoutPanel_top7.TabIndex = 34;
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
            // panel_Sidebar
            // 
            this.panel_Sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.panel_Sidebar.Controls.Add(this.guna2GradientPanel1);
            this.panel_Sidebar.Controls.Add(this.guna2GradientPanel2);
            this.panel_Sidebar.Controls.Add(this.button_settings);
            this.panel_Sidebar.Controls.Add(this.button_acc);
            this.panel_Sidebar.Controls.Add(this.button_lim);
            this.panel_Sidebar.Controls.Add(this.button_cat);
            this.panel_Sidebar.Controls.Add(this.button_stat);
            this.panel_Sidebar.Controls.Add(this.button_trns);
            this.panel_Sidebar.Controls.Add(this.button_home);
            this.panel_Sidebar.Location = new System.Drawing.Point(0, 0);
            this.panel_Sidebar.MaximumSize = new System.Drawing.Size(218, 750);
            this.panel_Sidebar.MinimumSize = new System.Drawing.Size(58, 750);
            this.panel_Sidebar.Name = "panel_Sidebar";
            this.panel_Sidebar.Size = new System.Drawing.Size(58, 750);
            this.panel_Sidebar.TabIndex = 69;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(112)))), ((int)(((byte)(92)))));
            this.guna2GradientPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2GradientPanel1.Controls.Add(this.label7);
            this.guna2GradientPanel1.Controls.Add(this.pictureBox_menu);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(218, 119);
            this.guna2GradientPanel1.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(50, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 46);
            this.label7.TabIndex = 70;
            this.label7.Text = "Menu";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_menu
            // 
            this.pictureBox_menu.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_menu.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_menu.Image")));
            this.pictureBox_menu.Location = new System.Drawing.Point(2, 0);
            this.pictureBox_menu.Name = "pictureBox_menu";
            this.pictureBox_menu.Size = new System.Drawing.Size(52, 46);
            this.pictureBox_menu.TabIndex = 67;
            this.pictureBox_menu.TabStop = false;
            this.pictureBox_menu.Click += new System.EventHandler(this.pictureBox_menu_Click_1);
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(112)))), ((int)(((byte)(92)))));
            this.guna2GradientPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2GradientPanel2.Controls.Add(this.button_logout);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 634);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(218, 116);
            this.guna2GradientPanel2.TabIndex = 70;
            // 
            // button_logout
            // 
            this.button_logout.BackColor = System.Drawing.Color.Transparent;
            this.button_logout.FlatAppearance.BorderSize = 0;
            this.button_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_logout.Font = new System.Drawing.Font("Cambria", 18.75F, System.Drawing.FontStyle.Bold);
            this.button_logout.ForeColor = System.Drawing.Color.White;
            this.button_logout.Image = ((System.Drawing.Image)(resources.GetObject("button_logout.Image")));
            this.button_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_logout.Location = new System.Drawing.Point(0, 66);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(218, 50);
            this.button_logout.TabIndex = 69;
            this.button_logout.Text = "       LOGOUT";
            this.button_logout.UseVisualStyleBackColor = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            this.button_logout.MouseEnter += new System.EventHandler(this.button_logout_MouseEnter);
            this.button_logout.MouseLeave += new System.EventHandler(this.button_logout_MouseLeave);
            // 
            // button_settings
            // 
            this.button_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.button_settings.FlatAppearance.BorderSize = 0;
            this.button_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_settings.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.button_settings.ForeColor = System.Drawing.Color.White;
            this.button_settings.Image = ((System.Drawing.Image)(resources.GetObject("button_settings.Image")));
            this.button_settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_settings.Location = new System.Drawing.Point(0, 491);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(216, 36);
            this.button_settings.TabIndex = 81;
            this.button_settings.Text = "           Settings";
            this.button_settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_settings.UseVisualStyleBackColor = false;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // button_acc
            // 
            this.button_acc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.button_acc.FlatAppearance.BorderSize = 0;
            this.button_acc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_acc.Font = new System.Drawing.Font("Cambria", 16.25F, System.Drawing.FontStyle.Bold);
            this.button_acc.ForeColor = System.Drawing.Color.White;
            this.button_acc.Image = ((System.Drawing.Image)(resources.GetObject("button_acc.Image")));
            this.button_acc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_acc.Location = new System.Drawing.Point(0, 186);
            this.button_acc.Name = "button_acc";
            this.button_acc.Size = new System.Drawing.Size(216, 36);
            this.button_acc.TabIndex = 80;
            this.button_acc.Text = "             Accounts";
            this.button_acc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_acc.UseVisualStyleBackColor = false;
            this.button_acc.Click += new System.EventHandler(this.button_acc_Click);
            // 
            // button_lim
            // 
            this.button_lim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.button_lim.FlatAppearance.BorderSize = 0;
            this.button_lim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_lim.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.button_lim.ForeColor = System.Drawing.Color.White;
            this.button_lim.Image = ((System.Drawing.Image)(resources.GetObject("button_lim.Image")));
            this.button_lim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_lim.Location = new System.Drawing.Point(0, 369);
            this.button_lim.Name = "button_lim";
            this.button_lim.Size = new System.Drawing.Size(216, 36);
            this.button_lim.TabIndex = 79;
            this.button_lim.Text = "           Limits";
            this.button_lim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_lim.UseVisualStyleBackColor = false;
            this.button_lim.Click += new System.EventHandler(this.button_lim_Click);
            // 
            // button_cat
            // 
            this.button_cat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.button_cat.FlatAppearance.BorderSize = 0;
            this.button_cat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cat.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.button_cat.ForeColor = System.Drawing.Color.White;
            this.button_cat.Image = ((System.Drawing.Image)(resources.GetObject("button_cat.Image")));
            this.button_cat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cat.Location = new System.Drawing.Point(0, 308);
            this.button_cat.Name = "button_cat";
            this.button_cat.Size = new System.Drawing.Size(216, 36);
            this.button_cat.TabIndex = 78;
            this.button_cat.Text = "           Categories";
            this.button_cat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cat.UseVisualStyleBackColor = false;
            this.button_cat.Click += new System.EventHandler(this.button_cat_Click);
            // 
            // button_stat
            // 
            this.button_stat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.button_stat.FlatAppearance.BorderSize = 0;
            this.button_stat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_stat.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.button_stat.ForeColor = System.Drawing.Color.White;
            this.button_stat.Image = ((System.Drawing.Image)(resources.GetObject("button_stat.Image")));
            this.button_stat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_stat.Location = new System.Drawing.Point(0, 430);
            this.button_stat.Name = "button_stat";
            this.button_stat.Size = new System.Drawing.Size(216, 36);
            this.button_stat.TabIndex = 77;
            this.button_stat.Text = "           Statistics";
            this.button_stat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_stat.UseVisualStyleBackColor = false;
            this.button_stat.Click += new System.EventHandler(this.button_stat_Click);
            // 
            // button_trns
            // 
            this.button_trns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.button_trns.FlatAppearance.BorderSize = 0;
            this.button_trns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_trns.Font = new System.Drawing.Font("Cambria", 16.25F, System.Drawing.FontStyle.Bold);
            this.button_trns.ForeColor = System.Drawing.Color.White;
            this.button_trns.Image = ((System.Drawing.Image)(resources.GetObject("button_trns.Image")));
            this.button_trns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_trns.Location = new System.Drawing.Point(0, 247);
            this.button_trns.Name = "button_trns";
            this.button_trns.Size = new System.Drawing.Size(216, 36);
            this.button_trns.TabIndex = 76;
            this.button_trns.Text = "             Transactions";
            this.button_trns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_trns.UseVisualStyleBackColor = false;
            this.button_trns.Click += new System.EventHandler(this.button_trns_Click);
            // 
            // button_home
            // 
            this.button_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.button_home.FlatAppearance.BorderSize = 0;
            this.button_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_home.Font = new System.Drawing.Font("Cambria", 16.25F, System.Drawing.FontStyle.Bold);
            this.button_home.ForeColor = System.Drawing.Color.White;
            this.button_home.Image = ((System.Drawing.Image)(resources.GetObject("button_home.Image")));
            this.button_home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_home.Location = new System.Drawing.Point(0, 125);
            this.button_home.Name = "button_home";
            this.button_home.Size = new System.Drawing.Size(218, 36);
            this.button_home.TabIndex = 74;
            this.button_home.Text = "             HOME";
            this.button_home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_home.UseVisualStyleBackColor = false;
            this.button_home.Click += new System.EventHandler(this.button_home_Click);
            // 
            // sidebar_timer
            // 
            this.sidebar_timer.Interval = 10;
            this.sidebar_timer.Tick += new System.EventHandler(this.sidebar_timer_Tick);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.panel_Sidebar);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartPageForm";
            this.Load += new System.EventHandler(this.StartPageForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_summary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_rec_exp)).EndInit();
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.panel_Sidebar.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_menu)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel_Sidebar;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox_menu;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.Button button_acc;
        private System.Windows.Forms.Button button_lim;
        private System.Windows.Forms.Button button_cat;
        private System.Windows.Forms.Button button_stat;
        private System.Windows.Forms.Button button_trns;
        private System.Windows.Forms.Button button_home;
        private System.Windows.Forms.Timer sidebar_timer;
        private System.Windows.Forms.Label label7;
    }
}