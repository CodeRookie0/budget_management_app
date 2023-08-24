namespace budget_management_app
{
    partial class TransactionsHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.transactionsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.accountComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.categoryComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.typeComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.deleteButton = new Guna.UI2.WinForms.Guna2Button();
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.backButton = new Guna.UI2.WinForms.Guna2Button();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(259, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 30);
            this.label2.TabIndex = 35;
            this.label2.Text = "History";
            // 
            // transactionsDataGridView
            // 
            this.transactionsDataGridView.AllowUserToAddRows = false;
            this.transactionsDataGridView.AllowUserToResizeColumns = false;
            this.transactionsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.transactionsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.transactionsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.transactionsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transactionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.transactionsDataGridView.ColumnHeadersHeight = 10;
            this.transactionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.transactionsDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactionsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.transactionsDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.transactionsDataGridView.Location = new System.Drawing.Point(25, 115);
            this.transactionsDataGridView.Name = "transactionsDataGridView";
            this.transactionsDataGridView.ReadOnly = true;
            this.transactionsDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.transactionsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.transactionsDataGridView.Size = new System.Drawing.Size(550, 562);
            this.transactionsDataGridView.TabIndex = 38;
            this.transactionsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.transactionsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.transactionsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.transactionsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.transactionsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.transactionsDataGridView.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionsDataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.transactionsDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.transactionsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.transactionsDataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.transactionsDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.transactionsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.transactionsDataGridView.ThemeStyle.HeaderStyle.Height = 10;
            this.transactionsDataGridView.ThemeStyle.ReadOnly = true;
            this.transactionsDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.transactionsDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.transactionsDataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.transactionsDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.transactionsDataGridView.ThemeStyle.RowsStyle.Height = 22;
            this.transactionsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.transactionsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.transactionsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_transactions_CellContentClick);
            // 
            // accountComboBox
            // 
            this.accountComboBox.BackColor = System.Drawing.Color.Transparent;
            this.accountComboBox.BorderColor = System.Drawing.Color.Red;
            this.accountComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.accountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountComboBox.FocusedColor = System.Drawing.Color.Red;
            this.accountComboBox.FocusedState.BorderColor = System.Drawing.Color.Red;
            this.accountComboBox.FocusedState.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.accountComboBox.FocusedState.ForeColor = System.Drawing.Color.Red;
            this.accountComboBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.accountComboBox.ForeColor = System.Drawing.Color.Red;
            this.accountComboBox.ItemHeight = 30;
            this.accountComboBox.Items.AddRange(new object[] {
            "Account : None"});
            this.accountComboBox.Location = new System.Drawing.Point(25, 73);
            this.accountComboBox.Name = "accountComboBox";
            this.accountComboBox.ShadowDecoration.Color = System.Drawing.Color.Red;
            this.accountComboBox.ShadowDecoration.Depth = 15;
            this.accountComboBox.ShadowDecoration.Enabled = true;
            this.accountComboBox.Size = new System.Drawing.Size(177, 36);
            this.accountComboBox.StartIndex = 0;
            this.accountComboBox.TabIndex = 43;
            this.accountComboBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.accountComboBox.SelectedIndexChanged += new System.EventHandler(this.accountComboBox_SelectedIndexChanged);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.BackColor = System.Drawing.Color.Transparent;
            this.categoryComboBox.BorderColor = System.Drawing.Color.Red;
            this.categoryComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FocusedColor = System.Drawing.Color.Red;
            this.categoryComboBox.FocusedState.BorderColor = System.Drawing.Color.Red;
            this.categoryComboBox.FocusedState.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.categoryComboBox.FocusedState.ForeColor = System.Drawing.Color.Red;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.categoryComboBox.ForeColor = System.Drawing.Color.Red;
            this.categoryComboBox.ItemHeight = 30;
            this.categoryComboBox.Items.AddRange(new object[] {
            "Category : None"});
            this.categoryComboBox.Location = new System.Drawing.Point(202, 73);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.ShadowDecoration.Color = System.Drawing.Color.Red;
            this.categoryComboBox.ShadowDecoration.Depth = 15;
            this.categoryComboBox.ShadowDecoration.Enabled = true;
            this.categoryComboBox.Size = new System.Drawing.Size(177, 36);
            this.categoryComboBox.StartIndex = 0;
            this.categoryComboBox.TabIndex = 74;
            this.categoryComboBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // typeComboBox
            // 
            this.typeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.typeComboBox.BorderColor = System.Drawing.Color.Red;
            this.typeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FocusedColor = System.Drawing.Color.Red;
            this.typeComboBox.FocusedState.BorderColor = System.Drawing.Color.Red;
            this.typeComboBox.FocusedState.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.typeComboBox.FocusedState.ForeColor = System.Drawing.Color.Red;
            this.typeComboBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.typeComboBox.ForeColor = System.Drawing.Color.Red;
            this.typeComboBox.ItemHeight = 30;
            this.typeComboBox.Items.AddRange(new object[] {
            "Type : None",
            "Income",
            "Expenses"});
            this.typeComboBox.Location = new System.Drawing.Point(379, 73);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.ShadowDecoration.Color = System.Drawing.Color.Red;
            this.typeComboBox.ShadowDecoration.Depth = 15;
            this.typeComboBox.ShadowDecoration.Enabled = true;
            this.typeComboBox.Size = new System.Drawing.Size(177, 36);
            this.typeComboBox.StartIndex = 0;
            this.typeComboBox.TabIndex = 75;
            this.typeComboBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.BorderRadius = 15;
            this.deleteButton.BorderThickness = 2;
            this.deleteButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteButton.FillColor = System.Drawing.Color.White;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.75F, System.Drawing.FontStyle.Bold);
            this.deleteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.HoverState.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.75F, System.Drawing.FontStyle.Bold);
            this.deleteButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(356, 693);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.ShadowDecoration.BorderRadius = 20;
            this.deleteButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.deleteButton.ShadowDecoration.Enabled = true;
            this.deleteButton.Size = new System.Drawing.Size(100, 45);
            this.deleteButton.TabIndex = 91;
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.addButton.BorderRadius = 15;
            this.addButton.BorderThickness = 2;
            this.addButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addButton.FillColor = System.Drawing.Color.White;
            this.addButton.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.75F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.addButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.addButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.addButton.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F, System.Drawing.FontStyle.Bold);
            this.addButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(124, 693);
            this.addButton.Name = "addButton";
            this.addButton.ShadowDecoration.BorderRadius = 20;
            this.addButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.addButton.ShadowDecoration.Enabled = true;
            this.addButton.Size = new System.Drawing.Size(100, 45);
            this.addButton.TabIndex = 90;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.backButton.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.backButton.FillColor = System.Drawing.Color.Transparent;
            this.backButton.FocusedColor = System.Drawing.Color.Transparent;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.backButton.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.backButton.HoverState.Image = global::budget_management_app.Properties.Resources.back_grey;
            this.backButton.Image = global::budget_management_app.Properties.Resources.back_red;
            this.backButton.ImageSize = new System.Drawing.Size(50, 50);
            this.backButton.Location = new System.Drawing.Point(-1, 0);
            this.backButton.Name = "backButton";
            this.backButton.PressedColor = System.Drawing.Color.Transparent;
            this.backButton.PressedDepth = 0;
            this.backButton.Size = new System.Drawing.Size(58, 56);
            this.backButton.TabIndex = 73;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Red;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Red;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 37;
            this.iconPictureBox1.Location = new System.Drawing.Point(219, 15);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(37, 37);
            this.iconPictureBox1.TabIndex = 76;
            this.iconPictureBox1.TabStop = false;
            // 
            // TransactionsHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.accountComboBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transactionsDataGridView);
            this.Controls.Add(this.iconPictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionsHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView transactionsDataGridView;
        private Guna.UI2.WinForms.Guna2Button backButton;
        private Guna.UI2.WinForms.Guna2ComboBox accountComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox categoryComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox typeComboBox;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2Button deleteButton;
        private Guna.UI2.WinForms.Guna2Button addButton;
    }
}