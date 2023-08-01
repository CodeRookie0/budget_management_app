namespace budget_management_app
{
    partial class PasswordPromptForm
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
            this.textBox_passwd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Button_ok = new Guna.UI2.WinForms.Guna2TileButton();
            this.label_exit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_passwd
            // 
            this.textBox_passwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_passwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_passwd.Location = new System.Drawing.Point(39, 100);
            this.textBox_passwd.Name = "textBox_passwd";
            this.textBox_passwd.Size = new System.Drawing.Size(348, 29);
            this.textBox_passwd.TabIndex = 66;
            this.textBox_passwd.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(119, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 28);
            this.label9.TabIndex = 71;
            this.label9.Text = "Enter your Password";
            // 
            // Button_ok
            // 
            this.Button_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_ok.BorderThickness = 1;
            this.Button_ok.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_ok.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_ok.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_ok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_ok.FillColor = System.Drawing.Color.Transparent;
            this.Button_ok.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.Button_ok.ForeColor = System.Drawing.Color.Black;
            this.Button_ok.Location = new System.Drawing.Point(150, 150);
            this.Button_ok.Name = "Button_ok";
            this.Button_ok.Size = new System.Drawing.Size(119, 25);
            this.Button_ok.TabIndex = 72;
            this.Button_ok.Text = "OK";
            this.Button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            this.Button_ok.MouseEnter += new System.EventHandler(this.Button_ok_MouseEnter);
            this.Button_ok.MouseLeave += new System.EventHandler(this.Button_ok_MouseLeave);
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.BackColor = System.Drawing.Color.White;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI Black", 19.25F, System.Drawing.FontStyle.Bold);
            this.label_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            this.label_exit.Location = new System.Drawing.Point(395, -1);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(33, 36);
            this.label_exit.TabIndex = 73;
            this.label_exit.Text = "X";
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click);
            this.label_exit.MouseEnter += new System.EventHandler(this.label_exit_MouseEnter);
            this.label_exit.MouseLeave += new System.EventHandler(this.label_exit_MouseLeave);
            // 
            // PasswdPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(427, 228);
            this.Controls.Add(this.label_exit);
            this.Controls.Add(this.Button_ok);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_passwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswdPromptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PasswdPromptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_passwd;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TileButton Button_ok;
        private System.Windows.Forms.Label label_exit;
    }
}