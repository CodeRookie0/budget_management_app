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
using TheArtOfDevHtmlRenderer.Adapters.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace budget_management_app
{
    public partial class LoginForm : Form
    {
        DBConnection dbconn=new DBConnection();
        public LoginForm()
        {
            InitializeComponent();
        }


        // Referral to the MainMenuForm
        private void Button_log_in_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_email.Text == "" || textBox_passw.Text == "")
                {
                    MessageBox.Show("Please Complete the blank fields", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string selectQuery = "SELECT * FROM [User] WHERE UserEmail='" + textBox_email.Text + "'AND UserPasswd ='" + textBox_passw.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, dbconn.GetCon());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        StartPageForm start = new StartPageForm();
                        start.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Email or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_passw.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Design of Button_log_in
        private void Button_log_in_MouseEnter(object sender, EventArgs e)
        {
            Button_log_in.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_log_in_MouseLeave(object sender, EventArgs e)
        {
            Button_log_in.BackColor = Color.FromArgb(250, 237, 205);
        }



        // Referral to the RegistrationForm
        private void label_sign_up_Click(object sender, EventArgs e)
        {
            RegistrationForm sign = new RegistrationForm();
            sign.Show();
            this.Hide();
        }
        // Design of label_sign_up
        private void label_sign_up_MouseEnter(object sender, EventArgs e)
        {
            label_sign_up.ForeColor = Color.FromArgb(212, 163, 115);
        }

        private void label_sign_up_MouseLeave(object sender, EventArgs e)
        {
            label_sign_up.ForeColor = Color.Black;
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
    }
}
