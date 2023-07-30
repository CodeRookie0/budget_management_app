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
    public partial class SignUpForm : Form
    {
        // Create an instance of the DBConnection class to manage database connections
        DBConnection dbConnection =new DBConnection();

        // Constructor for the SignUpForm class
        public SignUpForm()
        {
            InitializeComponent();
        }

        // Event handler for the "Sign Up" button click
        private void signupButton_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnection.OpenCon();
                
                // Check if any of the required fields are empty
                if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text)
                || string.IsNullOrWhiteSpace(passwordTextBox.Text) || string.IsNullOrWhiteSpace(password2TextBox.Text))
                {
                    MessageBox.Show("Please Complete the blank fields", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the entered passwords match
                if (passwordTextBox.Text != password2TextBox.Text)
                {
                    MessageBox.Show("The entered password doesn't match, Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwordTextBox.Clear();
                    password2TextBox.Clear();
                    return;
                }

                // Check if the chosen username is available
                if (!IsUsernameAvailable(usernameTextBox.Text))
                {
                    MessageBox.Show("The entered UserName is already taken. Please choose a different UserName.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the entered email is available
                if (!IsEmailAvailable(emailTextBox.Text))
                {
                    MessageBox.Show("The entered email is already taken. Please choose a different email.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert new user into the database
                InsertNewUser();

                // Create default account for the new user
                CreateDefaultAccount();

                // Show a success message and navigate to the LoginForm
                MessageBox.Show("New user added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbConnection.CloseCon();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbConnection.CloseCon();
            }
        }

        // Check if the chosen username is available in the database
        private bool IsUsernameAvailable(string userName)
        {
            string checkQuery = "SELECT COUNT(*) FROM [User] WHERE UserName=@UserName";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.GetCon()))
            {
                checkCommand.Parameters.AddWithValue("@UserName", userName);
                int count = (int)checkCommand.ExecuteScalar();
                return count == 0;
            }
        }

        // Check if the entered email is available in the database
        private bool IsEmailAvailable(string userEmail)
        {
            string checkQuery = "SELECT COUNT(*) FROM [User] WHERE UserEmail=@UserEmail";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.GetCon()))
            {
                checkCommand.Parameters.AddWithValue("@UserEmail", userEmail);
                int count = (int)checkCommand.ExecuteScalar();
                return count == 0;
            }
        }

        // Insert a new user record into the database
        private void InsertNewUser()
        {
            string insertQuery = "INSERT INTO [User] (UserName, UserEmail, UserPasswd) VALUES (@UserName, @UserEmail, @UserPasswd)";
            using (SqlCommand insertCommand = new SqlCommand(insertQuery, dbConnection.GetCon()))
            {
                insertCommand.Parameters.AddWithValue("@UserName", usernameTextBox.Text);
                insertCommand.Parameters.AddWithValue("@UserEmail", emailTextBox.Text);
                insertCommand.Parameters.AddWithValue("@UserPasswd", passwordTextBox.Text);
                insertCommand.ExecuteNonQuery();
            }
        }

        // Create a default account for the new user
        private void CreateDefaultAccount()
        {
            // Get the UserId of the newly created user
            int userId = GetUserIdByUsername(usernameTextBox.Text);

            string createAccountQuery = "INSERT INTO Account (UserId, AccName, AccBalance, AccCurrId) VALUES (@UserId, 'Wallet', 0.00, 1)";
            using (SqlCommand createAccountCommand = new SqlCommand(createAccountQuery, dbConnection.GetCon()))
            {
                createAccountCommand.Parameters.AddWithValue("@UserId", userId);
                createAccountCommand.ExecuteNonQuery();
            }
        }

        // Get the UserId of a user by their username
        private int GetUserIdByUsername(string userName)
        {
            string getUserIdQuery = "SELECT UserId FROM [User] WHERE UserName=@UserName";
            using (SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, dbConnection.GetCon()))
            {
                getUserIdCommand.Parameters.AddWithValue("@UserName", userName);
                return (int)getUserIdCommand.ExecuteScalar();
            }
        }

        // Event handlers for mouse enter and leave on the "Sign Up" button
        private void signupButton_MouseEnter(object sender, EventArgs e)
        {
            signupButton.FillColor = Color.FromArgb(230, 31, 52);
        }

        private void signupButton_MouseLeave(object sender, EventArgs e)
        {
            signupButton.FillColor = Color.FromArgb(233, 31, 52);
        }

        // Event handler for the "Exit" label click
        private void exitLabel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to leave the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Event handlers for mouse enter and leave on the "Exit" label
        private void exitLabel_MouseEnter(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.FromArgb(233, 31, 52);
        }

        private void exitLabel_MouseLeave(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.FromArgb(100, 120, 130);
        }

        // Event handler for the "Login" label click
        private void loginLabel_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        // Event handlers for mouse enter and leave on the "Login" label
        private void loginLabel_MouseEnter(object sender, EventArgs e)
        {
            loginLabel.ForeColor = Color.FromArgb(30, 41, 59);
        }

        private void loginLabel_MouseLeave(object sender, EventArgs e)
        {
            loginLabel.ForeColor = Color.FromArgb(100, 120, 130);
        }
    }
}
