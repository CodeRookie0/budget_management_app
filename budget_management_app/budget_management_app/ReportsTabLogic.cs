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
        private DBConnection dbcon = new DBConnection();

        public void getRaportMf(int AccId, int Year, int Month, int Day,DataGridView reportMoneyFlow,Label amountMoneyFlow)
        {
            string query = "SELECT " +
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

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", AccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            reportMoneyFlow.Rows.Clear();

            double exp = (dataTable.Rows.Count > 0 && !DBNull.Value.Equals(dataTable.Rows[0]["TotalExpenses"]))
                ? Convert.ToDouble(dataTable.Rows[0]["TotalExpenses"]) : 0;
            double income = (dataTable.Rows.Count > 0 && !DBNull.Value.Equals(dataTable.Rows[0]["TotalIncome"]))
                ? Convert.ToDouble(dataTable.Rows[0]["TotalIncome"]) : 0;
            int num_exp = dataTable.Rows.Count > 0 && dataTable.Rows[0]["ExpensesRowCount"] != DBNull.Value
                ? Convert.ToInt32(dataTable.Rows[0]["ExpensesRowCount"]) : 0;
            int num_income = dataTable.Rows.Count > 0 && dataTable.Rows[0]["IncomeRowCount"] != DBNull.Value
                ? Convert.ToInt32(dataTable.Rows[0]["IncomeRowCount"]) : 0;
            int days = dataTable.Rows.Count > 0 && dataTable.Rows[0]["DaysBetweenDates"] != DBNull.Value
                ? Convert.ToInt32(dataTable.Rows[0]["DaysBetweenDates"]) : 0;


            reportMoneyFlow.Rows.Add("Number", num_income, num_exp);
            reportMoneyFlow.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            reportMoneyFlow.Rows[0].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            reportMoneyFlow.Rows[0].DefaultCellStyle.Format = "0";
            reportMoneyFlow.Rows.Add("Average/Day", "+" + Math.Round(income / days, 2).ToString("0.00"), Math.Round(-exp / days, 2).ToString("0.00"));
            double averageIncome = num_income != 0 ? Math.Round(income / num_income, 2) : 0;
            double averageExpenses = num_exp != 0 ? Math.Round(-exp / num_exp, 2) : 0;
            reportMoneyFlow.Rows.Add("Average/Entry", "+" + averageIncome.ToString("0.00"), averageExpenses.ToString("0.00"));
            reportMoneyFlow.Rows[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            reportMoneyFlow.Rows[2].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            reportMoneyFlow.Rows.Add("Total", "+" + income.ToString("0.00"), (-exp).ToString("0.00"));

            if (income - exp > 0)
            {
                amountMoneyFlow.Text = "+" + (income - exp).ToString("0.00");
            }
            else
            {
                amountMoneyFlow.Text = (income - exp).ToString("0.00");
            }


            reportMoneyFlow.ClearSelection();
            reportMoneyFlow.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dbcon.CloseCon();
        }

        public void getRaportExp(int AccId, int Year, int Month, int Day, DataGridView reportExpenses,Label totalExpenses)
        {
            string query = "SELECT Category.CatName, " +
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


            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", AccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            string query_cat = "SELECT Category.CatName, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "JOIN Category ON Expenses.CatId = Category.CatId " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName";

            SqlCommand command_cat = new SqlCommand(query_cat, dbcon.GetCon());
            command_cat.Parameters.AddWithValue("@SelectedAccId", AccId);
            command_cat.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_cat.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter_cat = new SqlDataAdapter(command_cat);
            DataTable dataTable_cat = new DataTable();
            adapter_cat.Fill(dataTable_cat);

            reportExpenses.Rows.Clear();

            double totalAmount = 0;

            foreach (DataRow row_cat in dataTable_cat.Rows)
            {
                string catName = row_cat["CatName"].ToString().Trim();
                double catAmount = -(row_cat["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row_cat["TotalAmount"]) : 0);
                reportExpenses.Rows.Add(catName, catAmount);

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["CatName"].ToString().Trim() == catName)
                    {
                        string subName = "          " + row["SubName"].ToString().Trim();
                        double subAmount = -(row["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row["TotalAmount"]) : 0);
                        reportExpenses.Rows.Add(subName, "            " + subAmount.ToString("0.00"));
                        int rowIndex = reportExpenses.Rows.Count - 1;
                        reportExpenses.Rows[rowIndex].Cells[0].Style.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                        reportExpenses.Rows[rowIndex].Cells[1].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular);
                        reportExpenses.Rows[rowIndex].Cells[0].Style.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                totalAmount += catAmount;
            }

            totalExpenses.Text = totalAmount.ToString("0.00");
        }

        public void getRaportIn(int AccId, int Year, int Month, int Day, DataGridView reportIncome, Label totalIncome)
        {
            string query = "SELECT Category.CatName, " +
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


            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", AccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            string query_cat = "SELECT Category.CatName, SUM(Income.InAmount) AS TotalAmount " +
               "FROM Income " +
               "JOIN Category ON Income.CatId = Category.CatId " +
               "WHERE Income.AccId = @SelectedAccId " +
               "AND Income.UserId = @UserId " +
               "AND Income.InDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName";

            SqlCommand command_cat = new SqlCommand(query_cat, dbcon.GetCon());
            command_cat.Parameters.AddWithValue("@SelectedAccId", AccId);
            command_cat.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_cat.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter_cat = new SqlDataAdapter(command_cat);
            DataTable dataTable_cat = new DataTable();
            adapter_cat.Fill(dataTable_cat);

            reportIncome.Rows.Clear();

            double totalAmount = 0;

            foreach (DataRow row_cat in dataTable_cat.Rows)
            {
                string catName = row_cat["CatName"].ToString().Trim();
                double catAmount = row_cat["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row_cat["TotalAmount"]) : 0;
                reportIncome.Rows.Add(catName, catAmount);

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["CatName"].ToString().Trim() == catName)
                    {
                        string subName = "          " + row["SubName"].ToString().Trim();
                        double subAmount = row["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row["TotalAmount"]) : 0;
                        reportIncome.Rows.Add(subName, "            " + "+" + subAmount.ToString("0.00"));
                        int rowIndex = reportIncome.Rows.Count - 1;
                        reportIncome.Rows[rowIndex].Cells[0].Style.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                        reportIncome.Rows[rowIndex].Cells[1].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular);
                        reportIncome.Rows[rowIndex].Cells[0].Style.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                totalAmount += catAmount;
            }

            totalIncome.Text = "+" + totalAmount.ToString("0.00");
        }
    }
}
