namespace budget_management_app
{
    partial class AddTransactionForm
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
            this.currencyLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.backButton = new Guna.UI2.WinForms.Guna2Button();
            this.transactionAmountTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.accountComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.transactionTypeComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.label12 = new System.Windows.Forms.Label();
            this.transactionDateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.transactionCategoryContextMenu = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.transactionCategoryButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.currencyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.currencyLabel.Location = new System.Drawing.Point(439, 570);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(70, 37);
            this.currencyLabel.TabIndex = 65;
            this.currencyLabel.Text = "USD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Variable Display", 17.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(190, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 32);
            this.label8.TabIndex = 71;
            this.label8.Text = "New transaction";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.guna2Panel1.BorderRadius = 40;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.label8);
            this.guna2Panel1.Controls.Add(this.backButton);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, -77);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 45;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(7);
            this.guna2Panel1.Size = new System.Drawing.Size(581, 165);
            this.guna2Panel1.TabIndex = 73;
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
            this.backButton.Image = global::budget_management_app.Properties.Resources.back_white;
            this.backButton.ImageSize = new System.Drawing.Size(50, 50);
            this.backButton.Location = new System.Drawing.Point(0, 74);
            this.backButton.Name = "backButton";
            this.backButton.PressedColor = System.Drawing.Color.Transparent;
            this.backButton.PressedDepth = 0;
            this.backButton.Size = new System.Drawing.Size(58, 81);
            this.backButton.TabIndex = 72;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // transactionAmountTextBox
            // 
            this.transactionAmountTextBox.BackColor = System.Drawing.Color.Transparent;
            this.transactionAmountTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionAmountTextBox.BorderRadius = 20;
            this.transactionAmountTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.transactionAmountTextBox.DefaultText = "0,00";
            this.transactionAmountTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.transactionAmountTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.transactionAmountTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.transactionAmountTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.transactionAmountTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionAmountTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.transactionAmountTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.transactionAmountTextBox.ForeColor = System.Drawing.Color.Black;
            this.transactionAmountTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.transactionAmountTextBox.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.transactionAmountTextBox.Location = new System.Drawing.Point(265, 563);
            this.transactionAmountTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.transactionAmountTextBox.Name = "transactionAmountTextBox";
            this.transactionAmountTextBox.PasswordChar = '\0';
            this.transactionAmountTextBox.PlaceholderText = "";
            this.transactionAmountTextBox.SelectedText = "";
            this.transactionAmountTextBox.ShadowDecoration.BorderRadius = 20;
            this.transactionAmountTextBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionAmountTextBox.Size = new System.Drawing.Size(268, 51);
            this.transactionAmountTextBox.TabIndex = 75;
            this.transactionAmountTextBox.TextOffset = new System.Drawing.Point(10, 0);
            this.transactionAmountTextBox.TextChanged += new System.EventHandler(this.transactionAmountTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(43, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 74;
            this.label2.Text = "Account";
            // 
            // accountComboBox
            // 
            this.accountComboBox.BackColor = System.Drawing.Color.Transparent;
            this.accountComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.accountComboBox.BorderRadius = 20;
            this.accountComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.accountComboBox.DropDownHeight = 250;
            this.accountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountComboBox.DropDownWidth = 480;
            this.accountComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.accountComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accountComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.accountComboBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F, System.Drawing.FontStyle.Bold);
            this.accountComboBox.ForeColor = System.Drawing.Color.Black;
            this.accountComboBox.IntegralHeight = false;
            this.accountComboBox.ItemHeight = 45;
            this.accountComboBox.Location = new System.Drawing.Point(47, 170);
            this.accountComboBox.Name = "accountComboBox";
            this.accountComboBox.ShadowDecoration.BorderRadius = 20;
            this.accountComboBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.accountComboBox.Size = new System.Drawing.Size(486, 51);
            this.accountComboBox.TabIndex = 76;
            this.accountComboBox.TextOffset = new System.Drawing.Point(10, 0);
            this.accountComboBox.SelectedIndexChanged += new System.EventHandler(this.accountComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(43, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 22);
            this.label9.TabIndex = 77;
            this.label9.Text = "Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(43, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 22);
            this.label10.TabIndex = 78;
            this.label10.Text = "Category";
            // 
            // transactionTypeComboBox
            // 
            this.transactionTypeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.transactionTypeComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionTypeComboBox.BorderRadius = 20;
            this.transactionTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.transactionTypeComboBox.DropDownHeight = 250;
            this.transactionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transactionTypeComboBox.DropDownWidth = 480;
            this.transactionTypeComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionTypeComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.transactionTypeComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.transactionTypeComboBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F, System.Drawing.FontStyle.Bold);
            this.transactionTypeComboBox.ForeColor = System.Drawing.Color.Black;
            this.transactionTypeComboBox.IntegralHeight = false;
            this.transactionTypeComboBox.ItemHeight = 45;
            this.transactionTypeComboBox.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.transactionTypeComboBox.Location = new System.Drawing.Point(47, 432);
            this.transactionTypeComboBox.Name = "transactionTypeComboBox";
            this.transactionTypeComboBox.ShadowDecoration.BorderRadius = 20;
            this.transactionTypeComboBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionTypeComboBox.Size = new System.Drawing.Size(486, 51);
            this.transactionTypeComboBox.TabIndex = 79;
            this.transactionTypeComboBox.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(261, 518);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 22);
            this.label11.TabIndex = 81;
            this.label11.Text = "Amount";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.addButton.BorderRadius = 15;
            this.addButton.BorderThickness = 2;
            this.addButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.addButton.Font = new System.Drawing.Font("Segoe UI Variable Display", 15.75F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.addButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.addButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.addButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(228, 671);
            this.addButton.Name = "addButton";
            this.addButton.ShadowDecoration.BorderRadius = 20;
            this.addButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.addButton.Size = new System.Drawing.Size(124, 51);
            this.addButton.TabIndex = 82;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(43, 518);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 22);
            this.label12.TabIndex = 83;
            this.label12.Text = "Date";
            // 
            // transactionDateTimePicker
            // 
            this.transactionDateTimePicker.BackColor = System.Drawing.Color.Transparent;
            this.transactionDateTimePicker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionDateTimePicker.BorderRadius = 20;
            this.transactionDateTimePicker.BorderThickness = 1;
            this.transactionDateTimePicker.Checked = true;
            this.transactionDateTimePicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionDateTimePicker.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionDateTimePicker.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.transactionDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.transactionDateTimePicker.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionDateTimePicker.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionDateTimePicker.HoverState.ForeColor = System.Drawing.Color.Black;
            this.transactionDateTimePicker.Location = new System.Drawing.Point(47, 563);
            this.transactionDateTimePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.transactionDateTimePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.transactionDateTimePicker.Name = "transactionDateTimePicker";
            this.transactionDateTimePicker.ShadowDecoration.BorderRadius = 20;
            this.transactionDateTimePicker.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionDateTimePicker.Size = new System.Drawing.Size(176, 51);
            this.transactionDateTimePicker.TabIndex = 84;
            this.transactionDateTimePicker.Value = new System.DateTime(2023, 7, 29, 14, 48, 53, 430);
            // 
            // transactionCategoryContextMenu
            // 
            this.transactionCategoryContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionCategoryContextMenu.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12.75F, System.Drawing.FontStyle.Bold);
            this.transactionCategoryContextMenu.Name = "transactionCategoryContextMenu";
            this.transactionCategoryContextMenu.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.transactionCategoryContextMenu.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.transactionCategoryContextMenu.RenderStyle.ColorTable = null;
            this.transactionCategoryContextMenu.RenderStyle.RoundedEdges = true;
            this.transactionCategoryContextMenu.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.transactionCategoryContextMenu.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.transactionCategoryContextMenu.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.transactionCategoryContextMenu.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.transactionCategoryContextMenu.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.transactionCategoryContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // transactionCategoryButton
            // 
            this.transactionCategoryButton.BackColor = System.Drawing.Color.Transparent;
            this.transactionCategoryButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionCategoryButton.BorderRadius = 20;
            this.transactionCategoryButton.BorderThickness = 1;
            this.transactionCategoryButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.transactionCategoryButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.transactionCategoryButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.transactionCategoryButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.transactionCategoryButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionCategoryButton.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F, System.Drawing.FontStyle.Bold);
            this.transactionCategoryButton.ForeColor = System.Drawing.Color.Black;
            this.transactionCategoryButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.transactionCategoryButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.transactionCategoryButton.HoverState.ForeColor = System.Drawing.Color.Black;
            this.transactionCategoryButton.Location = new System.Drawing.Point(47, 301);
            this.transactionCategoryButton.Name = "transactionCategoryButton";
            this.transactionCategoryButton.ShadowDecoration.BorderRadius = 20;
            this.transactionCategoryButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.transactionCategoryButton.Size = new System.Drawing.Size(488, 51);
            this.transactionCategoryButton.TabIndex = 86;
            this.transactionCategoryButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.transactionCategoryButton.Click += new System.EventHandler(this.transactionCategoryButton_Click);
            // 
            // AddTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.transactionCategoryButton);
            this.Controls.Add(this.transactionDateTimePicker);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.currencyLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.transactionTypeComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.accountComboBox);
            this.Controls.Add(this.transactionAmountTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTransactionForm";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button backButton;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox transactionAmountTextBox;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox accountComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox transactionTypeComboBox;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button addButton;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2DateTimePicker transactionDateTimePicker;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip transactionCategoryContextMenu;
        private Guna.UI2.WinForms.Guna2Button transactionCategoryButton;
    }
}