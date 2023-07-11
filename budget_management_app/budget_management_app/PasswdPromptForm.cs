using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class PasswdPromptForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public PasswdPromptForm()
        {
            InitializeComponent();
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            if (IsPasswordValid())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_ok_MouseEnter(object sender, EventArgs e)
        {
            Button_ok.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_ok_MouseLeave(object sender, EventArgs e)
        {
            Button_ok.BackColor = Color.FromArgb(250, 237, 205);
        }

        private bool IsPasswordValid()
        {
            string selectQuery = "SELECT UserPasswd FROM Users WHERE UserId = "+LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            string password = command.ExecuteScalar()?.ToString();
            dbcon.CloseCon();
            return textBox_passwd.Text == password;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.BackColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.BackColor = Color.Black;
        }
    }
}
