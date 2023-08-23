using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_management_app
{
    internal class ReportsTabLogic
    {
        private DBConnection dbConnection = new DBConnection();

        // Method to generate money flow report
        public void GenerateMoneyFlowReport(int accountId, int year, int month, int day, DataGridView moneyFlowReport, Label totalMoneyFlowLabel)
        {
            // SQL query to calculate money flow data
            string moneyFlowQuery = "SELECT " +
               "    SUM(ExpAmount) AS TotalExpenses, " +
               "    SUM(InAmount) AS TotalIncome, " +
               "    COUNT(ExpAmount) AS ExpensesRowCount, " +
               "    COUNT(InAmount) AS IncomeRowCount, " +
               "    DATEDIFF(DAY, @StartDate, GETDATE()) AS DaysBetweenDates " +
               "FROM ( " +
               "    SELECT ExpAmount, NULL AS InAmount " +
               "    FROM Expenses " +
               "    WHERE Expenses.AccId = @SelectedAccId " +
               "    AND Expenses.UserId = @UserId " +
               "    AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "    UNION ALL " +
               "    SELECT NULL AS ExpAmount, InAmount " +
               "    FROM Income " +
               "    WHERE Income.AccId = @SelectedAccId " +
               "    AND Income.UserId = @UserId " +
               "    AND Income.InDate BETWEEN @StartDate AND GETDATE() " +
               ") AS CombinedData ";

            // Create SQL command with parameters
            SqlCommand moneyFlowCommand = new SqlCommand(moneyFlowQuery, dbConnection.GetCon());
            moneyFlowCommand.Parameters.AddWithValue("@SelectedAccId", accountId);
            moneyFlowCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
            moneyFlowCommand.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Execute SQL command and fill data into DataTable
            SqlDataAdapter moneyFlowAdapter = new SqlDataAdapter(moneyFlowCommand);
            DataTable moneyFlowDataTable = new DataTable();
            moneyFlowAdapter.Fill(moneyFlowDataTable);

            // Clear existing rows in the DataGridView
            moneyFlowReport.Rows.Clear();

            // Extract values from DataTable
            double expensesTotal = (moneyFlowDataTable.Rows.Count > 0 && !DBNull.Value.Equals(moneyFlowDataTable.Rows[0]["TotalExpenses"]))
                ? Convert.ToDouble(moneyFlowDataTable.Rows[0]["TotalExpenses"]) : 0;
            double incomeTotal = (moneyFlowDataTable.Rows.Count > 0 && !DBNull.Value.Equals(moneyFlowDataTable.Rows[0]["TotalIncome"]))
                ? Convert.ToDouble(moneyFlowDataTable.Rows[0]["TotalIncome"]) : 0;
            int expensesRowCount = moneyFlowDataTable.Rows.Count > 0 && moneyFlowDataTable.Rows[0]["ExpensesRowCount"] != DBNull.Value
                ? Convert.ToInt32(moneyFlowDataTable.Rows[0]["ExpensesRowCount"]) : 0;
            int incomeRowCount = moneyFlowDataTable.Rows.Count > 0 && moneyFlowDataTable.Rows[0]["IncomeRowCount"] != DBNull.Value
                ? Convert.ToInt32(moneyFlowDataTable.Rows[0]["IncomeRowCount"]) : 0;
            int daysBetweenDates = moneyFlowDataTable.Rows.Count > 0 && moneyFlowDataTable.Rows[0]["DaysBetweenDates"] != DBNull.Value
                ? Convert.ToInt32(moneyFlowDataTable.Rows[0]["DaysBetweenDates"]) : 0;


            // Populate DataGridView with calculated values
            moneyFlowReport.Rows.Add("Number", incomeRowCount, expensesRowCount);
            moneyFlowReport.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            moneyFlowReport.Rows[0].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            moneyFlowReport.Rows[0].DefaultCellStyle.Format = "0";
            moneyFlowReport.Rows.Add("Average/Day", "+" + Math.Round(incomeTotal / daysBetweenDates, 2).ToString("0.00"), Math.Round(-expensesTotal / daysBetweenDates, 2).ToString("0.00"));
            double averageIncome = incomeRowCount != 0 ? Math.Round(incomeTotal / incomeRowCount, 2) : 0;
            double averageExpenses = expensesRowCount != 0 ? Math.Round(-expensesTotal / expensesRowCount, 2) : 0;
            moneyFlowReport.Rows.Add("Average/Entry", "+" + averageIncome.ToString("0.00"), averageExpenses.ToString("0.00"));
            moneyFlowReport.Rows[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            moneyFlowReport.Rows[2].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            moneyFlowReport.Rows.Add("Total", "+" + incomeTotal.ToString("0.00"), (-expensesTotal).ToString("0.00"));

            // Set total money flow label text
            if (incomeTotal - expensesTotal > 0)
            {
                totalMoneyFlowLabel.Text = "+" + (incomeTotal - expensesTotal).ToString("0.00");
            }
            else
            {
                totalMoneyFlowLabel.Text = (incomeTotal - expensesTotal).ToString("0.00");
            }

            // Clear selection and set column header style
            moneyFlowReport.ClearSelection();
            moneyFlowReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dbConnection.CloseCon();
        }

        // Method to generate expenses report
        public void GenerateExpensesReport(int accountId, int year, int month, int day, DataGridView expensesReport, Label totalExpensesLabel)
        {
            // SQL query to calculate expenses data
            string expensesQuery = "SELECT Category.CatName, " +
               "COALESCE(SubCategory.SubName, UserSubCat.Us_SubName, CONCAT('General:', Category.CatName)) AS SubName, " +
               "SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "JOIN Category ON Expenses.CatId = Category.CatId " +
               "LEFT JOIN SubCategory ON Expenses.SubId = SubCategory.SubId " +
               "LEFT JOIN UserSubCat ON Expenses.Us_SubId = UserSubCat.Us_SubId " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName, COALESCE(SubCategory.SubName, UserSubCat.Us_SubName, CONCAT('General:', Category.CatName))";


            // Create SQL command with parameters
            SqlCommand expensesCommand = new SqlCommand(expensesQuery, dbConnection.GetCon());
            expensesCommand.Parameters.AddWithValue("@SelectedAccId", accountId);
            expensesCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
            expensesCommand.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Execute SQL command and fill data into DataTable
            SqlDataAdapter expensesAdapter = new SqlDataAdapter(expensesCommand);
            DataTable expensesDataTable = new DataTable();
            expensesAdapter.Fill(expensesDataTable);

            // SQL query to calculate category-wise expenses data
            string categoryQuery = "SELECT Category.CatName, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "JOIN Category ON Expenses.CatId = Category.CatId " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName";

            // Create SQL command for category-wise expenses
            SqlCommand categoryCommand = new SqlCommand(categoryQuery, dbConnection.GetCon());
            categoryCommand.Parameters.AddWithValue("@SelectedAccId", accountId);
            categoryCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
            categoryCommand.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Execute SQL command and fill data into DataTable
            SqlDataAdapter categoryAdapter = new SqlDataAdapter(categoryCommand);
            DataTable categoryDataTable = new DataTable();
            categoryAdapter.Fill(categoryDataTable);

            // Clear existing rows in the DataGridView
            expensesReport.Rows.Clear();

            double totalAmount = 0;

            // Loop through category data and populate the DataGridView
            foreach (DataRow row_cat in categoryDataTable.Rows)
            {
                string catName = row_cat["CatName"].ToString().Trim();
                double catAmount = -(row_cat["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row_cat["TotalAmount"]) : 0);
                expensesReport.Rows.Add(catName, catAmount);

                // Loop through expenses data and populate subcategories
                foreach (DataRow row in expensesDataTable.Rows)
                {
                    if (row["CatName"].ToString().Trim() == catName)
                    {
                        string subName = "          " + row["SubName"].ToString().Trim();
                        double subAmount = -(row["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row["TotalAmount"]) : 0);
                        expensesReport.Rows.Add(subName, "            " + subAmount.ToString("0.00"));
                        int rowIndex = expensesReport.Rows.Count - 1;
                        expensesReport.Rows[rowIndex].Cells[0].Style.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                        expensesReport.Rows[rowIndex].Cells[1].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular);
                        expensesReport.Rows[rowIndex].Cells[0].Style.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                totalAmount += catAmount;
            }

            totalExpensesLabel.Text = totalAmount.ToString("0.00");
        }

        // Method to generate income report
        public void GenerateIncomeReport(int accountId, int year, int month, int day, DataGridView incomeReport, Label totalIncomeLabel)
        {
            // SQL query to calculate income data
            string incomeQuery = "SELECT Category.CatName, " +
               "COALESCE(SubCategory.SubName, UserSubCat.Us_SubName, CONCAT('General:', Category.CatName)) AS SubName, " +
               "SUM(Income.InAmount) AS TotalAmount " +
               "FROM Income " +
               "JOIN Category ON Income.CatId = Category.CatId " +
               "LEFT JOIN SubCategory ON Income.SubId = SubCategory.SubId " +
               "LEFT JOIN UserSubCat ON Income.Us_SubId = UserSubCat.Us_SubId " +
               "WHERE Income.AccId = @SelectedAccId " +
               "AND Income.UserId = @UserId " +
               "AND Income.InDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName, COALESCE(SubCategory.SubName, UserSubCat.Us_SubName, CONCAT('General:', Category.CatName))";


            // Create SQL command with parameters
            SqlCommand incomeCommand = new SqlCommand(incomeQuery, dbConnection.GetCon());
            incomeCommand.Parameters.AddWithValue("@SelectedAccId", accountId);
            incomeCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
            incomeCommand.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Execute SQL command and fill data into DataTable
            SqlDataAdapter incomeAdapter = new SqlDataAdapter(incomeCommand);
            DataTable incomeDataTable = new DataTable();
            incomeAdapter.Fill(incomeDataTable);

            // SQL query to calculate category-wise income data
            string categoryQuery = "SELECT Category.CatName, SUM(Income.InAmount) AS TotalAmount " +
               "FROM Income " +
               "JOIN Category ON Income.CatId = Category.CatId " +
               "WHERE Income.AccId = @SelectedAccId " +
               "AND Income.UserId = @UserId " +
               "AND Income.InDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName";

            // Create SQL command for category-wise income
            SqlCommand categoryCommand = new SqlCommand(categoryQuery, dbConnection.GetCon());
            categoryCommand.Parameters.AddWithValue("@SelectedAccId", accountId);
            categoryCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
            categoryCommand.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Execute SQL command and fill data into DataTable
            SqlDataAdapter categoryAdapter = new SqlDataAdapter(categoryCommand);
            DataTable categoryDataTable = new DataTable();
            categoryAdapter.Fill(categoryDataTable);

            // Clear existing rows in the DataGridView
            incomeReport.Rows.Clear();

            double totalAmount = 0;

            // Loop through category data and populate the DataGridView
            foreach (DataRow row_cat in categoryDataTable.Rows)
            {
                string catName = row_cat["CatName"].ToString().Trim();
                double catAmount = row_cat["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row_cat["TotalAmount"]) : 0;
                incomeReport.Rows.Add(catName, catAmount);

                // Loop through income data and populate subcategories
                foreach (DataRow row in incomeDataTable.Rows)
                {
                    if (row["CatName"].ToString().Trim() == catName)
                    {
                        string subName = "          " + row["SubName"].ToString().Trim();
                        double subAmount = row["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row["TotalAmount"]) : 0;
                        incomeReport.Rows.Add(subName, "            " + "+" + subAmount.ToString("0.00"));
                        int rowIndex = incomeReport.Rows.Count - 1;
                        incomeReport.Rows[rowIndex].Cells[0].Style.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                        incomeReport.Rows[rowIndex].Cells[1].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular);
                        incomeReport.Rows[rowIndex].Cells[0].Style.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                totalAmount += catAmount;
            }

            totalIncomeLabel.Text = "+" + totalAmount.ToString("0.00");
        }
    }
}
