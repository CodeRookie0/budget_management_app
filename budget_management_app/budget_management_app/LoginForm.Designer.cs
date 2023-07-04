﻿namespace budget_management_app
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel_log_in = new System.Windows.Forms.LinkLabel();
            this.label_username = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_passw = new System.Windows.Forms.Label();
            this.label_passw2 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_passw = new System.Windows.Forms.TextBox();
            this.textBox_passw2 = new System.Windows.Forms.TextBox();
            this.Button_sign_up = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 199);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel2.Location = new System.Drawing.Point(0, 640);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 181);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(227, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 135);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(169, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 89);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sign up to create a secure account";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel_log_in
            // 
            this.linkLabel_log_in.AutoSize = true;
            this.linkLabel_log_in.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Bold);
            this.linkLabel_log_in.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.linkLabel_log_in.Location = new System.Drawing.Point(168, 599);
            this.linkLabel_log_in.Name = "linkLabel_log_in";
            this.linkLabel_log_in.Size = new System.Drawing.Size(245, 20);
            this.linkLabel_log_in.TabIndex = 3;
            this.linkLabel_log_in.TabStop = true;
            this.linkLabel_log_in.Text = "Already have an account?  LOG IN";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_username.Location = new System.Drawing.Point(88, 355);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(103, 22);
            this.label_username.TabIndex = 4;
            this.label_username.Text = "UserName";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_email.Location = new System.Drawing.Point(88, 402);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(66, 22);
            this.label_email.TabIndex = 5;
            this.label_email.Text = "E-mail";
            // 
            // label_passw
            // 
            this.label_passw.AutoSize = true;
            this.label_passw.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_passw.Location = new System.Drawing.Point(88, 449);
            this.label_passw.Name = "label_passw";
            this.label_passw.Size = new System.Drawing.Size(97, 22);
            this.label_passw.TabIndex = 6;
            this.label_passw.Text = "Password";
            // 
            // label_passw2
            // 
            this.label_passw2.AutoSize = true;
            this.label_passw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_passw2.Location = new System.Drawing.Point(88, 496);
            this.label_passw2.Name = "label_passw2";
            this.label_passw2.Size = new System.Drawing.Size(167, 22);
            this.label_passw2.TabIndex = 7;
            this.label_passw2.Text = "Repeat Password";
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_username.Location = new System.Drawing.Point(293, 352);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(211, 25);
            this.textBox_username.TabIndex = 9;
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_email.Location = new System.Drawing.Point(293, 399);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(211, 25);
            this.textBox_email.TabIndex = 10;
            // 
            // textBox_passw
            // 
            this.textBox_passw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_passw.Location = new System.Drawing.Point(293, 446);
            this.textBox_passw.Name = "textBox_passw";
            this.textBox_passw.Size = new System.Drawing.Size(211, 25);
            this.textBox_passw.TabIndex = 11;
            // 
            // textBox_passw2
            // 
            this.textBox_passw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_passw2.Location = new System.Drawing.Point(293, 493);
            this.textBox_passw2.Name = "textBox_passw2";
            this.textBox_passw2.Size = new System.Drawing.Size(211, 25);
            this.textBox_passw2.TabIndex = 12;
            // 
            // Button_sign_up
            // 
            this.Button_sign_up.BackColor = System.Drawing.Color.MediumSpringGreen;
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
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.Button_sign_up);
            this.Controls.Add(this.textBox_passw2);
            this.Controls.Add(this.textBox_passw);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label_passw2);
            this.Controls.Add(this.label_passw);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.linkLabel_log_in);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel_log_in;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_passw;
        private System.Windows.Forms.Label label_passw2;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_passw;
        private System.Windows.Forms.TextBox textBox_passw2;
        private Guna.UI2.WinForms.Guna2TileButton Button_sign_up;
    }
}