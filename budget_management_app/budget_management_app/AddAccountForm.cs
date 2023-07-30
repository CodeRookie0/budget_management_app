using Guna.UI2.WinForms;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace budget_management_app
{
    public partial class AddAccountForm : Form
    {
        private DBConnection dbConnection = new DBConnection();
        private static int selectedCurrencyId = 0;
        private static string selectedCurrencyCode = "USD";
        private string lastValidAmount = string.Empty;

        public AddAccountForm()
        {
            InitializeComponent();
            LoadCurrencies();
        }

        // Loads currency names from the database and populates the ComboBox with them
        private void LoadCurrencies()
        {
            try
            {
                string selectQuery = "SELECT CurrName FROM Currency";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string currencyName = reader.GetString(0);
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
        // Gets the currency code based on the selected currency name from the ComboBox_currency
        public void GetSelectedCurrencyCode()
        {
            try
            {
                string selectQuery = "SELECT CurrCode FROM Currency WHERE CurrName = @CurrencyName";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@CurrencyName", accountCurrencyComboBox.SelectedItem.ToString());
                    dbConnection.OpenCon();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        selectedCurrencyCode = result.ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting currency code: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }
        // Gets the currency ID based on the selected value from the ComboBox_currency
        private void GetSelectedCurrencyId()
        {
            try
            {
                string selectQuery = "SELECT CurrId FROM Currency WHERE CurrName = @CurrencyName";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@CurrencyName", accountCurrencyComboBox.SelectedItem.ToString());
                    dbConnection.OpenCon();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        selectedCurrencyId = Convert.ToInt32(result);
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

        // Event handler for the ComboBox selected index change event
        private void accountCurrencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedCurrencyCode();
            currencyLabel.Text = selectedCurrencyCode;
        }

        // Add data to Account table
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFormInputs())
                {
                    return;
                }

                decimal balance = 0.00m;

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

                if (IsAccountNameExist(accountNameTextBox.Text))
                {
                    MessageBox.Show("An account with the same name already exists. Please choose a different Account Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    accountNameTextBox.Text = "";
                    return;
                }

                GetSelectedCurrencyId();
                string insertQuery = "INSERT INTO Account (UserId, AccName, AccBalance, AccCurrId) VALUES (@UserId, @AccName, @AccBalance, @AccCurrId)";
                using (SqlCommand command = new SqlCommand(insertQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();

                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    command.Parameters.AddWithValue("@AccName", accountNameTextBox.Text);
                    command.Parameters.AddWithValue("@AccBalance", balance);
                    command.Parameters.AddWithValue("@AccCurrId", selectedCurrencyId);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Account Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AccountsForm accounts = new AccountsForm();
                    accounts.Show();
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Validates the user inputs before adding the account
        private bool ValidateFormInputs()
        {
            if (string.IsNullOrEmpty(startBalanceTextBox.Text))
            {
                MessageBox.Show("Starting balance value is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (accountCurrencyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a currency.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (startBalanceTextBox.Text.Length > 21)
            {
                startBalanceTextBox.Text = lastValidAmount;
                startBalanceTextBox.SelectionStart = startBalanceTextBox.Text.Length;
                return false;
            }

            return true;
        }

        // Checks if the account name already exists in the database
        private bool IsAccountNameExist(string accountName)
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM Account WHERE AccName = @AccountName";
                using (SqlCommand command = new SqlCommand(checkQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@AccountName", accountName);
                    dbConnection.OpenCon();

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking account existence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for the startBalanceTextBox text changed event
        private void startBalanceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(startBalanceTextBox.Text, out decimal result))
            {
                if (startBalanceTextBox.Text.Length > 21)
                {
                    startBalanceTextBox.Text = lastValidAmount;
                    startBalanceTextBox.SelectionStart = startBalanceTextBox.Text.Length;
                    return;
                }

                // If the conversion succeeds, we check the number of decimal places
                int decimalPlaces = GetDecimalPlaces(result);
                if (decimalPlaces <= 2)
                {
                    lastValidAmount = startBalanceTextBox.Text;
                }
                else
                {
                    startBalanceTextBox.Text = lastValidAmount;
                    startBalanceTextBox.SelectionStart = startBalanceTextBox.Text.Length;
                }
            }
            else
            {
                startBalanceTextBox.Text = lastValidAmount;
                startBalanceTextBox.SelectionStart = startBalanceTextBox.Text.Length;
            }
        }

        // Helper method to get the number of decimal places in a decimal number
        private int GetDecimalPlaces(decimal number)
        {
            int[] bits = Decimal.GetBits(number);
            int scale = (bits[3] >> 16) & 31;
            return scale;
        }

        // Event handler for the back button click event
        private void backButton_Click(object sender, EventArgs e)
        {
            AccountsForm accounts = new AccountsForm();
            accounts.Show();
            this.Hide();
        }
    }
}
