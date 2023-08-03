using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class TransactionsHistoryForm : Form
    {
        private DBConnection dbConnection = new DBConnection();

        // Selected account and category IDs, and transaction type name filter
        private static int selectedAccountId = 0;
        private static int selectedCategoryId = 0;
        private static string selectedTransactionTypeNameFilter;

        // Selected transaction ID and transaction type for deletion
        private static int selectedTransactionId = -1;
        private static string selectedTransactionTypeNameDelete;

        public TransactionsHistoryForm()
        {
            InitializeComponent();
            LoadAccounts();
            LoadCategories();
            LoadTransactionHistory();
        }

        // Load accounts from the database and populate accountComboBox
        private void LoadAccounts()
        {
            try
            {
                // SQL query to select account names for the logged-in user
                string selectQuery = "SELECT AccName FROM Account WHERE UserId = " + LoginForm.userId;
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string data = reader.GetString(0);
                            accountComboBox.Items.Add(data.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading accounts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Load categories from the database and populate categoryComboBox
        private void LoadCategories()
        {
            try
            {
                // SQL query to select category names
                string selectQuery = "SELECT CatName FROM Category";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string data = reader.GetString(0);
                            categoryComboBox.Items.Add(data.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Load the transaction history from the database and display it in transactionsDataGridView
        public void LoadTransactionHistory()
        {
            try
            {
                // SQL query to select transaction history for the logged-in user
                string query = "SELECT 'Income' AS TransactionType, Income.InId AS TransactionId, Account.AccName, Category.CatName,Income.InDate AS TransactionDate, '+' + CAST(Income.InAmount AS VARCHAR) AS Amount FROM Income " +
                    " JOIN Account ON Income.AccId = Account.AccId " + "JOIN Category ON Income.CatId = Category.CatId " +
                    " WHERE Income.UserId =" + LoginForm.userId +
                    " UNION ALL " +
                    " SELECT 'Expenses' AS TransactionType, Expenses.ExpId AS TransactionId,  Account.AccName, Category.CatName,Expenses.ExpDate AS TransactionDate, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
                    " JOIN Account ON Expenses.AccId = Account.AccId " +
                    " JOIN Category ON Expenses.CatId = Category.CatId " +
                    " WHERE Expenses.UserId = " + LoginForm.userId +
                    " ORDER BY TransactionDate DESC";

                // Execute the query and populate the DataGridView
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetCon()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                if (row[i] != null && row[i] != DBNull.Value)
                                {
                                    row[i] = row[i].ToString().Trim();
                                }
                            }
                        }

                        transactionsDataGridView.DataSource = dataTable;
                        transactionsDataGridView.Columns["TransactionDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                        transactionsDataGridView.Columns["TransactionType"].Visible = false;
                        transactionsDataGridView.Columns["TransactionId"].Visible = false;
                        transactionsDataGridView.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading transaction history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler when the user selects an account from the accountComboBox
        private void accountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // If an account is selected (not the default option)
                if (accountComboBox.SelectedItem != null && accountComboBox.SelectedIndex != 0)
                {
                    // SQL query to get the AccId for the selected account and logged-in user
                    string selectQuery = "SELECT AccId FROM Account WHERE AccName ='" + accountComboBox.SelectedItem.ToString() + "' AND UserId=" + LoginForm.userId;
                    SqlCommand comm = new SqlCommand(selectQuery, dbConnection.GetCon());
                    dbConnection.OpenCon();
                    object result = comm.ExecuteScalar();
                    if (result != null)
                    {
                        selectedAccountId = Convert.ToInt32(result);
                    }
                    dbConnection.CloseCon();
                    // Update the DataGridView with the selected filters
                    UpdateDataGridView();
                }

                // If the default option is selected, reset the selectedAccountId and update the DataGridView
                if (accountComboBox.SelectedIndex == 0)
                {
                    selectedAccountId = 0;
                    UpdateDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the account selection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler when the user selects a category from the categoryComboBox
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                // If a category is selected (not the default option)
                if (categoryComboBox.SelectedItem != null && categoryComboBox.SelectedIndex != 0)
                {
                    // SQL query to get the CatId for the selected category
                    string selectQuery = "SELECT CatId FROM Category WHERE CatName ='" + categoryComboBox.SelectedItem.ToString() + "'";
                    SqlCommand comm = new SqlCommand(selectQuery, dbConnection.GetCon());
                    dbConnection.OpenCon();
                    object result = comm.ExecuteScalar();
                    if (result != null)
                    {
                        selectedCategoryId = Convert.ToInt32(result);
                    }
                    dbConnection.CloseCon();
                    // Update the DataGridView with the selected filters
                    UpdateDataGridView();
                }

                // If the default option is selected, reset the selectedCategoryId and update the DataGridView
                if (categoryComboBox.SelectedIndex == 0)
                {
                    selectedCategoryId = 0;
                    UpdateDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the category selection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler when the user selects a transaction type from the typeComboBox
        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // If a transaction type is selected (not the default option)
                if (typeComboBox.SelectedItem != null && typeComboBox.SelectedIndex != 0)
                {
                    selectedTransactionTypeNameFilter = typeComboBox.SelectedItem.ToString();
                    // Update the DataGridView with the selected filters
                    UpdateDataGridView();
                }

                // If the default option is selected, reset the selectedTransactionTypeNameFilter and update the DataGridView
                if (typeComboBox.SelectedIndex == 0)
                {
                    selectedTransactionTypeNameFilter = null;
                    UpdateDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the transaction type selection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update the DataGridView with the selected filters (account, category, and transaction type)
        private void UpdateDataGridView()
        {
            try
            {
                string query = "SELECT 'Income' AS TransactionType, Income.InId AS TransactionId, Account.AccName AS AccName, Category.CatName AS CatName,Income.InDate AS TransactionDate," +
                    " '+' + CAST(Income.InAmount AS VARCHAR) AS Amount FROM Income " +
                   " JOIN Account ON Income.AccId = Account.AccId " + "JOIN Category ON Income.CatId = Category.CatId " +
                   " WHERE Income.UserId = " + LoginForm.userId;

                if (selectedTransactionTypeNameFilter == null)
                {
                    if (selectedAccountId != 0)
                    {
                        query += " AND Income.AccId = " + selectedAccountId;
                    }
                    if (selectedCategoryId != 0)
                    {
                        query += " AND Income.CatId = " + selectedCategoryId;
                    }

                    query += " UNION ALL " +
                             "SELECT 'Expenses' AS TransactionType, Expenses.ExpId AS TransactionId, Account.AccName AS AccName, Category.CatName AS CatName,Expenses.ExpDate AS TransactionDate," +
                             " '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
                   " JOIN Account ON Expenses.AccId = Account.AccId " + "JOIN Category ON Expenses.CatId = Category.CatId " +
                   " WHERE Expenses.UserId =" + LoginForm.userId;

                    if (selectedAccountId != 0)
                    {
                        query += " AND Expenses.AccId = " + selectedAccountId;
                    }
                    if (selectedCategoryId != 0)
                    {
                        query += " AND Expenses.CatId = " + selectedCategoryId;
                    }
                    query += "ORDER BY TransactionDate DESC";
                }
                else if (selectedTransactionTypeNameFilter == "Income")
                {
                    if (selectedAccountId != 0)
                    {
                        query += " AND Income.AccId = " + selectedAccountId;
                    }
                    if (selectedCategoryId != 0)
                    {
                        query += " AND Income.CatId = " + selectedCategoryId;
                    }
                    query += "ORDER BY TransactionDate DESC";
                }
                else
                {
                    query = "SELECT 'Expenses' AS TransactionType, Expenses.ExpId AS TransactionId, Account.AccName AS AccName, Category.CatName AS CatName,Expenses.ExpDate AS TransactionDate," +
                        " '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
                   " JOIN Account ON Expenses.AccId = Account.AccId " + "JOIN Category ON Expenses.CatId = Category.CatId " +
                   " WHERE Expenses.UserId = " + LoginForm.userId;

                    if (selectedAccountId != 0)
                    {
                        query += " AND Expenses.AccId = " + selectedAccountId;
                    }
                    if (selectedCategoryId != 0)
                    {
                        query += " AND Expenses.CatId = " + selectedCategoryId;
                    }
                    query += "ORDER BY TransactionDate DESC";
                }
                SqlCommand command = new SqlCommand(query, dbConnection.GetCon());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                transactionsDataGridView.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler when the user clicks on a cell content in the DataGridView
        private void DataGridView_transactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    selectedTransactionTypeNameDelete = transactionsDataGridView.Rows[e.RowIndex].Cells["TransactionType"].Value.ToString();
                    selectedTransactionId = Convert.ToInt32(transactionsDataGridView.Rows[e.RowIndex].Cells["TransactionId"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the cell content click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler when the user clicks on the deleteButton
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a transaction has been selected for deletion
                if (selectedTransactionId == -1)
                {
                    MessageBox.Show("Have not selected a transaction to delete. Please, try again", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Show a confirmation dialog before deleting the selected transaction
                DialogResult result = MessageBox.Show("Are you sure you want to delete selected transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteQuery = "";

                    // Determine the type of transaction selected (Income, Expenses) and build the appropriate delete query
                    if (selectedTransactionTypeNameDelete == "Income")
                    {
                        deleteQuery = "DELETE FROM Income WHERE InId =  " + selectedTransactionId + " AND UserId= " + LoginForm.userId;
                    }
                    else if (selectedTransactionTypeNameDelete == "Expenses")
                    {
                        deleteQuery = "DELETE FROM Expenses WHERE ExpId = " + selectedTransactionId + " AND UserId= " + LoginForm.userId;
                    }

                    // Execute the delete query to remove the selected transaction
                    SqlCommand command = new SqlCommand(deleteQuery, dbConnection.GetCon());
                    dbConnection.OpenCon();
                    command.ExecuteNonQuery();

                    dbConnection.CloseCon();
                    MessageBox.Show("Transaction was Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                selectedTransactionId = -1;
                selectedTransactionTypeNameDelete = "";
                // Update the DataGridView to reflect the changes after deletion
                LoadTransactionHistory();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler when the user clicks on the addButton
        private void addButton_Click(object sender, EventArgs e)
        {
            AddTransactionForm addTransaction = new AddTransactionForm();
            addTransaction.Show();
            this.Hide();
        }

        // Event handler when the user clicks on the backButton
        private void backButton_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }
    }
}
