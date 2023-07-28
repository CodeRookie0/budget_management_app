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
        // Create a new instance of the DBConnection class
        DBConnection dbConnection =new DBConnection();

        // Create a public static variable to store the user ID
        public static int userId;

        // Constructor for the Login form
        public LoginForm()
        {
            InitializeComponent();
        }

        // Event handler for the "Log In" button click
        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the email and password fields are empty
                if (string.IsNullOrEmpty(emailTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    MessageBox.Show("Please Complete the blank fields", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Prepare the SQL query to retrieve user data based on email and password
                string loginQuery = "SELECT * FROM [User] WHERE UserEmail = @UserEmail AND UserPasswd = @UserPasswd";
                SqlCommand command = new SqlCommand(loginQuery, dbConnection.GetCon());
                dbConnection.OpenCon();

                // Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@UserEmail", emailTextBox.Text);
                command.Parameters.AddWithValue("@UserPasswd", passwordTextBox.Text);

                // Create a data adapter and fill a data table with the results from the query
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable userDataTable = new DataTable();
                dataAdapter.Fill(userDataTable);

                // If the query returned any rows, the user's credentials are valid
                if (userDataTable.Rows.Count > 0)
                {
                    userId = Convert.ToInt32(userDataTable.Rows[0]["UserId"]);
                    HomeForm start = new HomeForm();
                    start.Show();
                    this.Hide();
                }
                else
                {
                    // Show an error message if the login credentials are incorrect
                    MessageBox.Show("Wrong Email or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Clear the password field to allow the user to re-enter their credentials
                    passwordTextBox.Clear();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while processing the login request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handlers to change the color of the "Login" button when the mouse hovers over it
        private void loginButton_MouseEnter(object sender, EventArgs e)
        {
            loginButton.FillColor = Color.FromArgb(230, 31, 52);
        }

        private void loginButton_MouseLeave(object sender, EventArgs e)
        {
            loginButton.FillColor = Color.FromArgb(233, 31, 52);
        }

        // Event handler for the "Sign Up" label click
        private void signupLabel_Click(object sender, EventArgs e)
        {
            SignUpForm sign = new SignUpForm();
            sign.Show();
            this.Hide();
        }

        // Event handlers to change the color of the "Sign Up" label when the mouse hovers over it
        private void signupLabel_MouseEnter(object sender, EventArgs e)
        {
            signupLabel.ForeColor = Color.FromArgb(30, 41, 59);
        }

        private void signupLabel_MouseLeave(object sender, EventArgs e)
        {
            signupLabel.ForeColor = Color.FromArgb(100, 120, 130);
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

        // Event handlers to change the color of the "Exit" label when the mouse hovers over it
        private void exitLabel_MouseEnter(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.FromArgb(233, 31, 52);
        }

        private void exitLabel_MouseLeave(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.FromArgb(100, 120, 130);
        }
    }
}
