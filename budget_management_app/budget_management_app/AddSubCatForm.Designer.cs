namespace budget_management_app
{
    partial class AddSubCatForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.label_category = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboBox_type = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_add = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel2.Controls.Add(this.label_exit);
            this.panel2.Controls.Add(this.label_category);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 55);
            this.panel2.TabIndex = 4;
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
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_category.ForeColor = System.Drawing.Color.White;
            this.label_category.Location = new System.Drawing.Point(12, 13);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(219, 29);
            this.label_category.TabIndex = 36;
            this.label_category.Text = "New Subcategory";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel1.Location = new System.Drawing.Point(0, 699);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 55);
            this.panel1.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.label8.Location = new System.Drawing.Point(29, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(541, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "_________________________________________________________________________________" +
    "________";
            // 
            // ComboBox_type
            // 
            this.ComboBox_type.BackColor = System.Drawing.Color.Transparent;
            this.ComboBox_type.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.ComboBox_type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_type.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBox_type.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBox_type.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.ComboBox_type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboBox_type.ItemHeight = 30;
            this.ComboBox_type.Items.AddRange(new object[] {
            "Income",
            "Expense",
            "Savings"});
            this.ComboBox_type.Location = new System.Drawing.Point(17, 214);
            this.ComboBox_type.Name = "ComboBox_type";
            this.ComboBox_type.Size = new System.Drawing.Size(551, 36);
            this.ComboBox_type.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(10, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 28);
            this.label3.TabIndex = 44;
            this.label3.Text = "Type";
            // 
            // textBox_name
            // 
            this.textBox_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_name.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.textBox_name.Location = new System.Drawing.Point(32, 107);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(529, 25);
            this.textBox_name.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(7, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 28);
            this.label1.TabIndex = 42;
            this.label1.Text = "Name";
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
            this.Button_add.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button_add.ForeColor = System.Drawing.Color.Black;
            this.Button_add.Location = new System.Drawing.Point(214, 296);
            this.Button_add.Name = "Button_add";
            this.Button_add.Size = new System.Drawing.Size(146, 36);
            this.Button_add.TabIndex = 47;
            this.Button_add.Text = "ADD";
            this.Button_add.Click += new System.EventHandler(this.Button_add_Click);
            this.Button_add.MouseEnter += new System.EventHandler(this.Button_add_MouseEnter);
            this.Button_add.MouseLeave += new System.EventHandler(this.Button_add_MouseLeave);
            // 
            // AddSubCatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.Button_add);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ComboBox_type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSubCatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSubCatForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBox_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TileButton Button_add;
    }
}