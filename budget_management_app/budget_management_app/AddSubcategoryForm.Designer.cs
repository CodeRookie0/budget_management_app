namespace budget_management_app
{
    partial class AddSubcategoryForm
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
            this.subcategoryTypeComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.selectedCategoryLabel = new System.Windows.Forms.Label();
            this.subcategoryNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.addButton = new Guna.UI2.WinForms.Guna2Button();
            this.backButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // subcategoryTypeComboBox
            // 
            this.subcategoryTypeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.subcategoryTypeComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.subcategoryTypeComboBox.BorderRadius = 20;
            this.subcategoryTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.subcategoryTypeComboBox.DropDownHeight = 250;
            this.subcategoryTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subcategoryTypeComboBox.DropDownWidth = 480;
            this.subcategoryTypeComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.subcategoryTypeComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subcategoryTypeComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subcategoryTypeComboBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F);
            this.subcategoryTypeComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.subcategoryTypeComboBox.IntegralHeight = false;
            this.subcategoryTypeComboBox.ItemHeight = 45;
            this.subcategoryTypeComboBox.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.subcategoryTypeComboBox.ItemsAppearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F);
            this.subcategoryTypeComboBox.ItemsAppearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.subcategoryTypeComboBox.Location = new System.Drawing.Point(47, 426);
            this.subcategoryTypeComboBox.Name = "subcategoryTypeComboBox";
            this.subcategoryTypeComboBox.ShadowDecoration.BorderRadius = 20;
            this.subcategoryTypeComboBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.subcategoryTypeComboBox.Size = new System.Drawing.Size(486, 51);
            this.subcategoryTypeComboBox.TabIndex = 81;
            this.subcategoryTypeComboBox.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(43, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 22);
            this.label9.TabIndex = 80;
            this.label9.Text = "Type";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 40;
            this.guna2Panel2.Controls.Add(this.backButton);
            this.guna2Panel2.Controls.Add(this.selectedCategoryLabel);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, -71);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 45;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(7);
            this.guna2Panel2.Size = new System.Drawing.Size(580, 147);
            this.guna2Panel2.TabIndex = 88;
            // 
            // selectedCategoryLabel
            // 
            this.selectedCategoryLabel.AutoSize = true;
            this.selectedCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectedCategoryLabel.ForeColor = System.Drawing.Color.White;
            this.selectedCategoryLabel.Location = new System.Drawing.Point(183, 93);
            this.selectedCategoryLabel.Name = "selectedCategoryLabel";
            this.selectedCategoryLabel.Size = new System.Drawing.Size(215, 29);
            this.selectedCategoryLabel.TabIndex = 36;
            this.selectedCategoryLabel.Text = "New subcategory";
            // 
            // subcategoryNameTextBox
            // 
            this.subcategoryNameTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.subcategoryNameTextBox.BorderRadius = 20;
            this.subcategoryNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.subcategoryNameTextBox.DefaultText = "";
            this.subcategoryNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.subcategoryNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.subcategoryNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.subcategoryNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.subcategoryNameTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.subcategoryNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subcategoryNameTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F);
            this.subcategoryNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.subcategoryNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subcategoryNameTextBox.Location = new System.Drawing.Point(47, 299);
            this.subcategoryNameTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.subcategoryNameTextBox.Name = "subcategoryNameTextBox";
            this.subcategoryNameTextBox.PasswordChar = '\0';
            this.subcategoryNameTextBox.PlaceholderText = "";
            this.subcategoryNameTextBox.SelectedText = "";
            this.subcategoryNameTextBox.Size = new System.Drawing.Size(486, 51);
            this.subcategoryNameTextBox.TabIndex = 89;
            this.subcategoryNameTextBox.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(43, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 22);
            this.label2.TabIndex = 90;
            this.label2.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 12.75F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(43, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 92;
            this.label4.Text = "Category";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.categoryTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.categoryTextBox.BorderRadius = 20;
            this.categoryTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.categoryTextBox.DefaultText = "";
            this.categoryTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.categoryTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.categoryTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.categoryTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.categoryTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.categoryTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.categoryTextBox.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.categoryTextBox.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 14.75F);
            this.categoryTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.categoryTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.categoryTextBox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.categoryTextBox.Location = new System.Drawing.Point(47, 172);
            this.categoryTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.PasswordChar = '\0';
            this.categoryTextBox.PlaceholderText = "";
            this.categoryTextBox.ReadOnly = true;
            this.categoryTextBox.SelectedText = "";
            this.categoryTextBox.Size = new System.Drawing.Size(486, 51);
            this.categoryTextBox.TabIndex = 91;
            this.categoryTextBox.TextOffset = new System.Drawing.Point(10, 0);
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
            this.addButton.Location = new System.Drawing.Point(228, 550);
            this.addButton.Name = "addButton";
            this.addButton.ShadowDecoration.BorderRadius = 20;
            this.addButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(31)))), ((int)(((byte)(52)))));
            this.addButton.Size = new System.Drawing.Size(124, 51);
            this.addButton.TabIndex = 93;
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
            this.backButton.Image = global::budget_management_app.Properties.Resources.back_white;
            this.backButton.ImageSize = new System.Drawing.Size(50, 50);
            this.backButton.Location = new System.Drawing.Point(0, 69);
            this.backButton.Name = "backButton";
            this.backButton.PressedColor = System.Drawing.Color.Transparent;
            this.backButton.PressedDepth = 0;
            this.backButton.Size = new System.Drawing.Size(58, 76);
            this.backButton.TabIndex = 73;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // AddSubcategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subcategoryNameTextBox);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.subcategoryTypeComboBox);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSubcategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSubCatForm";
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox subcategoryTypeComboBox;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button backButton;
        private System.Windows.Forms.Label selectedCategoryLabel;
        private Guna.UI2.WinForms.Guna2TextBox subcategoryNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox categoryTextBox;
        private Guna.UI2.WinForms.Guna2Button addButton;
    }
}