namespace budget_management_app
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.money_flow = new System.Windows.Forms.TabPage();
            this.panel_money_flow = new System.Windows.Forms.Panel();
            this.expenses = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_more_trns_exp = new Guna.UI2.WinForms.Guna2TileButton();
            this.chart_exp_cat = new LiveCharts.WinForms.PieChart();
            this.label_exp_from_date = new System.Windows.Forms.Label();
            this.label_today = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DataGridView_7High_exp = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label_exp_last_X = new System.Windows.Forms.Label();
            this.label_exp_cat = new System.Windows.Forms.Label();
            this.income = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.button_more_trns_in = new Guna.UI2.WinForms.Guna2TileButton();
            this.chart_in_cat = new LiveCharts.WinForms.PieChart();
            this.label_in_from_date = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DataGridView_7High_in = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label_in_last_X = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.raports = new System.Windows.Forms.TabPage();
            this.panel_raport = new System.Windows.Forms.Panel();
            this.panel_bottomBar = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_account = new System.Windows.Forms.ComboBox();
            this.pictureBox_bottomBar = new System.Windows.Forms.PictureBox();
            this.button_1Y = new Guna.UI2.WinForms.Guna2Button();
            this.button_6M = new Guna.UI2.WinForms.Guna2Button();
            this.button_30D = new Guna.UI2.WinForms.Guna2Button();
            this.button_12W = new Guna.UI2.WinForms.Guna2Button();
            this.button_7D = new Guna.UI2.WinForms.Guna2Button();
            this.timer_bottomBar = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.money_flow.SuspendLayout();
            this.expenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_7High_exp)).BeginInit();
            this.income.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_7High_in)).BeginInit();
            this.raports.SuspendLayout();
            this.panel_bottomBar.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bottomBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.panel2.Controls.Add(this.label_exit);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 36);
            this.panel2.TabIndex = 31;
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI Black", 19.25F, System.Drawing.FontStyle.Bold);
            this.label_exit.ForeColor = System.Drawing.Color.White;
            this.label_exit.Location = new System.Drawing.Point(547, 0);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(33, 36);
            this.label_exit.TabIndex = 37;
            this.label_exit.Text = "X";
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click);
            this.label_exit.MouseEnter += new System.EventHandler(this.label_exit_MouseEnter);
            this.label_exit.MouseLeave += new System.EventHandler(this.label_exit_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.panel1.Location = new System.Drawing.Point(-1, 777);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 22);
            this.panel1.TabIndex = 32;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.money_flow);
            this.guna2TabControl1.Controls.Add(this.expenses);
            this.guna2TabControl1.Controls.Add(this.income);
            this.guna2TabControl1.Controls.Add(this.raports);
            this.guna2TabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(145, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 36);
            this.guna2TabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(585, 680);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(157)))), ((int)(((byte)(118)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(157)))), ((int)(((byte)(118)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(145, 40);
            this.guna2TabControl1.TabIndex = 33;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // money_flow
            // 
            this.money_flow.BackColor = System.Drawing.Color.White;
            this.money_flow.Controls.Add(this.panel_money_flow);
            this.money_flow.Location = new System.Drawing.Point(4, 44);
            this.money_flow.Name = "money_flow";
            this.money_flow.Size = new System.Drawing.Size(577, 632);
            this.money_flow.TabIndex = 4;
            this.money_flow.Text = "Money flow";
            // 
            // panel_money_flow
            // 
            this.panel_money_flow.AutoScroll = true;
            this.panel_money_flow.Location = new System.Drawing.Point(0, 0);
            this.panel_money_flow.Name = "panel_money_flow";
            this.panel_money_flow.Size = new System.Drawing.Size(577, 626);
            this.panel_money_flow.TabIndex = 1;
            // 
            // expenses
            // 
            this.expenses.AutoScroll = true;
            this.expenses.BackColor = System.Drawing.Color.White;
            this.expenses.Controls.Add(this.label1);
            this.expenses.Controls.Add(this.Button_more_trns_exp);
            this.expenses.Controls.Add(this.chart_exp_cat);
            this.expenses.Controls.Add(this.label_exp_from_date);
            this.expenses.Controls.Add(this.label_today);
            this.expenses.Controls.Add(this.label3);
            this.expenses.Controls.Add(this.label4);
            this.expenses.Controls.Add(this.DataGridView_7High_exp);
            this.expenses.Controls.Add(this.label_exp_last_X);
            this.expenses.Controls.Add(this.label_exp_cat);
            this.expenses.Location = new System.Drawing.Point(4, 44);
            this.expenses.Name = "expenses";
            this.expenses.Padding = new System.Windows.Forms.Padding(3);
            this.expenses.Size = new System.Drawing.Size(577, 632);
            this.expenses.TabIndex = 0;
            this.expenses.Text = "Expenses";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(306, 994);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 82;
            // 
            // Button_more_trns_exp
            // 
            this.Button_more_trns_exp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_more_trns_exp.BorderThickness = 1;
            this.Button_more_trns_exp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_more_trns_exp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_more_trns_exp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_more_trns_exp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_more_trns_exp.FillColor = System.Drawing.Color.Transparent;
            this.Button_more_trns_exp.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.Button_more_trns_exp.ForeColor = System.Drawing.Color.Black;
            this.Button_more_trns_exp.Location = new System.Drawing.Point(8, 953);
            this.Button_more_trns_exp.Name = "Button_more_trns_exp";
            this.Button_more_trns_exp.Size = new System.Drawing.Size(119, 25);
            this.Button_more_trns_exp.TabIndex = 81;
            this.Button_more_trns_exp.Text = "Show More";
            this.Button_more_trns_exp.Click += new System.EventHandler(this.Button_more_trns_Click);
            this.Button_more_trns_exp.MouseEnter += new System.EventHandler(this.Button_more_trns_MouseEnter);
            this.Button_more_trns_exp.MouseLeave += new System.EventHandler(this.Button_more_trns_MouseLeave);
            // 
            // chart_exp_cat
            // 
            this.chart_exp_cat.Location = new System.Drawing.Point(8, 70);
            this.chart_exp_cat.Name = "chart_exp_cat";
            this.chart_exp_cat.Size = new System.Drawing.Size(549, 372);
            this.chart_exp_cat.TabIndex = 80;
            // 
            // label_exp_from_date
            // 
            this.label_exp_from_date.AutoSize = true;
            this.label_exp_from_date.Font = new System.Drawing.Font("Sitka Small", 9F);
            this.label_exp_from_date.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_exp_from_date.Location = new System.Drawing.Point(5, 689);
            this.label_exp_from_date.Name = "label_exp_from_date";
            this.label_exp_from_date.Size = new System.Drawing.Size(40, 18);
            this.label_exp_from_date.TabIndex = 79;
            this.label_exp_from_date.Text = "7 Jun";
            // 
            // label_today
            // 
            this.label_today.AutoSize = true;
            this.label_today.Font = new System.Drawing.Font("Sitka Small", 9F);
            this.label_today.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_today.Location = new System.Drawing.Point(506, 689);
            this.label_today.Name = "label_today";
            this.label_today.Size = new System.Drawing.Size(44, 18);
            this.label_today.TabIndex = 78;
            this.label_today.Text = "Today";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(6, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 77;
            this.label3.Text = "CHART";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(6, 733);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 23);
            this.label4.TabIndex = 76;
            this.label4.Text = "HIGHEST EXPENSES";
            // 
            // DataGridView_7High_exp
            // 
            this.DataGridView_7High_exp.AllowUserToAddRows = false;
            this.DataGridView_7High_exp.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_exp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_7High_exp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_7High_exp.ColumnHeadersHeight = 4;
            this.DataGridView_7High_exp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_7High_exp.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_7High_exp.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView_7High_exp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_exp.Location = new System.Drawing.Point(8, 774);
            this.DataGridView_7High_exp.Name = "DataGridView_7High_exp";
            this.DataGridView_7High_exp.ReadOnly = true;
            this.DataGridView_7High_exp.RowHeadersVisible = false;
            this.DataGridView_7High_exp.Size = new System.Drawing.Size(542, 163);
            this.DataGridView_7High_exp.TabIndex = 75;
            this.DataGridView_7High_exp.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_exp.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_7High_exp.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_7High_exp.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_7High_exp.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_7High_exp.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_exp.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_exp.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_exp.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_7High_exp.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DataGridView_7High_exp.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_7High_exp.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_7High_exp.ThemeStyle.HeaderStyle.Height = 4;
            this.DataGridView_7High_exp.ThemeStyle.ReadOnly = true;
            this.DataGridView_7High_exp.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_exp.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_7High_exp.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DataGridView_7High_exp.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_7High_exp.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridView_7High_exp.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_exp.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label_exp_last_X
            // 
            this.label_exp_last_X.AutoSize = true;
            this.label_exp_last_X.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label_exp_last_X.Location = new System.Drawing.Point(6, 48);
            this.label_exp_last_X.Name = "label_exp_last_X";
            this.label_exp_last_X.Size = new System.Drawing.Size(96, 19);
            this.label_exp_last_X.TabIndex = 74;
            this.label_exp_last_X.Text = "LAST 30 DAYS";
            // 
            // label_exp_cat
            // 
            this.label_exp_cat.AutoSize = true;
            this.label_exp_cat.Font = new System.Drawing.Font("Sitka Small Semibold", 18.25F, System.Drawing.FontStyle.Bold);
            this.label_exp_cat.Location = new System.Drawing.Point(3, 3);
            this.label_exp_cat.Name = "label_exp_cat";
            this.label_exp_cat.Size = new System.Drawing.Size(294, 36);
            this.label_exp_cat.TabIndex = 73;
            this.label_exp_cat.Text = "Expenses by category";
            // 
            // income
            // 
            this.income.AutoScroll = true;
            this.income.BackColor = System.Drawing.Color.White;
            this.income.Controls.Add(this.label17);
            this.income.Controls.Add(this.button_more_trns_in);
            this.income.Controls.Add(this.chart_in_cat);
            this.income.Controls.Add(this.label_in_from_date);
            this.income.Controls.Add(this.label6);
            this.income.Controls.Add(this.label7);
            this.income.Controls.Add(this.label8);
            this.income.Controls.Add(this.DataGridView_7High_in);
            this.income.Controls.Add(this.label_in_last_X);
            this.income.Controls.Add(this.label10);
            this.income.Location = new System.Drawing.Point(4, 44);
            this.income.Name = "income";
            this.income.Size = new System.Drawing.Size(577, 632);
            this.income.TabIndex = 2;
            this.income.Text = "Income";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Sitka Small", 9F);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(311, 1002);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 18);
            this.label17.TabIndex = 90;
            // 
            // button_more_trns_in
            // 
            this.button_more_trns_in.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.button_more_trns_in.BorderThickness = 1;
            this.button_more_trns_in.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_more_trns_in.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_more_trns_in.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_more_trns_in.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_more_trns_in.FillColor = System.Drawing.Color.Transparent;
            this.button_more_trns_in.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.button_more_trns_in.ForeColor = System.Drawing.Color.Black;
            this.button_more_trns_in.Location = new System.Drawing.Point(10, 952);
            this.button_more_trns_in.Name = "button_more_trns_in";
            this.button_more_trns_in.Size = new System.Drawing.Size(119, 25);
            this.button_more_trns_in.TabIndex = 89;
            this.button_more_trns_in.Text = "Show More";
            // 
            // chart_in_cat
            // 
            this.chart_in_cat.Location = new System.Drawing.Point(8, 70);
            this.chart_in_cat.Name = "chart_in_cat";
            this.chart_in_cat.Size = new System.Drawing.Size(549, 372);
            this.chart_in_cat.TabIndex = 88;
            // 
            // label_in_from_date
            // 
            this.label_in_from_date.AutoSize = true;
            this.label_in_from_date.Font = new System.Drawing.Font("Sitka Small", 9F);
            this.label_in_from_date.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_in_from_date.Location = new System.Drawing.Point(5, 689);
            this.label_in_from_date.Name = "label_in_from_date";
            this.label_in_from_date.Size = new System.Drawing.Size(40, 18);
            this.label_in_from_date.TabIndex = 87;
            this.label_in_from_date.Text = "7 Jun";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Small", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(506, 689);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 86;
            this.label6.Text = "Today";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sitka Small", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(6, 468);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 23);
            this.label7.TabIndex = 85;
            this.label7.Text = "CHART";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(6, 733);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 23);
            this.label8.TabIndex = 84;
            this.label8.Text = "HIGHEST EXPENSES";
            // 
            // DataGridView_7High_in
            // 
            this.DataGridView_7High_in.AllowUserToAddRows = false;
            this.DataGridView_7High_in.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_in.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_7High_in.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView_7High_in.ColumnHeadersHeight = 4;
            this.DataGridView_7High_in.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_7High_in.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_7High_in.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView_7High_in.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_in.Location = new System.Drawing.Point(8, 773);
            this.DataGridView_7High_in.Name = "DataGridView_7High_in";
            this.DataGridView_7High_in.ReadOnly = true;
            this.DataGridView_7High_in.RowHeadersVisible = false;
            this.DataGridView_7High_in.Size = new System.Drawing.Size(542, 163);
            this.DataGridView_7High_in.TabIndex = 83;
            this.DataGridView_7High_in.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_in.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_7High_in.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_7High_in.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_7High_in.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_7High_in.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_in.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_in.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_in.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_7High_in.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DataGridView_7High_in.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_7High_in.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_7High_in.ThemeStyle.HeaderStyle.Height = 4;
            this.DataGridView_7High_in.ThemeStyle.ReadOnly = true;
            this.DataGridView_7High_in.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_7High_in.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_7High_in.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DataGridView_7High_in.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_7High_in.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridView_7High_in.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_7High_in.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label_in_last_X
            // 
            this.label_in_last_X.AutoSize = true;
            this.label_in_last_X.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label_in_last_X.Location = new System.Drawing.Point(6, 48);
            this.label_in_last_X.Name = "label_in_last_X";
            this.label_in_last_X.Size = new System.Drawing.Size(96, 19);
            this.label_in_last_X.TabIndex = 82;
            this.label_in_last_X.Text = "LAST 30 DAYS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Sitka Small Semibold", 18.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(294, 36);
            this.label10.TabIndex = 81;
            this.label10.Text = "Expenses by category";
            // 
            // raports
            // 
            this.raports.BackColor = System.Drawing.Color.White;
            this.raports.Controls.Add(this.panel_raport);
            this.raports.Location = new System.Drawing.Point(4, 44);
            this.raports.Name = "raports";
            this.raports.Size = new System.Drawing.Size(577, 632);
            this.raports.TabIndex = 3;
            this.raports.Text = "Raports";
            // 
            // panel_raport
            // 
            this.panel_raport.AutoScroll = true;
            this.panel_raport.Location = new System.Drawing.Point(0, 0);
            this.panel_raport.Name = "panel_raport";
            this.panel_raport.Size = new System.Drawing.Size(577, 626);
            this.panel_raport.TabIndex = 1;
            // 
            // panel_bottomBar
            // 
            this.panel_bottomBar.Controls.Add(this.guna2Panel1);
            this.panel_bottomBar.Controls.Add(this.pictureBox_bottomBar);
            this.panel_bottomBar.Controls.Add(this.button_1Y);
            this.panel_bottomBar.Controls.Add(this.button_6M);
            this.panel_bottomBar.Controls.Add(this.button_30D);
            this.panel_bottomBar.Controls.Add(this.button_12W);
            this.panel_bottomBar.Controls.Add(this.button_7D);
            this.panel_bottomBar.Location = new System.Drawing.Point(74, 715);
            this.panel_bottomBar.MaximumSize = new System.Drawing.Size(432, 138);
            this.panel_bottomBar.MinimumSize = new System.Drawing.Size(432, 58);
            this.panel_bottomBar.Name = "panel_bottomBar";
            this.panel_bottomBar.Size = new System.Drawing.Size(432, 58);
            this.panel_bottomBar.TabIndex = 34;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.comboBox_account);
            this.guna2Panel1.Location = new System.Drawing.Point(1, 57);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(430, 170);
            this.guna2Panel1.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 28);
            this.label2.TabIndex = 71;
            this.label2.Text = "Account";
            // 
            // comboBox_account
            // 
            this.comboBox_account.Font = new System.Drawing.Font("Sitka Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_account.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.comboBox_account.FormattingEnabled = true;
            this.comboBox_account.Location = new System.Drawing.Point(117, 12);
            this.comboBox_account.Name = "comboBox_account";
            this.comboBox_account.Size = new System.Drawing.Size(296, 31);
            this.comboBox_account.TabIndex = 70;
            this.comboBox_account.SelectedIndexChanged += new System.EventHandler(this.comboBox_account_SelectedIndexChanged);
            // 
            // pictureBox_bottomBar
            // 
            this.pictureBox_bottomBar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_bottomBar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_bottomBar.Image")));
            this.pictureBox_bottomBar.Location = new System.Drawing.Point(191, 0);
            this.pictureBox_bottomBar.Name = "pictureBox_bottomBar";
            this.pictureBox_bottomBar.Size = new System.Drawing.Size(50, 31);
            this.pictureBox_bottomBar.TabIndex = 40;
            this.pictureBox_bottomBar.TabStop = false;
            this.pictureBox_bottomBar.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox_bottomBar.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox_bottomBar.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // button_1Y
            // 
            this.button_1Y.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_1Y.BorderThickness = 1;
            this.button_1Y.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_1Y.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_1Y.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_1Y.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_1Y.FillColor = System.Drawing.Color.White;
            this.button_1Y.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.button_1Y.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_1Y.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.button_1Y.HoverState.ForeColor = System.Drawing.Color.White;
            this.button_1Y.Location = new System.Drawing.Point(345, 31);
            this.button_1Y.Name = "button_1Y";
            this.button_1Y.Size = new System.Drawing.Size(86, 27);
            this.button_1Y.TabIndex = 39;
            this.button_1Y.Text = "1Y";
            this.button_1Y.Click += new System.EventHandler(this.button_1Y_Click);
            // 
            // button_6M
            // 
            this.button_6M.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_6M.BorderThickness = 1;
            this.button_6M.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_6M.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_6M.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_6M.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_6M.FillColor = System.Drawing.Color.White;
            this.button_6M.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.button_6M.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_6M.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.button_6M.HoverState.ForeColor = System.Drawing.Color.White;
            this.button_6M.Location = new System.Drawing.Point(259, 31);
            this.button_6M.Name = "button_6M";
            this.button_6M.Size = new System.Drawing.Size(86, 27);
            this.button_6M.TabIndex = 38;
            this.button_6M.Text = "6M";
            this.button_6M.Click += new System.EventHandler(this.button_6M_Click);
            // 
            // button_30D
            // 
            this.button_30D.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_30D.BorderThickness = 1;
            this.button_30D.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_30D.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_30D.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_30D.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_30D.FillColor = System.Drawing.Color.White;
            this.button_30D.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.button_30D.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_30D.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.button_30D.HoverState.ForeColor = System.Drawing.Color.White;
            this.button_30D.Location = new System.Drawing.Point(87, 31);
            this.button_30D.Name = "button_30D";
            this.button_30D.Size = new System.Drawing.Size(86, 27);
            this.button_30D.TabIndex = 37;
            this.button_30D.Text = "30D";
            this.button_30D.Click += new System.EventHandler(this.button_30D_Click);
            // 
            // button_12W
            // 
            this.button_12W.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_12W.BorderThickness = 1;
            this.button_12W.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_12W.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_12W.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_12W.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_12W.FillColor = System.Drawing.Color.White;
            this.button_12W.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.button_12W.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_12W.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.button_12W.HoverState.ForeColor = System.Drawing.Color.White;
            this.button_12W.Location = new System.Drawing.Point(173, 31);
            this.button_12W.Name = "button_12W";
            this.button_12W.Size = new System.Drawing.Size(86, 27);
            this.button_12W.TabIndex = 36;
            this.button_12W.Text = "12W";
            this.button_12W.Click += new System.EventHandler(this.button_12W_Click);
            // 
            // button_7D
            // 
            this.button_7D.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_7D.BorderThickness = 1;
            this.button_7D.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_7D.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_7D.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_7D.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_7D.FillColor = System.Drawing.Color.White;
            this.button_7D.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.button_7D.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.button_7D.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.button_7D.HoverState.ForeColor = System.Drawing.Color.White;
            this.button_7D.Location = new System.Drawing.Point(1, 31);
            this.button_7D.Name = "button_7D";
            this.button_7D.Size = new System.Drawing.Size(86, 27);
            this.button_7D.TabIndex = 35;
            this.button_7D.Text = "7D";
            this.button_7D.Click += new System.EventHandler(this.button_7D_Click);
            // 
            // timer_bottomBar
            // 
            this.timer_bottomBar.Interval = 10;
            this.timer_bottomBar.Tick += new System.EventHandler(this.timer_bottomBar_Tick);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 798);
            this.Controls.Add(this.panel_bottomBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.guna2TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatisticsForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2TabControl1.ResumeLayout(false);
            this.money_flow.ResumeLayout(false);
            this.expenses.ResumeLayout(false);
            this.expenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_7High_exp)).EndInit();
            this.income.ResumeLayout(false);
            this.income.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_7High_in)).EndInit();
            this.raports.ResumeLayout(false);
            this.panel_bottomBar.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bottomBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage expenses;
        private System.Windows.Forms.TabPage income;
        private System.Windows.Forms.TabPage raports;
        private System.Windows.Forms.TabPage money_flow;
        private System.Windows.Forms.Panel panel_bottomBar;
        private Guna.UI2.WinForms.Guna2Button button_1Y;
        private Guna.UI2.WinForms.Guna2Button button_6M;
        private Guna.UI2.WinForms.Guna2Button button_30D;
        private Guna.UI2.WinForms.Guna2Button button_12W;
        private Guna.UI2.WinForms.Guna2Button button_7D;
        private System.Windows.Forms.PictureBox pictureBox_bottomBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_account;
        private System.Windows.Forms.Timer timer_bottomBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Panel panel_raport;
        private System.Windows.Forms.Panel panel_money_flow;
        private LiveCharts.WinForms.PieChart chart_exp_cat;
        private System.Windows.Forms.Label label_exp_from_date;
        private System.Windows.Forms.Label label_today;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_7High_exp;
        private System.Windows.Forms.Label label_exp_last_X;
        private System.Windows.Forms.Label label_exp_cat;
        private Guna.UI2.WinForms.Guna2TileButton Button_more_trns_exp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2TileButton button_more_trns_in;
        private LiveCharts.WinForms.PieChart chart_in_cat;
        private System.Windows.Forms.Label label_in_from_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_7High_in;
        private System.Windows.Forms.Label label_in_last_X;
        private System.Windows.Forms.Label label10;
    }
}