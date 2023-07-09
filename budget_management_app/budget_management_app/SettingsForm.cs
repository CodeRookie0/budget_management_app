using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace budget_management_app
{
    public partial class SettingsForm : Form
    {
        DBConnection dbcon=new DBConnection();
        string userName;
        string userPasswd;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            getData();
        }
        private void getData()
        {
            string selectQuerry = "SELECT UserName,UserEmail,UserCreatedAt,UserPasswd FROM User WHERE UserId =" + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                userName = row["UserName"].ToString().Trim();
                textBox_email.Text = row["UserEmail"].ToString().Trim();
                textBox_createdAt.Text = row["UserCreatedAt"].ToString().Trim();
                textBox_name.Text=userName;
                userPasswd= row["UserPasswd"].ToString();
            }
        }

        // Change of username
        private void Button_commit_Click(object sender, EventArgs e)
        {
            try
            {
                if (userName == textBox_name.Text.Trim())
                {
                    MessageBox.Show("The new UserName is the same as the current one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Checking the existence of such a user name in the data base
                    string checkQuery_username = "SELECT COUNT(*) FROM [User] WHERE UserName='" + textBox_name.Text + "'";
                    dbcon.OpenCon();
                    SqlCommand checkCommand_username = new SqlCommand(checkQuery_username, dbcon.GetCon());
                    int count = (int)checkCommand_username.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The entered UserName is already taken. Please choose a different UserName.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string updateQuery = "UPDATE [User] SET UserName = '"+textBox_name.Text+"' WHERE UserId ="+LoginForm.userId;
                    SqlCommand command = new SqlCommand(updateQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.ExecuteNonQuery();
                    dbcon.CloseCon();
                    MessageBox.Show("UserName updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Design of button_commit
        private void Button_commit_MouseEnter(object sender, EventArgs e)
        {
            Button_commit.BackColor = Color.FromArgb(224, 233, 194);
        }

        private void Button_commit_MouseLeave(object sender, EventArgs e)
        {
            Button_commit.BackColor = Color.FromArgb(204, 213, 174);
        }


        // Handles clicking the change password button
        private void Button_change_passwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_changePasswd1.Text != textBox_changePasswd2.Text)
                {
                    MessageBox.Show("Passwords must be the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else if (textBox_changePasswd1.Text==userPasswd)
                {
                    MessageBox.Show("The new Password is the same as the current one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string updateQuery = "UPDATE [User] SET UserPasswd = '"+textBox_changePasswd1.Text+"' WHERE UserId ="+LoginForm.userId;
                    SqlCommand command = new SqlCommand(updateQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.ExecuteNonQuery();
                    dbcon.CloseCon();
                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Design of button_change_passwd
        private void Button_change_passwd_MouseEnter(object sender, EventArgs e)
        {
            Button_change_passwd.BackColor = Color.FromArgb(224, 233, 194);
        }

        private void Button_change_passwd_MouseLeave(object sender, EventArgs e)
        {
            Button_change_passwd.BackColor = Color.FromArgb(204, 213, 174);
        }


        // Logout from account
        private void Button_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to leave log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login=new LoginForm();
                login.Show();
                this.Hide();
            }
        }
        // Design of button_logout
        private void Button_logout_MouseEnter(object sender, EventArgs e)
        {
            Button_logout.BackColor = Color.FromArgb(275, 212, 212);
        }

        private void Button_logout_MouseLeave(object sender, EventArgs e)
        {
            Button_logout.BackColor = Color.FromArgb(255, 192, 192);
        }


        // Handles the click event on the delete account label
        private void label_delete_acc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (result == DialogResult.Yes)
                {
                    PasswdPromptForm pwd = new PasswdPromptForm();
                    pwd.Show();
                    DialogResult passwdResult = pwd.ShowDialog();
                    if (passwdResult == DialogResult.OK)
                    {
                        string deleteQuery = "DELETE FROM Users WHERE UserId =" + LoginForm.userId;
                        SqlCommand command = new SqlCommand(deleteQuery, dbcon.GetCon());
                        dbcon.OpenCon();
                        command.ExecuteNonQuery();
                        dbcon.CloseCon();
                        MessageBox.Show("Your account has been successfully deleted.", "Deleting your account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Hide();
                        LoginForm log = new LoginForm();
                        log.Show();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
