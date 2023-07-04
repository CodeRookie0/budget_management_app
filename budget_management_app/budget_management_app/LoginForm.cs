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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
            label_exit.ForeColor = Color.Chocolate;
        }



        // Referral to the MainMenuForm
        private void Button_log_in_Click(object sender, EventArgs e)
        {
            
        }
        // Design of Button_log_in
        private void Button_log_in_MouseEnter(object sender, EventArgs e)
        {
            Button_log_in.BackColor = Color.SandyBrown;
        }

        private void Button_log_in_MouseLeave(object sender, EventArgs e)
        {
            Button_log_in.BackColor = Color.MediumSpringGreen;
        }



        // Referral to the RegistrationForm
        private void linkLabel_sign_up_Click(object sender, EventArgs e)
        {
            RegistrationForm sign = new RegistrationForm();
            sign.Show();
            this.Hide();
        }
        // Design of linkLabel_sign_up
        private void linkLabel_sign_up_MouseEnter(object sender, EventArgs e)
        {
            linkLabel_sign_up.ForeColor = Color.Red;
        }

        private void linkLabel_sign_up_MouseLeave(object sender, EventArgs e)
        {
            linkLabel_sign_up.ForeColor = Color.Black;
        }

    }
}
