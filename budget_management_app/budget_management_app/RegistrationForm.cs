﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }


        // Adding data to database. Referral to the MainMenuForm
        private void Button_sign_up_Click(object sender, EventArgs e)
        {

        }
        // Design of Button_sign_up
        private void Button_sign_up_MouseEnter(object sender, EventArgs e)
        {
            Button_sign_up.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_sign_up_MouseLeave(object sender, EventArgs e)
        {
            Button_sign_up.BackColor = Color.FromArgb(250, 237, 205);
        }



        //Exit from the application
        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Design of label_exit
        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.FromArgb(212, 148, 85);
        }


        
        // Referral to the LoginForm
        private void label_log_in_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        // Design of linkLabel_log_in
        private void label_log_in_MouseEnter(object sender, EventArgs e)
        {
            label_log_in.ForeColor = Color.FromArgb(212, 148, 85);
        }

        private void label_log_in_MouseLeave(object sender, EventArgs e)
        {
            label_log_in.ForeColor = Color.Black;
        }
        
    }
}
