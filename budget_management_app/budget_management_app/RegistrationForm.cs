using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class RegistrationForm : Form
    {
        DBConnection db=new DBConnection();
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            
        }

        // Adding data to database. Referral to the MainMenuForm
        private void Button_sign_up_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_username.Text == "" || textBox_email.Text == "" || textBox_passw.Text == "" || textBox_passw2.Text == "")
                {
                    MessageBox.Show("Please Complete the blank fields", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Check that the passwords are the same
                else if (textBox_passw.Text != textBox_passw2.Text)
                {
                    MessageBox.Show("The entered password doesn't match, Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_passw.Clear();
                    textBox_passw2.Clear();
                }
                else 
                {
                    string insertQuery = "INSERT INTO [User] (UserName, UserEmail, UserPasswd) VALUES ('" + textBox_username.Text + "', '" + textBox_email.Text + "', '" + textBox_passw.Text + "')";

                    // Checking the existence of such a user name in the data base
                    string checkQuery_username = "SELECT COUNT(*) FROM [User] WHERE UserName='"+textBox_username.Text+"'";
                    db.OpenCon();
                    SqlCommand checkCommand_username = new SqlCommand(checkQuery_username, db.GetCon());
                    int count = (int)checkCommand_username.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The entered UserName is already taken. Please choose a different UserName.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Checking the existence of such email in the data base
                    string checkQuery_email = "SELECT COUNT(*) FROM [User] WHERE UserEmail='" + textBox_email.Text + "'";
                    db.OpenCon();
                    SqlCommand checkCommand_email = new SqlCommand(checkQuery_email, db.GetCon());
                    int count_email = (int)checkCommand_email.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The entered Email is already taken. Please choose a different email.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Adding a new user to the database date
                    SqlCommand insertCommand = new SqlCommand(insertQuery, db.GetCon());
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("New user added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.CloseCon();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
