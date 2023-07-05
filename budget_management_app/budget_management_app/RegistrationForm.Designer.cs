namespace budget_management_app
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_passw = new System.Windows.Forms.Label();
            this.label_passw2 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_passw = new System.Windows.Forms.TextBox();
            this.textBox_passw2 = new System.Windows.Forms.TextBox();
            this.Button_sign_up = new Guna.UI2.WinForms.Guna2TileButton();
            this.label_log_in = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label_exit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 199);
            this.panel1.TabIndex = 0;
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI Black", 19.25F, System.Drawing.FontStyle.Bold);
            this.label_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(148)))), ((int)(((byte)(85)))));
            this.label_exit.Location = new System.Drawing.Point(547, 0);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(33, 36);
            this.label_exit.TabIndex = 1;
            this.label_exit.Text = "X";
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click);
            this.label_exit.MouseEnter += new System.EventHandler(this.label_exit_MouseEnter);
            this.label_exit.MouseLeave += new System.EventHandler(this.label_exit_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel2.Location = new System.Drawing.Point(0, 664);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 157);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(169, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 89);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sign up to create a secure account";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_username.Location = new System.Drawing.Point(88, 347);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(103, 22);
            this.label_username.TabIndex = 4;
            this.label_username.Text = "UserName";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_email.Location = new System.Drawing.Point(88, 394);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(66, 22);
            this.label_email.TabIndex = 5;
            this.label_email.Text = "E-mail";
            // 
            // label_passw
            // 
            this.label_passw.AutoSize = true;
            this.label_passw.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_passw.Location = new System.Drawing.Point(88, 441);
            this.label_passw.Name = "label_passw";
            this.label_passw.Size = new System.Drawing.Size(97, 22);
            this.label_passw.TabIndex = 6;
            this.label_passw.Text = "Password";
            // 
            // label_passw2
            // 
            this.label_passw2.AutoSize = true;
            this.label_passw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_passw2.Location = new System.Drawing.Point(88, 488);
            this.label_passw2.Name = "label_passw2";
            this.label_passw2.Size = new System.Drawing.Size(167, 22);
            this.label_passw2.TabIndex = 7;
            this.label_passw2.Text = "Repeat Password";
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_username.Location = new System.Drawing.Point(293, 344);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(211, 25);
            this.textBox_username.TabIndex = 9;
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_email.Location = new System.Drawing.Point(293, 391);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(211, 25);
            this.textBox_email.TabIndex = 10;
            // 
            // textBox_passw
            // 
            this.textBox_passw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_passw.Location = new System.Drawing.Point(293, 438);
            this.textBox_passw.Name = "textBox_passw";
            this.textBox_passw.Size = new System.Drawing.Size(211, 25);
            this.textBox_passw.TabIndex = 11;
            // 
            // textBox_passw2
            // 
            this.textBox_passw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_passw2.Location = new System.Drawing.Point(293, 485);
            this.textBox_passw2.Name = "textBox_passw2";
            this.textBox_passw2.Size = new System.Drawing.Size(211, 25);
            this.textBox_passw2.TabIndex = 12;
            // 
            // Button_sign_up
            // 
            this.Button_sign_up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_sign_up.BorderThickness = 1;
            this.Button_sign_up.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_sign_up.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_sign_up.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_sign_up.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_sign_up.FillColor = System.Drawing.Color.Transparent;
            this.Button_sign_up.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button_sign_up.ForeColor = System.Drawing.Color.Black;
            this.Button_sign_up.Location = new System.Drawing.Point(217, 545);
            this.Button_sign_up.Name = "Button_sign_up";
            this.Button_sign_up.Size = new System.Drawing.Size(146, 36);
            this.Button_sign_up.TabIndex = 13;
            this.Button_sign_up.Text = "SIGN UP";
            this.Button_sign_up.Click += new System.EventHandler(this.Button_sign_up_Click);
            this.Button_sign_up.MouseEnter += new System.EventHandler(this.Button_sign_up_MouseEnter);
            this.Button_sign_up.MouseLeave += new System.EventHandler(this.Button_sign_up_MouseLeave);
            // 
            // label_log_in
            // 
            this.label_log_in.AutoSize = true;
            this.label_log_in.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_log_in.Location = new System.Drawing.Point(166, 617);
            this.label_log_in.Name = "label_log_in";
            this.label_log_in.Size = new System.Drawing.Size(245, 20);
            this.label_log_in.TabIndex = 14;
            this.label_log_in.Text = "Already have an account?  LOG IN";
            this.label_log_in.Click += new System.EventHandler(this.label_log_in_Click);
            this.label_log_in.MouseEnter += new System.EventHandler(this.label_log_in_MouseEnter);
            this.label_log_in.MouseLeave += new System.EventHandler(this.label_log_in_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(226, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 131);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.label_log_in);
            this.Controls.Add(this.Button_sign_up);
            this.Controls.Add(this.textBox_passw2);
            this.Controls.Add(this.textBox_passw);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label_passw2);
            this.Controls.Add(this.label_passw);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_passw;
        private System.Windows.Forms.Label label_passw2;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_passw;
        private System.Windows.Forms.TextBox textBox_passw2;
        private Guna.UI2.WinForms.Guna2TileButton Button_sign_up;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Label label_log_in;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}