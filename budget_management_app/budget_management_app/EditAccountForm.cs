using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class EditAccountForm : Form
    {
        private DBConnection dbConnection = new DBConnection();
        private int accountId;
        private int currencyId;
        private string currencyCode;
        private string selectedAccountName;

        public EditAccountForm(string accountName)
        {
            InitializeComponent();
            selectedAccountName = accountName;
            LoadCurrencies();
            GetData();
        }

        // Retrieve data for the selected account from the database
        private void GetData()
        {
            try
            {
                // SQL query to retrieve account data using its name
                string selectQuery = "SELECT AccId, AccCurrId, AccBalance, AccName FROM Account WHERE AccName = @AccountName";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@AccountName", selectedAccountName);
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read and populate the account data from the database
                        while (reader.Read())
                        {
                            accountId = reader.GetInt32(0);
                            startBalanceTextBox.Text = reader.GetDecimal(2).ToString();
                            currencyId = reader.GetInt32(1);
                            accountNameTextBox.Text = reader.GetString(3).Trim();
                            accountNameLabel.Text = reader.GetString(3).Trim();
                        }
                    }
                }

                // SQL query to retrieve the currency code for the selected account
                string selectQueryCurr = "SELECT CurrCode FROM Currency WHERE CurrId = @CurrencyId";
                using (SqlCommand commandCurr = new SqlCommand(selectQueryCurr, dbConnection.GetCon()))
                {
                    commandCurr.Parameters.AddWithValue("@CurrencyId", currencyId);
                    using (SqlDataReader readerCurr = commandCurr.ExecuteReader())
                    {
                        // Read and display the currency code
                        while (readerCurr.Read())
                        {
                            currencyCode = readerCurr.GetString(0).Trim();
                            currencyLabel.Text = currencyCode;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Load available currencies into the accountCurrencyComboBox
        private void LoadCurrencies()
        {
            try
            {
                // SQL query to retrieve currency names from the database
                string selectQuery = "SELECT CurrName From Currency";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string currencyName = reader.GetString(0).Trim();
                            accountCurrencyComboBox.Items.Add(currencyName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading currencies: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Go back to the AccountsForm when backButton is clicked
        private void backButton_Click(object sender, EventArgs e)
        {
            AccountsForm accounts = new AccountsForm();
            accounts.Show();
            this.Hide();
        }

        // Update the account information when updateButton is clicked
        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                decimal balance = 0.00m;

                // Validate and parse the starting balance value
                if (string.IsNullOrEmpty(startBalanceTextBox.Text))
                {
                    MessageBox.Show("Starting balance value is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(startBalanceTextBox.Text.Replace('.', ','), out balance))
                {
                    MessageBox.Show("Invalid entered starting balance value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (balance < 0m)
                {
                    MessageBox.Show("Invalid entered starting balance value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate account name and currency selection
                if (string.IsNullOrEmpty(accountNameTextBox.Text) || accountCurrencyComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL query to update the account information in the database
                string updateQuery = "UPDATE Account SET AccName = @AccName, AccBalance = @AccBalance, AccCurrId = @AccCurrId WHERE AccId = @AccId";
                using (SqlCommand command = new SqlCommand(updateQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();

                    // Go back to the AccountsForm after successful update
                    command.Parameters.AddWithValue("@AccName", accountNameTextBox.Text);
                    command.Parameters.AddWithValue("@AccBalance", balance);
                    command.Parameters.AddWithValue("@AccCurrId", currencyId);
                    command.Parameters.AddWithValue("@AccId", accountId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account Updated Successfully", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AccountsForm accounts = new AccountsForm();
                    accounts.Show();
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Update the currency label when a new currency is selected
        private void accountCurrencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCurrencyName = accountCurrencyComboBox.SelectedItem?.ToString();
                if (selectedCurrencyName != null)
                {
                    // SQL query to get the currency ID based on the selected currency name
                    string selectQuery = "SELECT CurrId,CurrCode FROM Currency WHERE CurrName = @CurrencyName";
                    using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                    {
                        command.Parameters.AddWithValue("@CurrencyName", selectedCurrencyName);
                        dbConnection.OpenCon();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                currencyId = reader.GetInt32(0);
                                currencyLabel.Text = reader.GetString(1).Trim();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting currency ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Delete the account and related transactions when deleteButton is clicked
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this account and related transactions?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // SQL queries to delete related transactions
                    string deleteExpensesQuery = "DELETE FROM Expenses WHERE AccId = @AccId AND UserId = @UserId";
                    string deleteIncomeQuery = "DELETE FROM Income WHERE AccId = @AccId AND UserId = @UserId";
                    
                    using (SqlCommand commandExpenses = new SqlCommand(deleteExpensesQuery, dbConnection.GetCon()))
                    using (SqlCommand commandIncome = new SqlCommand(deleteIncomeQuery, dbConnection.GetCon()))
                    {
                        commandExpenses.Parameters.AddWithValue("@AccId", accountId);
                        commandExpenses.Parameters.AddWithValue("@UserId", LoginForm.userId);
                        commandIncome.Parameters.AddWithValue("@AccId", accountId);
                        commandIncome.Parameters.AddWithValue("@UserId", LoginForm.userId);

                        dbConnection.OpenCon();
                        commandExpenses.ExecuteNonQuery();
                        commandIncome.ExecuteNonQuery();
                    }

                    // SQL query to delete the account
                    string deleteAccountQuery = "DELETE FROM Account WHERE AccName = @AccountName AND UserId = @UserId";
                    using (SqlCommand command = new SqlCommand(deleteAccountQuery, dbConnection.GetCon()))
                    {
                        command.Parameters.AddWithValue("@AccountName", selectedAccountName);
                        command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                        dbConnection.OpenCon();
                        command.ExecuteNonQuery();
                    }

                    
                    MessageBox.Show("Account was Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Go back to the AccountsForm after successful deletion
                    AccountsForm accounts = new AccountsForm();
                    accounts.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }
    }
}
