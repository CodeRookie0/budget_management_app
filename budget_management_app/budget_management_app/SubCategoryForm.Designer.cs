namespace budget_management_app
{
    partial class SubCategoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_category = new System.Windows.Forms.Label();
            this.label_exit = new System.Windows.Forms.Label();
            this.DataGridView_selectedCat = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DataGridView_subcat = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Button_add = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_selectedCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_subcat)).BeginInit();
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
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel1.Location = new System.Drawing.Point(0, 709);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 55);
            this.panel1.TabIndex = 4;
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_category.ForeColor = System.Drawing.Color.White;
            this.label_category.Location = new System.Drawing.Point(12, 13);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(118, 29);
            this.label_category.TabIndex = 36;
            this.label_category.Text = "Category";
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
            // DataGridView_selectedCat
            // 
            this.DataGridView_selectedCat.AllowUserToAddRows = false;
            this.DataGridView_selectedCat.AllowUserToDeleteRows = false;
            this.DataGridView_selectedCat.AllowUserToResizeColumns = false;
            this.DataGridView_selectedCat.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.DataGridView_selectedCat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.DataGridView_selectedCat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_selectedCat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DataGridView_selectedCat.ColumnHeadersHeight = 4;
            this.DataGridView_selectedCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_selectedCat.ColumnHeadersVisible = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Sitka Display", 20F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_selectedCat.DefaultCellStyle = dataGridViewCellStyle21;
            this.DataGridView_selectedCat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.DataGridView_selectedCat.Location = new System.Drawing.Point(0, 107);
            this.DataGridView_selectedCat.Name = "DataGridView_selectedCat";
            this.DataGridView_selectedCat.ReadOnly = true;
            this.DataGridView_selectedCat.RowHeadersVisible = false;
            this.DataGridView_selectedCat.Size = new System.Drawing.Size(580, 53);
            this.DataGridView_selectedCat.TabIndex = 5;
            this.DataGridView_selectedCat.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_selectedCat.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_selectedCat.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_selectedCat.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_selectedCat.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_selectedCat.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_selectedCat.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.DataGridView_selectedCat.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_selectedCat.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_selectedCat.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataGridView_selectedCat.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_selectedCat.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_selectedCat.ThemeStyle.HeaderStyle.Height = 4;
            this.DataGridView_selectedCat.ThemeStyle.ReadOnly = true;
            this.DataGridView_selectedCat.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_selectedCat.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_selectedCat.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataGridView_selectedCat.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_selectedCat.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridView_selectedCat.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_selectedCat.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.label1.Location = new System.Drawing.Point(0, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "GENERAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.label3.Location = new System.Drawing.Point(3, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "SUBCATEGORIES";
            // 
            // DataGridView_subcat
            // 
            this.DataGridView_subcat.AllowUserToAddRows = false;
            this.DataGridView_subcat.AllowUserToDeleteRows = false;
            this.DataGridView_subcat.AllowUserToResizeColumns = false;
            this.DataGridView_subcat.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.DataGridView_subcat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.DataGridView_subcat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_subcat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.DataGridView_subcat.ColumnHeadersHeight = 4;
            this.DataGridView_subcat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_subcat.ColumnHeadersVisible = false;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Sitka Display", 20F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_subcat.DefaultCellStyle = dataGridViewCellStyle24;
            this.DataGridView_subcat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.DataGridView_subcat.Location = new System.Drawing.Point(0, 215);
            this.DataGridView_subcat.Name = "DataGridView_subcat";
            this.DataGridView_subcat.ReadOnly = true;
            this.DataGridView_subcat.RowHeadersVisible = false;
            this.DataGridView_subcat.Size = new System.Drawing.Size(580, 444);
            this.DataGridView_subcat.TabIndex = 7;
            this.DataGridView_subcat.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_subcat.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridView_subcat.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridView_subcat.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridView_subcat.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridView_subcat.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_subcat.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.DataGridView_subcat.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridView_subcat.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_subcat.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataGridView_subcat.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_subcat.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_subcat.ThemeStyle.HeaderStyle.Height = 4;
            this.DataGridView_subcat.ThemeStyle.ReadOnly = true;
            this.DataGridView_subcat.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_subcat.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_subcat.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DataGridView_subcat.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_subcat.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridView_subcat.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_subcat.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            this.Button_add.Location = new System.Drawing.Point(217, 667);
            this.Button_add.Name = "Button_add";
            this.Button_add.Size = new System.Drawing.Size(146, 36);
            this.Button_add.TabIndex = 26;
            this.Button_add.Text = "ADD";
            this.Button_add.Click += new System.EventHandler(this.Button_add_Click);
            this.Button_add.MouseEnter += new System.EventHandler(this.Button_add_MouseEnter);
            this.Button_add.MouseLeave += new System.EventHandler(this.Button_add_MouseLeave);
            // 
            // SubCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.Button_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DataGridView_subcat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridView_selectedCat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubCategoryForm";
            this.Text = "SubCategoryForm";
            this.Load += new System.EventHandler(this.SubCategoryForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_selectedCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_subcat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.Label label_exit;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_selectedCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_subcat;
        private Guna.UI2.WinForms.Guna2TileButton Button_add;
    }
}