namespace budget_management_app
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
            this.Button_log_in = new Guna.UI2.WinForms.Guna2TileButton();
            this.textBox_passw = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_passw = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_sign_up = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_exit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_log_in
            // 
            this.Button_log_in.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.Button_log_in.BorderThickness = 1;
            this.Button_log_in.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_log_in.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_log_in.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_log_in.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_log_in.FillColor = System.Drawing.Color.Transparent;
            this.Button_log_in.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button_log_in.ForeColor = System.Drawing.Color.Black;
            this.Button_log_in.Location = new System.Drawing.Point(217, 455);
            this.Button_log_in.Name = "Button_log_in";
            this.Button_log_in.Size = new System.Drawing.Size(146, 36);
            this.Button_log_in.TabIndex = 25;
            this.Button_log_in.Text = "LOG IN";
            this.Button_log_in.Click += new System.EventHandler(this.Button_log_in_Click);
            this.Button_log_in.MouseEnter += new System.EventHandler(this.Button_log_in_MouseEnter);
            this.Button_log_in.MouseLeave += new System.EventHandler(this.Button_log_in_MouseLeave);
            // 
            // textBox_passw
            // 
            this.textBox_passw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_passw.Location = new System.Drawing.Point(287, 394);
            this.textBox_passw.Name = "textBox_passw";
            this.textBox_passw.Size = new System.Drawing.Size(211, 25);
            this.textBox_passw.TabIndex = 23;
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.textBox_email.Location = new System.Drawing.Point(287, 347);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(211, 25);
            this.textBox_email.TabIndex = 22;
            // 
            // label_passw
            // 
            this.label_passw.AutoSize = true;
            this.label_passw.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_passw.Location = new System.Drawing.Point(82, 397);
            this.label_passw.Name = "label_passw";
            this.label_passw.Size = new System.Drawing.Size(97, 22);
            this.label_passw.TabIndex = 19;
            this.label_passw.Text = "Password";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label_email.Location = new System.Drawing.Point(82, 350);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(66, 22);
            this.label_email.TabIndex = 18;
            this.label_email.Text = "E-mail";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(126, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 89);
            this.label1.TabIndex = 15;
            this.label1.Text = "Log in to your account";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_sign_up
            // 
            this.label_sign_up.AutoSize = true;
            this.label_sign_up.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_sign_up.Location = new System.Drawing.Point(168, 534);
            this.label_sign_up.Name = "label_sign_up";
            this.label_sign_up.Size = new System.Drawing.Size(245, 20);
            this.label_sign_up.TabIndex = 27;
            this.label_sign_up.Text = "Already have an account?  LOG IN";
            this.label_sign_up.Click += new System.EventHandler(this.label_sign_up_Click);
            this.label_sign_up.MouseEnter += new System.EventHandler(this.label_sign_up_MouseEnter);
            this.label_sign_up.MouseLeave += new System.EventHandler(this.label_sign_up_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label_exit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 199);
            this.panel1.TabIndex = 28;
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
            this.label_exit.Click += new System.EventHandler(this.label_exit_Click_1);
            this.label_exit.MouseEnter += new System.EventHandler(this.label_exit_MouseEnter_1);
            this.label_exit.MouseLeave += new System.EventHandler(this.label_exit_MouseLeave_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            this.panel2.Location = new System.Drawing.Point(0, 595);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 157);
            this.panel2.TabIndex = 29;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 750);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_sign_up);
            this.Controls.Add(this.Button_log_in);
            this.Controls.Add(this.textBox_passw);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.label_passw);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TileButton Button_log_in;
        private System.Windows.Forms.TextBox textBox_passw;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_passw;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_sign_up;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.Panel panel2;
    }
}