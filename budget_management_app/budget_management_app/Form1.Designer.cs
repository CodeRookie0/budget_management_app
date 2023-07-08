namespace budget_management_app
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_Sidebar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_home = new System.Windows.Forms.Button();
            this.button1_logout = new System.Windows.Forms.Button();
            this.label_user_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_trns = new System.Windows.Forms.Button();
            this.button_stat = new System.Windows.Forms.Button();
            this.button_cat = new System.Windows.Forms.Button();
            this.button_lim = new System.Windows.Forms.Button();
            this.button_acc = new System.Windows.Forms.Button();
            this.panel_Sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Sidebar
            // 
            this.panel_Sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel_Sidebar.Controls.Add(this.button_acc);
            this.panel_Sidebar.Controls.Add(this.button_lim);
            this.panel_Sidebar.Controls.Add(this.button_cat);
            this.panel_Sidebar.Controls.Add(this.button_stat);
            this.panel_Sidebar.Controls.Add(this.button_trns);
            this.panel_Sidebar.Controls.Add(this.panel1);
            this.panel_Sidebar.Controls.Add(this.button_home);
            this.panel_Sidebar.Controls.Add(this.button1_logout);
            this.panel_Sidebar.Location = new System.Drawing.Point(185, 12);
            this.panel_Sidebar.Name = "panel_Sidebar";
            this.panel_Sidebar.Size = new System.Drawing.Size(218, 750);
            this.panel_Sidebar.TabIndex = 68;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(177)))), ((int)(((byte)(138)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_user_Name);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 98);
            this.panel1.TabIndex = 75;
            // 
            // button_home
            // 
            this.button_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.button_home.FlatAppearance.BorderSize = 0;
            this.button_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_home.Font = new System.Drawing.Font("Cambria", 16.25F, System.Drawing.FontStyle.Bold);
            this.button_home.ForeColor = System.Drawing.Color.White;
            this.button_home.Image = ((System.Drawing.Image)(resources.GetObject("button_home.Image")));
            this.button_home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_home.Location = new System.Drawing.Point(3, 104);
            this.button_home.Name = "button_home";
            this.button_home.Size = new System.Drawing.Size(213, 36);
            this.button_home.TabIndex = 74;
            this.button_home.Text = "           HOME";
            this.button_home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_home.UseVisualStyleBackColor = false;
            // 
            // button1_logout
            // 
            this.button1_logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.button1_logout.FlatAppearance.BorderSize = 0;
            this.button1_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1_logout.Font = new System.Drawing.Font("Cambria", 19.75F, System.Drawing.FontStyle.Bold);
            this.button1_logout.ForeColor = System.Drawing.Color.White;
            this.button1_logout.Location = new System.Drawing.Point(0, 711);
            this.button1_logout.Name = "button1_logout";
            this.button1_logout.Size = new System.Drawing.Size(218, 36);
            this.button1_logout.TabIndex = 69;
            this.button1_logout.Text = "LOGOUT";
            this.button1_logout.UseVisualStyleBackColor = false;
            // 
            // label_user_Name
            // 
            this.label_user_Name.AutoSize = true;
            this.label_user_Name.Font = new System.Drawing.Font("Segoe UI", 14.75F, System.Drawing.FontStyle.Bold);
            this.label_user_Name.Location = new System.Drawing.Point(3, 5);
            this.label_user_Name.Name = "label_user_Name";
            this.label_user_Name.Size = new System.Drawing.Size(101, 28);
            this.label_user_Name.TabIndex = 0;
            this.label_user_Name.Text = "Maria_SH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Balance : ";
            // 
            // button_trns
            // 
            this.button_trns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.button_trns.FlatAppearance.BorderSize = 0;
            this.button_trns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_trns.Font = new System.Drawing.Font("Cambria", 16.25F, System.Drawing.FontStyle.Bold);
            this.button_trns.ForeColor = System.Drawing.Color.White;
            this.button_trns.Image = ((System.Drawing.Image)(resources.GetObject("button_trns.Image")));
            this.button_trns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_trns.Location = new System.Drawing.Point(0, 243);
            this.button_trns.Name = "button_trns";
            this.button_trns.Size = new System.Drawing.Size(216, 36);
            this.button_trns.TabIndex = 76;
            this.button_trns.Text = "             Transactions";
            this.button_trns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_trns.UseVisualStyleBackColor = false;
            // 
            // button_stat
            // 
            this.button_stat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.button_stat.FlatAppearance.BorderSize = 0;
            this.button_stat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_stat.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.button_stat.ForeColor = System.Drawing.Color.White;
            this.button_stat.Image = ((System.Drawing.Image)(resources.GetObject("button_stat.Image")));
            this.button_stat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_stat.Location = new System.Drawing.Point(0, 399);
            this.button_stat.Name = "button_stat";
            this.button_stat.Size = new System.Drawing.Size(216, 36);
            this.button_stat.TabIndex = 77;
            this.button_stat.Text = "           Statistics";
            this.button_stat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_stat.UseVisualStyleBackColor = false;
            // 
            // button_cat
            // 
            this.button_cat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.button_cat.FlatAppearance.BorderSize = 0;
            this.button_cat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cat.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.button_cat.ForeColor = System.Drawing.Color.White;
            this.button_cat.Image = ((System.Drawing.Image)(resources.GetObject("button_cat.Image")));
            this.button_cat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cat.Location = new System.Drawing.Point(0, 292);
            this.button_cat.Name = "button_cat";
            this.button_cat.Size = new System.Drawing.Size(216, 45);
            this.button_cat.TabIndex = 78;
            this.button_cat.Text = "           Categories";
            this.button_cat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cat.UseVisualStyleBackColor = false;
            // 
            // button_lim
            // 
            this.button_lim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.button_lim.FlatAppearance.BorderSize = 0;
            this.button_lim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_lim.Font = new System.Drawing.Font("Cambria", 18.25F, System.Drawing.FontStyle.Bold);
            this.button_lim.ForeColor = System.Drawing.Color.White;
            this.button_lim.Image = ((System.Drawing.Image)(resources.GetObject("button_lim.Image")));
            this.button_lim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_lim.Location = new System.Drawing.Point(0, 350);
            this.button_lim.Name = "button_lim";
            this.button_lim.Size = new System.Drawing.Size(216, 36);
            this.button_lim.TabIndex = 79;
            this.button_lim.Text = "           Limits";
            this.button_lim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_lim.UseVisualStyleBackColor = false;
            // 
            // button_acc
            // 
            this.button_acc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.button_acc.FlatAppearance.BorderSize = 0;
            this.button_acc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_acc.Font = new System.Drawing.Font("Cambria", 16.25F, System.Drawing.FontStyle.Bold);
            this.button_acc.ForeColor = System.Drawing.Color.White;
            this.button_acc.Image = ((System.Drawing.Image)(resources.GetObject("button_acc.Image")));
            this.button_acc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_acc.Location = new System.Drawing.Point(0, 194);
            this.button_acc.Name = "button_acc";
            this.button_acc.Size = new System.Drawing.Size(216, 36);
            this.button_acc.TabIndex = 80;
            this.button_acc.Text = "             Accounts";
            this.button_acc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_acc.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 811);
            this.Controls.Add(this.panel_Sidebar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_Sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Sidebar;
        private System.Windows.Forms.Button button1_logout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_home;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_user_Name;
        private System.Windows.Forms.Button button_lim;
        private System.Windows.Forms.Button button_cat;
        private System.Windows.Forms.Button button_stat;
        private System.Windows.Forms.Button button_trns;
        private System.Windows.Forms.Button button_acc;
    }
}