using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace budget_management_app
{
    internal class ExpensesTabLogic
    {
        private DBConnection dbcon = new DBConnection();
        private DateTime currentDate = DateTime.Today;

        public void getPieChart(int AccId,int Year,int Month,int Day,LiveCharts.WinForms.PieChart pieChart)
        {
            string query_exp = "SELECT Category.CatName, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "JOIN Category ON Expenses.CatId = Category.CatId " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", AccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));


            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            pieChart.Series.Clear();

            System.Windows.Media.Color[] customColors = new System.Windows.Media.Color[]
            {
                System.Windows.Media.Color.FromRgb(230, 225, 175),
                System.Windows.Media.Color.FromRgb(233, 195, 187),
                System.Windows.Media.Color.FromRgb(235, 154, 157),
                System.Windows.Media.Color.FromRgb(212, 129, 176),
                System.Windows.Media.Color.FromRgb(168, 138, 188),
                System.Windows.Media.Color.FromRgb(125, 146, 191),
                System.Windows.Media.Color.FromRgb(106, 169, 192),
                System.Windows.Media.Color.FromRgb(104, 186, 193),
                System.Windows.Media.Color.FromRgb(114, 195, 173),
                System.Windows.Media.Color.FromRgb(147, 201, 140)
            };

            int colorIndex = 0;

            foreach (DataRow row in dataTable_exp.Rows)
            {
                decimal amount = Convert.ToDecimal(row["TotalAmount"]);

                if (amount > 0)
                {
                    var dataPoint = new PieSeries
                    {
                        Title = row["CatName"].ToString().Trim(),
                        Values = new ChartValues<decimal> { amount },
                        DataLabels = true,
                        LabelPoint = point => $"  {amount}  "
                    };
                    dataPoint.Fill = new SolidColorBrush(customColors[colorIndex % customColors.Length]);

                    pieChart.Series.Add(dataPoint);
                    pieChart.LegendLocation = LegendLocation.Bottom;

                    colorIndex++;
                }
            }
            pieChart.DataTooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.OnlySender,
                FontSize = 12,
            };
        }
        public void getHighestExpensees(int AccId, int Year, int Month, int Day, DataGridView dataGridView)
        {
            string query = "SELECT TOP 7 " +
               "CASE " +
               "  WHEN SubCategory.SubName IS NOT NULL THEN SubCategory.SubName " +
               "  WHEN UserSubCat.Us_SubName IS NOT NULL THEN UserSubCat.Us_SubName " +
               "  ELSE Category.CatName " +
               "END AS SubName, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount, Expenses.ExpDate AS DateTrns " +
               "FROM Expenses " +
               "JOIN Account ON Account.AccId = Expenses.AccId " +
               "JOIN Category ON Category.CatId = Expenses.CatId " +
               "LEFT JOIN SubCategory ON Expenses.SubId = SubCategory.SubId " +
               "LEFT JOIN UserSubCat ON Expenses.Us_SubId = UserSubCat.Us_SubId " +
               "WHERE Expenses.AccId = " + AccId +
               " AND Expenses.UserId = " + LoginForm.userId +
               " AND Expenses.ExpDate BETWEEN '" + Year + "-" + Month + "-" + Day +
               "' AND GETDATE() " +
               "ORDER BY Expenses.ExpAmount DESC";

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (row[i] != null && row[i] != DBNull.Value)
                    {
                        row[i] = row[i].ToString().Trim();
                    }
                }
            }
            dataGridView.DataSource = table;
            dbcon.CloseCon();
        }
        public void getColumnChart_Month(int AccId, int Year, int Month, int Day, Chart columnChart)
        {
            string query_exp = "SELECT DATEPART(MONTH, ExpDate) AS MonthNumber, DATEPART(YEAR, ExpDate) AS YearNumber, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY DATEPART(MONTH, ExpDate), DATEPART(YEAR, ExpDate)";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", AccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            columnChart.Series["Expenses"].Points.Clear();
            columnChart.Series["Default"].Points.Clear();

            double max_amount = 0;

            int startYear = Year;
            int endYear = currentDate.Year;

            for (int year = startYear; year <= endYear; year++)
            {
                int startMonth = (year == Year) ? Month : 1;
                int endMonth = (year == currentDate.Year) ? currentDate.Month : 12;

                for (int month = startMonth; month <= endMonth; month++)
                {
                    DataRow[] rows = dataTable_exp.Select("MonthNumber = " + month + " AND YearNumber = " + year);

                    double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                    columnChart.Series["Expenses"].Points.Add(amount);

                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
                    int index = columnChart.Series["Expenses"].Points.Count - 1;
                    columnChart.Series["Expenses"].Points[index].SetCustomProperty("Tooltip", monthName + "\nAmount: " + amount.ToString("N2"));

                    if (amount > max_amount)
                    {
                        max_amount = amount;
                    }
                }
            }

            for (int i = 0; i < columnChart.Series["Expenses"].Points.Count; i++)
            {
                double amount = columnChart.Series["Expenses"].Points[i].YValues[0];
                columnChart.Series["Default"].Points.Add(max_amount * 1.1 - amount);
            }
        }
        public void getColumnChart_Week(int AccId, int Year, int Month, int Day, Chart columnChart)
        {
            string query_exp = "SELECT ExpDate, SUM(Expenses.ExpAmount) AS TotalAmount " +
                   "FROM Expenses " +
                   "WHERE Expenses.AccId = @SelectedAccId " +
                   "AND Expenses.UserId = @UserId " +
                   "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                   "GROUP BY ExpDate";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", AccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            columnChart.Series["Expenses"].Points.Clear();
            columnChart.Series["Default"].Points.Clear();

            double max_amount = 0;

            DateTime startDate = new DateTime(Year, Month, Day);
            DateTime endDate = currentDate;

            DateTime currentWeekStart = GetWeekStartDate(startDate);
            DateTime currentWeekEnd = currentWeekStart.AddDays(6);

            while (currentWeekStart <= endDate)
            {
                DataRow[] rows = dataTable_exp.Select("ExpDate >= #" + currentWeekStart.ToString("MM/dd/yyyy") + "# AND ExpDate <= #" + currentWeekEnd.ToString("MM/dd/yyyy") + "#");

                double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                columnChart.Series["Expenses"].Points.Add(amount);

                int index = columnChart.Series["Expenses"].Points.Count - 1;
                columnChart.Series["Expenses"].Points[index].SetCustomProperty("Tooltip", "From: " + currentWeekStart.ToString("dd/MM/yyyy") + "\nTo: " + currentWeekEnd.ToString("dd/MM/yyyy") + "\nAmount: " + amount.ToString("N2"));

                if (amount > max_amount)
                {
                    max_amount = amount;
                }

                currentWeekStart = currentWeekEnd.AddDays(1);
                currentWeekEnd = currentWeekStart.AddDays(6);
            }

            for (int i = 0; i < columnChart.Series["Expenses"].Points.Count; i++)
            {
                double amount = columnChart.Series["Expenses"].Points[i].YValues[0];
                columnChart.Series["Default"].Points.Add(max_amount * 1.1 - amount);
            }

            DateTime GetWeekStartDate(DateTime date)
            {
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                return date.AddDays(-1 * diff).Date;
            }
        }
        public void getColumnChart_Day(int AccId, int Year, int Month, int Day, Chart columnChart)
        {
            string query_exp = "SELECT ExpDate, SUM(Expenses.ExpAmount) AS TotalAmount " +
                   "FROM Expenses " +
                   "WHERE Expenses.AccId = @SelectedAccId " +
                   "AND Expenses.UserId = @UserId " +
                   "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                   "GROUP BY ExpDate";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", AccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            columnChart.Series["Expenses"].Points.Clear();
            columnChart.Series["Default"].Points.Clear();

            double max_amount = 0;

            DateTime startDate = new DateTime(Year, Month, Day);
            DateTime endDate = currentDate;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DataRow[] rows = dataTable_exp.Select("ExpDate = #" + date.ToString("MM/dd/yyyy") + "#");

                double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                columnChart.Series["Expenses"].Points.Add(amount);

                int index = columnChart.Series["Expenses"].Points.Count - 1;
                columnChart.Series["Expenses"].Points[index].SetCustomProperty("Tooltip", date.ToString("dd/MM/yyyy") + "\nAmount: " + amount.ToString("N2"));

                if (amount > max_amount)
                {
                    max_amount = amount;
                }
            }

            for (int i = 0; i < columnChart.Series["Expenses"].Points.Count; i++)
            {
                double amount = columnChart.Series["Expenses"].Points[i].YValues[0];
                columnChart.Series["Default"].Points.Add(max_amount * 1.1 - amount);
            }
        }
    }
}
