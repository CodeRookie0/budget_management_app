using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class SubcategoriesForm : Form
    {
        // The DBConnection instance for database operations
        private DBConnection dbConnection = new DBConnection();
        // A string to store the name of the selected subcategory
        private string selectedSubcategory = "";
        private string selectedCategoryName;

        public SubcategoriesForm(string categoryName)
        {
            InitializeComponent();
            selectedCategoryName= categoryName;

        }

        private void SubCategoryForm_Load(object sender, EventArgs e)
        {
            // Display the selected category name in a label
            selectedCategoryLabel.Text = selectedCategoryName.Trim();
            selectedCategoryLabel.Location = new Point((this.Width - selectedCategoryLabel.Width) / 2,93);

            // Load categories, subcategories, and user-specific subcategories
            LoadCategories();
            LoadSubcategories();
            LoadUserSubcategories();
        }

        // Load categories from the database and populate the categoryDataGridView
        private void LoadCategories()
        {
            string selectCategoryQuery = "SELECT CatName FROM Category WHERE CatName = @SelectedCategory";
            SqlCommand categoryCommand = new SqlCommand(selectCategoryQuery, dbConnection.GetCon());
            categoryCommand.Parameters.AddWithValue("@SelectedCategory", selectedCategoryName);
            SqlDataAdapter categoryAdapter = new SqlDataAdapter(categoryCommand);
            DataTable categoryTable = new DataTable();
            categoryAdapter.Fill(categoryTable);
            categoryDataGridView.DataSource = categoryTable;
        }

        // Load subcategories for the selected category and populate the subcategoriesDataGridView
        private void LoadSubcategories()
        {
            string selectSubcategoryQuery = "SELECT SubName FROM SubCategory WHERE CatId = (SELECT CatId FROM Category WHERE CatName = @SelectedCategory)";
            SqlCommand subcategoryCommand = new SqlCommand(selectSubcategoryQuery, dbConnection.GetCon());
            subcategoryCommand.Parameters.AddWithValue("@SelectedCategory", selectedCategoryName);
            SqlDataAdapter subcategoryAdapter = new SqlDataAdapter(subcategoryCommand);
            DataTable subcategoryTable = new DataTable();
            subcategoryAdapter.Fill(subcategoryTable);

            foreach (DataRow row in subcategoryTable.Rows)
            {
                row["SubName"] = row["SubName"].ToString().Trim();
            }

            // Add a column to show transaction count for each subcategory
            subcategoryTable.Columns.Add("TransactionCount", typeof(string));

            // Calculate transaction count for each subcategory and update the table
            foreach (DataRow row in subcategoryTable.Rows)
            {
                string subcategoryName = row["SubName"].ToString();
                int transactionCount = GetTransactionCountForSubcategory(subcategoryName);
                row["TransactionCount"] = transactionCount.ToString() + " txns  ";
            }

            // Display the subcategory table in the subcategoriesDataGridView
            subcategoriesDataGridView.DataSource = subcategoryTable;
            subcategoriesDataGridView.Columns["TransactionCount"].DefaultCellStyle.Font = new Font("Segoe UI Variable Display", 13);
            subcategoriesDataGridView.Columns["TransactionCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            subcategoriesDataGridView.Columns["TransactionCount"].Width = 100;
            subcategoriesDataGridView.ClearSelection();
        }

        // Get the transaction count for a specific subcategory from the database
        private int GetTransactionCountForSubcategory(string subcategoryName)
        {
            int transactionCount = 0;

            // SQL queries to count transactions for expenses and income related to the subcategory
            string expensesQuery = "SELECT COUNT(*) FROM Expenses WHERE SubId IN (SELECT SubId FROM SubCategory WHERE SubName = @SubName) AND UserId = @UserId";
            string incomeQuery = "SELECT COUNT(*) FROM Income WHERE SubId IN (SELECT SubId FROM SubCategory WHERE SubName = @SubName) AND UserId = @UserId";

            // Execute the queries and calculate the total transaction count
            using (SqlCommand expensesCommand = new SqlCommand(expensesQuery, dbConnection.GetCon()))
            using (SqlCommand incomeCommand = new SqlCommand(incomeQuery, dbConnection.GetCon()))
            {
                expensesCommand.Parameters.AddWithValue("@SubName", subcategoryName);
                expensesCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                dbConnection.OpenCon();
                transactionCount += (int)expensesCommand.ExecuteScalar();

                incomeCommand.Parameters.AddWithValue("@SubName", subcategoryName);
                incomeCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                transactionCount += (int)incomeCommand.ExecuteScalar();
            }

            dbConnection.CloseCon();
            return transactionCount;
        }

        // Load user-specific subcategories and populate the mySubcategoriesDataGridView
        private void LoadUserSubcategories()
        {
            string selectUserSubcategoriesQuery = "SELECT Us_SubName FROM UserSubCat WHERE Us_CatId = (SELECT CatId FROM Category WHERE CatName = @SelectedCategory) AND UserId = @UserId";
            SqlCommand userSubcategoriesCommand = new SqlCommand(selectUserSubcategoriesQuery, dbConnection.GetCon());
            userSubcategoriesCommand.Parameters.AddWithValue("@SelectedCategory", selectedCategoryName);
            userSubcategoriesCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
            SqlDataAdapter userSubcategoriesAdapter = new SqlDataAdapter(userSubcategoriesCommand);
            DataTable userSubcategoriesTable = new DataTable();
            userSubcategoriesAdapter.Fill(userSubcategoriesTable);

            foreach (DataRow row in userSubcategoriesTable.Rows)
            {
                row["Us_SubName"] = row["Us_SubName"].ToString().Trim();
            }

            // Add a column to show transaction count for each user-specific subcategory
            userSubcategoriesTable.Columns.Add("TransactionCount", typeof(string));

            // Calculate transaction count for each user-specific subcategory and update the table
            foreach (DataRow row in userSubcategoriesTable.Rows)
            {
                string mySubcategoryName = row["Us_SubName"].ToString();
                int transactionCount = GetTransactionCountForMySubcategory(mySubcategoryName);
                row["TransactionCount"] = transactionCount.ToString() + " txns  ";
            }

            // Display the user-specific subcategory table in the mySubcategoriesDataGridView
            mySubcategoriesDataGridView.DataSource = userSubcategoriesTable;
            mySubcategoriesDataGridView.Columns["TransactionCount"].DefaultCellStyle.Font = new Font("Segoe UI Variable Display", 13);
            mySubcategoriesDataGridView.Columns["TransactionCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mySubcategoriesDataGridView.Columns["TransactionCount"].Width = 100;
            mySubcategoriesDataGridView.ClearSelection();
        }

        // Get the transaction count for a specific user-specific subcategory from the database
        private int GetTransactionCountForMySubcategory(string mySubcategoryName)
        {
            int transactionCount = 0;

            // SQL queries to count transactions for expenses and income related to the user-specific subcategory
            string expensesQuery = "SELECT COUNT(*) FROM Expenses WHERE Us_SubId IN (SELECT Us_SubId FROM UserSubCat WHERE Us_SubName = @Us_SubName) AND UserId = @UserId";
            string incomeQuery = "SELECT COUNT(*) FROM Income WHERE Us_SubId IN (SELECT Us_SubId FROM UserSubCat WHERE Us_SubName = @Us_SubName) AND UserId = @UserId";

            // Execute the queries and calculate the total transaction count
            using (SqlCommand expensesCommand = new SqlCommand(expensesQuery, dbConnection.GetCon()))
            using (SqlCommand incomeCommand = new SqlCommand(incomeQuery, dbConnection.GetCon()))
            {
                expensesCommand.Parameters.AddWithValue("@Us_SubName", mySubcategoryName);
                expensesCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                dbConnection.OpenCon();
                transactionCount += (int)expensesCommand.ExecuteScalar();

                incomeCommand.Parameters.AddWithValue("@Us_SubName", mySubcategoryName);
                incomeCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                transactionCount += (int)incomeCommand.ExecuteScalar();
            }

            dbConnection.CloseCon();
            return transactionCount;
        }

        // Event handler for the addButton Click event
        private void addButton_Click(object sender, EventArgs e)
        {
            AddSubcategoryForm addSubcategory = new AddSubcategoryForm(selectedCategoryName);
            addSubcategory.Show();
            this.Hide();
        }

        // Event handler for the deleteButton Click event
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Check if a subcategory is selected for deletion
            if (string.IsNullOrEmpty(selectedSubcategory))
            {
                MessageBox.Show("Subcategory not selected or cannot be deleted. Remember that you can only delete subcategories created by you.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Ask for confirmation before deleting the selected subcategory and its related transactions
                DialogResult result = MessageBox.Show("Are you sure you want to delete this subcategory '" + selectedSubcategory + "' and all transactions related to it ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Get the subcategory ID and delete its transactions and user-subcategory relationship from the database
                    int subId = GetSubIdForSubcategory(selectedSubcategory.PadRight(60));
                    if (subId > 0)
                    {
                        DeleteTransactionsForSubcategory(subId);
                        DeleteUserSubcategory(selectedSubcategory.PadRight(60));
                        LoadUserSubcategories();
                        selectedSubcategory = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Get the subcategory ID for the specified subcategory name from the database
        private int GetSubIdForSubcategory(string subcategoryName)
        {
            int subId = 0;
            string getSubIdQuery = "SELECT Us_SubId FROM UserSubCat WHERE UserId = @UserId AND Us_SubName = @Us_SubName";
            using (SqlCommand getSubIdCommand = new SqlCommand(getSubIdQuery, dbConnection.GetCon()))
            {
                getSubIdCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                getSubIdCommand.Parameters.AddWithValue("@Us_SubName", subcategoryName);
                dbConnection.OpenCon();
                subId = Convert.ToInt32(getSubIdCommand.ExecuteScalar());
                dbConnection.CloseCon();
            }
            return subId;
        }

        // Delete all transactions related to the specified subcategory ID from the database
        private void DeleteTransactionsForSubcategory(int subId)
        {
            string deleteIncomeQuery = "DELETE FROM Income WHERE Us_SubId = @SubId AND UserId = @UserId";
            string deleteExpensesQuery = "DELETE FROM Expenses WHERE Us_SubId = @SubId AND UserId = @UserId";

            using (SqlCommand deleteIncomeCommand = new SqlCommand(deleteIncomeQuery, dbConnection.GetCon()))
            using (SqlCommand deleteExpensesCommand = new SqlCommand(deleteExpensesQuery, dbConnection.GetCon()))
            {
                deleteIncomeCommand.Parameters.AddWithValue("@SubId", subId);
                deleteIncomeCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);

                deleteExpensesCommand.Parameters.AddWithValue("@SubId", subId);
                deleteExpensesCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);

                dbConnection.OpenCon();
                deleteIncomeCommand.ExecuteNonQuery();
                deleteExpensesCommand.ExecuteNonQuery();
                dbConnection.CloseCon();
            }
        }

        // Delete the user-subcategory relationship from the database for the specified subcategory name
        private void DeleteUserSubcategory(string subcategoryName)
        {
            string deleteQuery = "DELETE FROM UserSubCat WHERE UserId = @UserId AND Us_SubName = @Us_SubName";
            using (SqlCommand deleteSubCatCommand = new SqlCommand(deleteQuery, dbConnection.GetCon()))
            {
                deleteSubCatCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                deleteSubCatCommand.Parameters.AddWithValue("@Us_SubName", subcategoryName.Trim());
                dbConnection.OpenCon();
                deleteSubCatCommand.ExecuteNonQuery();
                dbConnection.CloseCon();
            }
        }

        private void mySubcategoriesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedSubcategory = mySubcategoriesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            subcategoriesDataGridView.ClearSelection();
        }

        private void subcategoriesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedSubcategory = "";
            mySubcategoriesDataGridView.ClearSelection();
        }

        private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedSubcategory = "";
            mySubcategoriesDataGridView.ClearSelection();
        }

        // Event handler for the backButton Click event
        private void backButton_Click(object sender, EventArgs e)
        {
            CategoriesForm categories = new CategoriesForm();
            categories.Show();
            this.Hide();
        }
    }
}
