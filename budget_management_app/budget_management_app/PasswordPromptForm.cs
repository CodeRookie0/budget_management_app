using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class PasswordPromptForm : RoundedCornerFormBase
    {
        // An instance of the DBConnection class to manage database connections
        DBConnection dbConnection =new DBConnection();
        public PasswordPromptForm()
        {
            InitializeComponent();
        }

        // Event handler for the "OK" button click
        private void okButton_Click(object sender, EventArgs e)
        {
            // Check if the entered password is valid
            if (IsPasswordValid())
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                passwordTextBox.Text = "";
                MessageBox.Show("Wrong password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Check if the entered password is valid by querying the database
        private bool IsPasswordValid()
        {
            string selectQuery = "SELECT UserPasswd FROM [User] WHERE UserId = @UserId";
            dbConnection.OpenCon();

            // Use a parameterized SqlCommand to prevent SQL injection and fetch the password
            using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
            {
                command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                string password = command.ExecuteScalar()?.ToString().Trim();
                dbConnection.CloseCon();
                return passwordTextBox.Text == password;
            }
            
        }

        // Event handler for the "Exit" label click.
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exitLabel_MouseEnter(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.FromArgb(233,31,52);
        }

        private void exitLabel_MouseLeave(object sender, EventArgs e)
        {
            exitLabel.ForeColor = Color.FromArgb(125, 137, 149);
        }
    }
}
