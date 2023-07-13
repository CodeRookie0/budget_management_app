namespace budget_management_app
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Sidebar = new System.Windows.Forms.Panel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox_sideBar = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.Button_more_sum = new Guna.UI2.WinForms.Guna2TileButton();
            this.chart_summary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_rec_trns = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_rec_exp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel_account = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Button_more_trns = new Guna.UI2.WinForms.Guna2TileButton();
            this.Button_add_trns = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel_main = new System.Windows.Forms.Panel();
            this.DataGridView_top7trns = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel2.SuspendLayout();
            this.panel_Sidebar.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sideBar)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_summary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_rec_exp)).BeginInit();
            this.panel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_top7trns)).BeginInit();
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
            this.guna2GradientPanel1.Controls.Add(this.pictureBox_sideBar);
            this.guna2GradientPanel1.Controls.Add(this.label7);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(218, 119);
            this.guna2GradientPanel1.TabIndex = 69;
            // 
            // pictureBox_sideBar
            // 
            this.pictureBox_sideBar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_sideBar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_sideBar.Image")));
            this.pictureBox_sideBar.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_sideBar.Name = "pictureBox_sideBar";
            this.pictureBox_sideBar.Size = new System.Drawing.Size(219, 48);
            this.pictureBox_sideBar.TabIndex = 71;
            this.pictureBox_sideBar.TabStop = false;
            this.pictureBox_sideBar.Click += new System.EventHandler(this.pictureBox_sideBar_Click);
            this.pictureBox_sideBar.MouseEnter += new System.EventHandler(this.pictureBox_sideBar_MouseEnter);
            this.pictureBox_sideBar.MouseLeave += new System.EventHandler(this.pictureBox_sideBar_MouseLeave);
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
            // Button_more_sum
            // 
            this.Button_more_sum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_more_sum.BorderThickness = 1;
            this.Button_more_sum.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_more_sum.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_more_sum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_more_sum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_more_sum.FillColor = System.Drawing.Color.Transparent;
            this.Button_more_sum.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.Button_more_sum.ForeColor = System.Drawing.Color.Black;
            this.Button_more_sum.Location = new System.Drawing.Point(25, 526);
            this.Button_more_sum.Name = "Button_more_sum";
            this.Button_more_sum.Size = new System.Drawing.Size(119, 25);
            this.Button_more_sum.TabIndex = 59;
            this.Button_more_sum.Text = "Show More";
            this.Button_more_sum.Click += new System.EventHandler(this.Button_more_sum_Click);
            this.Button_more_sum.MouseEnter += new System.EventHandler(this.Button_more_sum_MouseEnter);
            this.Button_more_sum.MouseLeave += new System.EventHandler(this.Button_more_sum_MouseLeave);
            // 
            // chart_summary
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_summary.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart_summary.Legends.Add(legend1);
            this.chart_summary.Location = new System.Drawing.Point(25, 256);
            this.chart_summary.Name = "chart_summary";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series1.Legend = "Legend1";
            series1.Name = "DataSeries";
            this.chart_summary.Series.Add(series1);
            this.chart_summary.Size = new System.Drawing.Size(459, 243);
            this.chart_summary.TabIndex = 35;
            // 
            // label_rec_trns
            // 
            this.label_rec_trns.AutoSize = true;
            this.label_rec_trns.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_rec_trns.Location = new System.Drawing.Point(20, 596);
            this.label_rec_trns.Name = "label_rec_trns";
            this.label_rec_trns.Size = new System.Drawing.Size(290, 28);
            this.label_rec_trns.TabIndex = 60;
            this.label_rec_trns.Text = "Expenses for the last 7 days";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(20, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 28);
            this.label3.TabIndex = 34;
            this.label3.Text = "Summary";
            // 
            // chart_rec_exp
            // 
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea1";
            this.chart_rec_exp.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_rec_exp.Legends.Add(legend2);
            this.chart_rec_exp.Location = new System.Drawing.Point(0, 641);
            this.chart_rec_exp.Name = "chart_rec_exp";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.SystemColors.Highlight;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Expenses";
            this.chart_rec_exp.Series.Add(series2);
            this.chart_rec_exp.Size = new System.Drawing.Size(467, 276);
            this.chart_rec_exp.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 32;
            this.label1.Text = "Accounts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(22, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "LAST 30 DAYS";
            // 
            // flowLayoutPanel_account
            // 
            this.flowLayoutPanel_account.AutoScroll = true;
            this.flowLayoutPanel_account.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_account.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flowLayoutPanel_account.Location = new System.Drawing.Point(29, 53);
            this.flowLayoutPanel_account.Name = "flowLayoutPanel_account";
            this.flowLayoutPanel_account.Size = new System.Drawing.Size(444, 75);
            this.flowLayoutPanel_account.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(20, 960);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 28);
            this.label5.TabIndex = 63;
            this.label5.Text = "Recent Transactions";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Sitka Small Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(383, 1244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 47);
            this.label6.TabIndex = 65;
            // 
            // Button_more_trns
            // 
            this.Button_more_trns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_more_trns.BorderThickness = 1;
            this.Button_more_trns.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_more_trns.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_more_trns.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_more_trns.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_more_trns.FillColor = System.Drawing.Color.Transparent;
            this.Button_more_trns.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.Button_more_trns.ForeColor = System.Drawing.Color.Black;
            this.Button_more_trns.Location = new System.Drawing.Point(25, 1226);
            this.Button_more_trns.Name = "Button_more_trns";
            this.Button_more_trns.Size = new System.Drawing.Size(119, 25);
            this.Button_more_trns.TabIndex = 64;
            this.Button_more_trns.Text = "Show More";
            this.Button_more_trns.Click += new System.EventHandler(this.Button_more_trns_Click);
            this.Button_more_trns.MouseEnter += new System.EventHandler(this.Button_more_trns_MouseEnter);
            this.Button_more_trns.MouseLeave += new System.EventHandler(this.Button_more_trns_MouseLeave);
            // 
            // Button_add_trns
            // 
            this.Button_add_trns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_add_trns.BorderThickness = 1;
            this.Button_add_trns.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_add_trns.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_add_trns.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_add_trns.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_add_trns.FillColor = System.Drawing.Color.Transparent;
            this.Button_add_trns.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold);
            this.Button_add_trns.ForeColor = System.Drawing.Color.Black;
            this.Button_add_trns.Location = new System.Drawing.Point(168, 148);
            this.Button_add_trns.Name = "Button_add_trns";
            this.Button_add_trns.Size = new System.Drawing.Size(167, 32);
            this.Button_add_trns.TabIndex = 66;
            this.Button_add_trns.Text = "Add Transaction";
            this.Button_add_trns.Click += new System.EventHandler(this.Button_add_trns_Click);
            this.Button_add_trns.MouseEnter += new System.EventHandler(this.Button_add_trns_MouseEnter);
            this.Button_add_trns.MouseLeave += new System.EventHandler(this.Button_add_trns_MouseLeave);
            // 
            // panel_main
            // 
            this.panel_main.AutoScroll = true;
            this.panel_main.Controls.Add(this.DataGridView_top7trns);
            this.panel_main.Controls.Add(this.label6);
            this.panel_main.Controls.Add(this.label1);
            this.panel_main.Controls.Add(this.flowLayoutPanel_account);
            this.panel_main.Controls.Add(this.Button_add_trns);
            this.panel_main.Controls.Add(this.Button_more_trns);
            this.panel_main.Controls.Add(this.label5);
            this.panel_main.Controls.Add(this.label4);
            this.panel_main.Controls.Add(this.chart_rec_exp);
            this.panel_main.Controls.Add(this.label3);
            this.panel_main.Controls.Add(this.label_rec_trns);
            this.panel_main.Controls.Add(this.chart_summary);
            this.panel_main.Controls.Add(this.Button_more_sum);
            this.panel_main.Location = new System.Drawing.Point(58, 52);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(519, 680);
            this.panel_main.TabIndex = 63;
            // 
            // DataGridView_top7trns
            // 
            this.DataGridView_top7trns.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridView_top7trns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_top7trns.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_top7trns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_top7trns.ColumnHeadersHeight = 4;
            this.DataGridView_top7trns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_top7trns.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_top7trns.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView_top7trns.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.DataGridView_top7trns.Location = new System.Drawing.Point(16, 1012);
            this.DataGridView_top7trns.Name = "DataGridView_top7trns";
            this.DataGridView_top7trns.ReadOnly = true;
            this.DataGridView_top7trns.RowHeadersVisible = false;
            this.DataGridView_top7trns.Size = new System.Drawing.Size(464, 198);
            this.DataGridView_top7trns.TabIndex = 67;
            this.DataGridView_top7trns.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_top7trns.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_top7trns.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_top7trns.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_top7trns.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_top7trns.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_top7trns.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.DataGridView_top7trns.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_top7trns.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_top7trns.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataGridView_top7trns.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_top7trns.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_top7trns.ThemeStyle.HeaderStyle.Height = 4;
            this.DataGridView_top7trns.ThemeStyle.ReadOnly = true;
            this.DataGridView_top7trns.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_top7trns.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_top7trns.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataGridView_top7trns.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_top7trns.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridView_top7trns.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_top7trns.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            this.panel_Sidebar.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sideBar)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_summary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_rec_exp)).EndInit();
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_top7trns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Panel panel_Sidebar;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
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
        private Guna.UI2.WinForms.Guna2TileButton Button_more_sum;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_summary;
        private System.Windows.Forms.Label label_rec_trns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_rec_exp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_account;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TileButton Button_more_trns;
        private Guna.UI2.WinForms.Guna2TileButton Button_add_trns;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.PictureBox pictureBox_sideBar;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_top7trns;
    }
}