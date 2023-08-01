using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class SettingsForm : Form
    {
        // Create an instance of DBConnection class to handle database operations
        DBConnection dbConnection =new DBConnection();

        // Store the user name and password for reference
        private string userName;
        private string userPassword;

        public SettingsForm()
        {
            InitializeComponent();
            // Load user data when the form is initialized
            LoadUserData();
        }

        // Method to load user data from the database and display it on the form
        private void LoadUserData()
        {
            try
            {
                // SQL query to fetch user data based on the UserId from the LoginForm
                string selectQuery = "SELECT UserName, UserEmail, UserCreatedAt, UserPasswd FROM [User] WHERE UserId = @UserId";
                SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon());
                command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                dbConnection.OpenCon();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Read data from the database and populate the form controls
                    userName = reader["UserName"].ToString().Trim();
                    userPassword = reader["UserPasswd"].ToString().Trim();
                    emailTextBox.Text = reader["UserEmail"].ToString().Trim();
                    createdAtTextBox.Text = ((DateTime)reader["UserCreatedAt"]).ToString("dd.MM.yyyy").Trim();
                    userNameTextBox.Text = userName.Trim();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading user data. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for logoutButton Click event
        private void logoutButton_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog before logging out
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
        }

        // Event handler for commitButton Click event
        private void commitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the user name has been modified
                if (userName != userNameTextBox.Text.Trim())
                {
                    // Validate if the new user name is available
                    if (IsUserNameTaken(userNameTextBox.Text))
                    {
                        MessageBox.Show("The entered UserName is already taken. Please choose a different UserName.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Update the user name in the database
                    UpdateUserName(userNameTextBox.Text);
                    MessageBox.Show("UserName updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Check if any of the password fields are filled
                if (!string.IsNullOrEmpty(passwordTextBox.Text) || !string.IsNullOrEmpty(newPasswordTextBox.Text) || !string.IsNullOrEmpty(confirmNewPasswordTextBox.Text))
                {
                    // Validate the entered passwords
                    if (!ValidatePassword())
                    {
                        return;
                    }

                    // Update the user password in the database
                    UpdateUserPassword(newPasswordTextBox.Text);
                    passwordTextBox.Text = "";
                    confirmNewPasswordTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reload the user data to reflect the changes
                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating user data. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to check if a given user name is already taken in the database
        private bool IsUserNameTaken(string userName)
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM [User] WHERE UserName = @UserName";
                dbConnection.OpenCon();
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, dbConnection.GetCon()))
                {
                    checkCommand.Parameters.AddWithValue("@UserName", userName);
                    int count = (int)checkCommand.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking the user name. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Method to update the user name in the database
        private void UpdateUserName(string newUserName)
        {
            try
            {
                string updateQuery = "UPDATE [User] SET UserName = @NewUserName WHERE UserId = @UserId";
                dbConnection.OpenCon();
                using (SqlCommand command = new SqlCommand(updateQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@NewUserName", newUserName);
                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the user name. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Method to validate the password entered by the user
        private bool ValidatePassword()
        {
            try
            {
                if (passwordTextBox.Text != userPassword)
                {
                    MessageBox.Show("Incorrect current password. Please, try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwordTextBox.Text = "";
                    confirmNewPasswordTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                    return false;
                }
                if (newPasswordTextBox.Text != confirmNewPasswordTextBox.Text)
                {
                    MessageBox.Show("New passwords must be the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirmNewPasswordTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                    return false;
                }
                if (newPasswordTextBox.Text == userPassword)
                {
                    MessageBox.Show("The new Password is the same as the current one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwordTextBox.Text = "";
                    confirmNewPasswordTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                    return false;
                }
                return true;
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show("An error occurred while validating the password. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to update the user password in the database
        private void UpdateUserPassword(string newPassword)
        {
            try
            {
                string updateQuery = "UPDATE [User] SET UserPasswd = @NewPassword WHERE UserId = @UserId";
                dbConnection.OpenCon();
                using (SqlCommand command = new SqlCommand(updateQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the password. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for deleteAccountLabel Click event
        private void deleteAccountLabel_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog before deleting the account
            DialogResult result = MessageBox.Show("Are you sure you want to delete account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (result == DialogResult.Yes)
                {
                    // Prompt the user for password before account deletion
                    PasswordPromptForm passwordPrompt = new PasswordPromptForm();
                    passwordPrompt.ShowDialog();
                    DialogResult passwdResult = passwordPrompt.ShowDialog();
                    if (passwdResult == DialogResult.OK)
                    {
                        // If the user confirms with password, proceed with account deletion
                        DeleteAccount();
                        
                        MessageBox.Show("Your account has been successfully deleted.", "Deleting your account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // After deletion, show the LoginForm and hide the SettingsForm
                        LoginForm login = new LoginForm();
                        login.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting your account. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to delete the user account and associated data from the database
        private void DeleteAccount()
        {
            try
            {
                int userId = LoginForm.userId;

                // SQL queries to delete user data from various tables
                string deleteIncomeQuery = "DELETE FROM Income WHERE UserId = " + userId;
                string deleteExpensesQuery = "DELETE FROM Expenses WHERE UserId = " + userId;
                string deleteSubcategoriesQuery = "DELETE FROM UserSubCat WHERE UserId = " + userId;
                string deleteAccountsQuery = "DELETE FROM Account WHERE UserId = " + userId;
                string deleteUserQuery = "DELETE FROM [User] WHERE UserId = " + userId;

                SqlCommand command;
                dbConnection.OpenCon();

                // Delete from Income table
                command = new SqlCommand(deleteIncomeQuery, dbConnection.GetCon());
                command.ExecuteNonQuery();

                // Delete from Expenses table
                command = new SqlCommand(deleteExpensesQuery, dbConnection.GetCon());
                command.ExecuteNonQuery();

                // Delete from UserSubCat table
                command = new SqlCommand(deleteSubcategoriesQuery, dbConnection.GetCon());
                command.ExecuteNonQuery();

                // Delete from Account table
                command = new SqlCommand(deleteAccountsQuery, dbConnection.GetCon());
                command.ExecuteNonQuery();

                // Delete from User table
                command = new SqlCommand(deleteUserQuery, dbConnection.GetCon());
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting your account. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for mouse enter event on deleteAccountLabel
        private void deleteAccountLabel_MouseEnter(object sender, EventArgs e)
        {
            deleteAccountLabel.ForeColor=Color.FromArgb(30, 41, 59);
        }

        // Event handler for mouse leave event on deleteAccountLabel
        private void deleteAccountLabel_MouseLeave(object sender, EventArgs e)
        {
            deleteAccountLabel.ForeColor = Color.FromArgb(233, 31, 52);
        }

        // Event handler for backButton Click event
        private void backButton_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }
    }
}
