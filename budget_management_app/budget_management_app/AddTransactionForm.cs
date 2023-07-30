using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace budget_management_app
{
    public partial class AddTransactionForm : Form
    {
        DBConnection dbConnection=new DBConnection();

        // Variables to store selected IDs for various elements
        private int selectedAccountId = 0;
        private int selectedUserSubCategoryId = 0;
        private int selectedSubCategoryId = 0;
        private int selectedCategoryId = 0;

        // Store the last valid amount to revert if invalid input
        private string lastValidAmount = string.Empty;


        public AddTransactionForm()
        {
            InitializeComponent();
            transactionDateTimePicker.MaxDate = DateTime.Now.Date;
            transactionDateTimePicker.Value = DateTime.Now.Date;
            LoadAccounts();
            LoadCategories();
        }

        // Load user accounts into the accountComboBox
        private void LoadAccounts() 
        {
            // Load the user's accounts from the database and populate the accountComboBox
            try
            {
                string selectQuery = "SELECT AccName FROM Account WHERE Account.UserId=" + LoginForm.userId;
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string accountName = reader.GetString(0);
                            accountComboBox.Items.Add(accountName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for selecting an account from accountComboBox
        private void accountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected account's ID and store it in selectedAccountId
            // Also, load the currency information related to the selected account
            LoadCurrency();

            string selectQuery = "SELECT AccId FROM Account WHERE AccName ='" + accountComboBox.SelectedItem.ToString() + "' AND UserId=" + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon());
            dbConnection.OpenCon();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                selectedAccountId = reader.GetInt32(0);
            }

            reader.Close();
            dbConnection.CloseCon();
        }

        // Load currency information related to the selected account and display it in currencyLabel
        private void LoadCurrency()
        {
            // Retrieve the currency code for the selected account from the database and display it in currencyLabel
            try
            {
                string selectQuery = "SELECT Currency.CurrCode " +
                    "FROM Account " +
                    "JOIN Currency ON Account.AccCurrId = Currency.CurrId " +
                    "WHERE Account.AccName ='" + accountComboBox.SelectedItem.ToString() + "'";

                dbConnection.OpenCon();
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    string currCode = command.ExecuteScalar()?.ToString().Trim();
                    currencyLabel.Text = currCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading currency: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Load categories and their subcategories into the transactionCategoryContextMenu
        private void LoadCategories()
        {
            try
            {
                // Load all categories and their subcategories from the database
                string selectQuery = "SELECT CatId, CatName FROM Category";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int catId = Convert.ToInt32(row["CatId"]);
                            string categoryName = row["CatName"].ToString();

                            // Create ToolStripMenuItems for each category and subcategory
                            ToolStripMenuItem categoryItem = new ToolStripMenuItem(categoryName.Trim());

                            // Attach event handlers to handle clicks on category and subcategory items
                            categoryItem.Click += (sender, e) => { selectedCategoryId = catId; };
                            LoadSubcategories(categoryItem, catId, categoryName);

                            // Add the items to the transactionCategoryContextMenu
                            transactionCategoryContextMenu.Items.Add(categoryItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Load subcategories for a given category into the categoryItem in the transactionCategoryContextMenu
        private void LoadSubcategories(ToolStripMenuItem categoryItem, int categoryId, string generalCategoryName)
        {
            // Load subcategories from the database for the specified category
            // Create ToolStripMenuItems for each subcategory and add them to the categoryItem

            Font itemFont = new Font("Segoe UI Variable Display Semibold", 12.75f, FontStyle.Bold);

            categoryItem.DropDownItems.Clear();

            ToolStripMenuItem generalCategory = new ToolStripMenuItem("General : " + generalCategoryName.Trim());
            generalCategory.Font = itemFont;
            generalCategory.BackColor = Color.FromArgb(173, 182, 255);
            generalCategory.Click += (sender, e) => { selectedSubCategoryId = 0; selectedUserSubCategoryId = 0; transactionCategoryButton.Text = generalCategory.Text; };
            categoryItem.DropDownItems.Add(generalCategory);

            try
            {
                // Load subcategories from SubCategory table
                string selectSubcategoriesQuery = "SELECT SubId, SubName FROM SubCategory WHERE CatId = @CategoryId";
                using (SqlCommand subcategoriesCommand = new SqlCommand(selectSubcategoriesQuery, dbConnection.GetCon()))
                {
                    subcategoriesCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = subcategoriesCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int subcatId = reader.GetInt32(0);
                            string subcategoryName = reader.GetString(1);
                            ToolStripMenuItem subcategoryItem = new ToolStripMenuItem(subcategoryName.Trim());
                            subcategoryItem.Font = itemFont;
                            subcategoryItem.BackColor = Color.FromArgb(248, 249, 253);
                            subcategoryItem.Click += (sender, e) => { selectedSubCategoryId = subcatId; transactionCategoryButton.Text = subcategoryItem.Text; };
                            categoryItem.DropDownItems.Add(subcategoryItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subcategories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }

            try
            {
                // Load user-specific subcategories from UserSubCat table
                string selectUserSubcategoriesQuery = "SELECT Us_SubId, Us_SubName FROM UserSubCat WHERE Us_CatId = @CategoryId";
                using (SqlCommand userSubcategoriesCommand = new SqlCommand(selectUserSubcategoriesQuery, dbConnection.GetCon()))
                {
                    userSubcategoriesCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                    dbConnection.OpenCon();
                    using (SqlDataReader userSubcategoriesReader = userSubcategoriesCommand.ExecuteReader())
                    {
                        while (userSubcategoriesReader.Read())
                        {
                            int userSubcatId = userSubcategoriesReader.GetInt32(0);
                            string userSubcategoryName = userSubcategoriesReader.GetString(1);
                            ToolStripMenuItem userSubcategoryItem = new ToolStripMenuItem(userSubcategoryName.Trim());
                            userSubcategoryItem.Font = itemFont;
                            userSubcategoryItem.BackColor = Color.FromArgb(248, 249, 253);
                            userSubcategoryItem.Click += (sender, e) => { selectedUserSubCategoryId = userSubcatId; transactionCategoryButton.Text = userSubcategoryItem.Text; };
                            categoryItem.DropDownItems.Add(userSubcategoryItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user-specific subcategories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for the transactionCategoryButton Click event
        private void transactionCategoryButton_Click(object sender, EventArgs e)
        {
            transactionCategoryContextMenu.Show(transactionCategoryButton, 0, transactionCategoryButton.Height);
        }

        // Event handler for the addButton Click event
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input data (amount, category, account, type, date)
                // If validation fails, return and do not proceed with adding the transaction
                if (!ValidateTransactionAmount() || !ValidateTransactionCategory() || !ValidateSelectedAccount() || !ValidateTransactionType() || !ValidateTransactionDate())
                {
                    return;
                }
                decimal amount = decimal.Parse(transactionAmountTextBox.Text.Replace('.', ','));

                string insertQuery = "";

                if (selectedSubCategoryId != 0 || selectedUserSubCategoryId != 0)
                {
                    if (selectedSubCategoryId != 0)
                    {
                        if (transactionTypeComboBox.SelectedItem.ToString() == "Income")
                        {
                            insertQuery = "INSERT INTO Income (UserId, AccId, CatId, SubId, InAmount, InDate) VALUES (@UserId, @AccId, @CatId, @SubId, @Amount, @Date)";
                        }
                        else if (transactionTypeComboBox.SelectedItem.ToString() == "Expense")
                        {
                            insertQuery = "INSERT INTO Expenses (UserId, AccId, CatId, SubId, ExpAmount, ExpDate) VALUES (@UserId, @AccId, @CatId, @SubId, @Amount, @Date)";
                        }
                    }
                    else
                    {
                        if (transactionTypeComboBox.SelectedItem.ToString() == "Income")
                        {
                            insertQuery = "INSERT INTO Income (UserId, AccId, CatId, Us_SubId, InAmount, InDate) VALUES (@UserId, @AccId, @CatId, @UsSubId, @Amount, @Date)";
                        }
                        else if (transactionTypeComboBox.SelectedItem.ToString() == "Expense")
                        {
                            insertQuery = "INSERT INTO Expenses (UserId, AccId, CatId, Us_SubId, ExpAmount, ExpDate) VALUES (@UserId, @AccId, @CatId, @UsSubId, @Amount, @Date)";
                        }
                    }
                }
                else
                {
                    if (transactionTypeComboBox.SelectedItem.ToString() == "Income")
                    {
                        insertQuery = "INSERT INTO Income (UserId, AccId, CatId, InAmount, InDate) VALUES (@UserId, @AccId, @CatId, @Amount, @Date)";
                    }
                    else if (transactionTypeComboBox.SelectedItem.ToString() == "Expense")
                    {
                        insertQuery = "INSERT INTO Expenses (UserId, AccId, CatId, ExpAmount, ExpDate) VALUES (@UserId, @AccId, @CatId, @Amount, @Date)";
                    }
                }

                // Execute the insert query to add the transaction to the database
                SqlCommand command = new SqlCommand(insertQuery, dbConnection.GetCon());
                command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                command.Parameters.AddWithValue("@AccId", selectedAccountId);
                command.Parameters.AddWithValue("@CatId", selectedCategoryId);
                command.Parameters.AddWithValue("@SubId", selectedSubCategoryId);
                command.Parameters.AddWithValue("@UsSubId", selectedUserSubCategoryId);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Date", transactionDateTimePicker.Value);

                dbConnection.OpenCon();
                command.ExecuteNonQuery();

                string updateQuery = "";
                if (transactionTypeComboBox.SelectedItem.ToString() == "Income")
                {
                    updateQuery = "UPDATE Account SET AccBalance = (AccBalance + @Amount) WHERE UserId = @UserId AND AccId = @AccId";
                }
                else
                {
                    updateQuery = "UPDATE Account SET AccBalance = (AccBalance - @Amount) WHERE UserId = @UserId AND AccId = @AccId";
                }

                // Update the account balance based on the transaction type (income or expense)
                SqlCommand updateCcommand = new SqlCommand(updateQuery, dbConnection.GetCon());

                updateCcommand.Parameters.AddWithValue("@Amount", amount);
                updateCcommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                updateCcommand.Parameters.AddWithValue("@AccId", selectedAccountId);

                updateCcommand.ExecuteNonQuery();

                MessageBox.Show("Transaction Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TransactionForm transactions = new TransactionForm();
                transactions.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Validate the transaction amount entered by the user
        private bool ValidateTransactionAmount()
        {
            if (string.IsNullOrEmpty(transactionAmountTextBox.Text) || !decimal.TryParse(transactionAmountTextBox.Text.Replace('.', ','), out decimal amount) || amount <= 0m)
            {
                MessageBox.Show("Invalid entered transaction value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Validate if a category is selected for the transaction
        private bool ValidateTransactionCategory()
        {
            if (string.IsNullOrEmpty(transactionCategoryButton.Text))
            {
                MessageBox.Show("Missing Information. Please select a category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Validate if an account is selected for the transaction
        private bool ValidateSelectedAccount()
        {
            if (selectedAccountId == 0)
            {
                MessageBox.Show("Missing Information. Please select an account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Validate if a transaction type is selected (income or expense)
        private bool ValidateTransactionType()
        {
            if (transactionTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Missing Information. Please select a transaction type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Validate if the transaction date is valid (not in the future)
        private bool ValidateTransactionDate()
        {
            if (!DateTime.TryParseExact(transactionDateTimePicker.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime userDate) || userDate > DateTime.Today)
            {
                MessageBox.Show("Incorrect data. Please, try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Event handler for the transactionAmountTextBox TextChanged event
        private void transactionAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(transactionAmountTextBox.Text, out decimal result))
            {
                if (transactionAmountTextBox.Text.Length > 15)
                {
                    transactionAmountTextBox.Text = lastValidAmount;
                    transactionAmountTextBox.SelectionStart = transactionAmountTextBox.Text.Length;
                    return;
                }

                // If the conversion succeeds, we check the number of decimal places
                int decimalPlaces = GetDecimalPlaces(result);
                if (decimalPlaces <= 2)
                {
                    lastValidAmount = transactionAmountTextBox.Text;
                }
                else
                {
                    transactionAmountTextBox.Text = lastValidAmount;
                    transactionAmountTextBox.SelectionStart = transactionAmountTextBox.Text.Length;
                }
            }
            else
            {
                transactionAmountTextBox.Text = lastValidAmount;
                transactionAmountTextBox.SelectionStart = transactionAmountTextBox.Text.Length;
            }
        }

        // Utility method to get the number of decimal places in a decimal number
        private int GetDecimalPlaces(decimal number)
        {
            int[] bits = Decimal.GetBits(number);
            int scale = (bits[3] >> 16) & 31;
            return scale;
        }

        // Event handler for the backButton Click event
        private void backButton_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Close();
        }
    }
}
