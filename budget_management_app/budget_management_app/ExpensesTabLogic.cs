using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace budget_management_app
{
    internal class ExpensesTabLogic
    {
        private DBConnection dbConnection = new DBConnection();
        private DateTime currentDate = DateTime.Today;

        // Generates a pie chart displaying expenses by category
        public void GeneratePieChart(int accountId, int year, int month, int day, LiveCharts.WinForms.PieChart pieChart)
        {
            // SQL query to fetch category-wise expenses
            string queryExpenses = "SELECT Category.CatName, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "JOIN Category ON Expenses.CatId = Category.CatId " +
               "WHERE Expenses.AccId = @SelectedAccountId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName";

            // Create a command to execute the query
            SqlCommand commandExpenses = new SqlCommand(queryExpenses, dbConnection.GetCon());
            commandExpenses.Parameters.AddWithValue("@SelectedAccountId", accountId);
            commandExpenses.Parameters.AddWithValue("@UserId", LoginForm.userId);
            commandExpenses.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Create an adapter to fetch data into a DataTable
            SqlDataAdapter adapterExpenses = new SqlDataAdapter(commandExpenses);
            DataTable dataTableExpenses = new DataTable();
            adapterExpenses.Fill(dataTableExpenses);

            // Clear existing series in the pie chart
            pieChart.Series.Clear();

            // Define custom colors for chart slices
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

            // Iterate through rows of expense data
            foreach (DataRow row in dataTableExpenses.Rows)
            {
                decimal amount = Convert.ToDecimal(row["TotalAmount"]);

                if (amount > 0)
                {
                    // Create a data point for the pie chart
                    var dataPoint = new PieSeries
                    {
                        Title = row["CatName"].ToString().Trim(),
                        Values = new ChartValues<decimal> { amount },
                        DataLabels = true,
                        LabelPoint = point => $"  {amount}  "
                    };
                    dataPoint.Fill = new SolidColorBrush(customColors[colorIndex % customColors.Length]);

                    // Add the data point to the pie chart series
                    pieChart.Series.Add(dataPoint);
                    pieChart.LegendLocation = LegendLocation.Bottom;

                    colorIndex++;
                }
            }

            // Configure data tooltip for the chart
            pieChart.DataTooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.OnlySender,
                FontSize = 12,
            };
        }

        // Generates a grid displaying highest expenses
        public void GenerateHighestExpenses(int accountId, int year, int month, int day, DataGridView dataGridView)
        {
            // SQL query to fetch top 7 highest expenses
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
               "WHERE Expenses.AccId = @SelectedAccountId " +
               " AND Expenses.UserId = @UserId " +
               " AND Expenses.ExpDate BETWEEN @StartDate "  +
               "' AND GETDATE() " +
               "ORDER BY Expenses.ExpAmount DESC";

            // Create a command to execute the query
            SqlCommand command = new SqlCommand(query, dbConnection.GetCon());
            command.Parameters.AddWithValue("@SelectedAccountId", accountId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));
            dbConnection.OpenCon();

            // Create an adapter to fetch data into a DataTable
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Trim whitespace from cells
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
            dbConnection.CloseCon();
        }

        // Generates a column chart displaying monthly expenses
        public void GenerateColumnChartMonth(int accountId, int year, int month, int day, Chart columnChart)
        {
            // SQL query to fetch monthly expenses
            string query_exp = "SELECT DATEPART(MONTH, ExpDate) AS MonthNumber, DATEPART(YEAR, ExpDate) AS YearNumber, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY DATEPART(MONTH, ExpDate), DATEPART(YEAR, ExpDate)";

            // Create a command to execute the query
            SqlCommand commandExpenses = new SqlCommand(query_exp, dbConnection.GetCon());
            commandExpenses.Parameters.AddWithValue("@SelectedAccId", accountId);
            commandExpenses.Parameters.AddWithValue("@UserId", LoginForm.userId);
            commandExpenses.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Create an adapter to fetch data into a DataTable
            SqlDataAdapter adapterExpenses = new SqlDataAdapter(commandExpenses);
            DataTable dataTableExpenses = new DataTable();
            adapterExpenses.Fill(dataTableExpenses);

            // Clear existing data points in the chart series
            columnChart.Series["Expenses"].Points.Clear();
            columnChart.Series["Default"].Points.Clear();

            double maxAmount = 0;

            int startYear = year;
            int endYear = currentDate.Year;

            for (int loopYear = startYear; loopYear <= endYear; loopYear++)
            {
                int startMonth = (loopYear == year) ? month : 1;
                int endMonth = (loopYear == currentDate.Year) ? currentDate.Month : 12;

                for (int loopMonth = startMonth; loopMonth <= endMonth; loopMonth++)
                {
                    DataRow[] rows = dataTableExpenses.Select("MonthNumber = " + loopMonth + " AND YearNumber = " + loopYear);

                    double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                    columnChart.Series["Expenses"].Points.Add(amount);

                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(loopMonth);
                    int index = columnChart.Series["Expenses"].Points.Count - 1;
                    columnChart.Series["Expenses"].Points[index].SetCustomProperty("Tooltip", monthName + "\nAmount: " + amount.ToString("N2"));

                    if (amount > maxAmount)
                    {
                        maxAmount = amount; 
                    }
                }
            }

            for (int i = 0; i < columnChart.Series["Expenses"].Points.Count; i++)
            {
                double amount = columnChart.Series["Expenses"].Points[i].YValues[0];
                columnChart.Series["Default"].Points.Add(maxAmount * 1.1 - amount);
            }
        }

        // Generates a column chart displaying weekly expenses
        public void GenerateColumnChartWeek(int accountId, int year, int month, int day, Chart columnChart)
        {
            // SQL query to fetch weekly expenses
            string query_exp = "SELECT ExpDate, SUM(Expenses.ExpAmount) AS TotalAmount " +
                   "FROM Expenses " +
                   "WHERE Expenses.AccId = @SelectedAccId " +
                   "AND Expenses.UserId = @UserId " +
                   "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                   "GROUP BY ExpDate";

            // Create a command to execute the query
            SqlCommand commandExpenses = new SqlCommand(query_exp, dbConnection.GetCon());
            commandExpenses.Parameters.AddWithValue("@SelectedAccId", accountId);
            commandExpenses.Parameters.AddWithValue("@UserId", LoginForm.userId);
            commandExpenses.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Create an adapter to fetch data into a DataTable
            SqlDataAdapter adapterExpenses = new SqlDataAdapter(commandExpenses);
            DataTable dataTableExpenses = new DataTable();
            adapterExpenses.Fill(dataTableExpenses);

            // Clear existing data points in the chart series
            columnChart.Series["Expenses"].Points.Clear();
            columnChart.Series["Default"].Points.Clear();

            double maxAmount = 0;

            DateTime startDate = new DateTime(year, month, day);
            DateTime endDate = currentDate;

            DateTime currentWeekStart = GetWeekStartDate(startDate);
            DateTime currentWeekEnd = currentWeekStart.AddDays(6);

            while (currentWeekStart <= endDate)
            {
                DataRow[] rows = dataTableExpenses.Select("ExpDate >= #" + currentWeekStart.ToString("MM/dd/yyyy") + "# AND ExpDate <= #" + currentWeekEnd.ToString("MM/dd/yyyy") + "#");

                double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                columnChart.Series["Expenses"].Points.Add(amount);

                int index = columnChart.Series["Expenses"].Points.Count - 1;
                columnChart.Series["Expenses"].Points[index].SetCustomProperty("Tooltip", "From: " + currentWeekStart.ToString("dd/MM/yyyy") + "\nTo: " + currentWeekEnd.ToString("dd/MM/yyyy") + "\nAmount: " + amount.ToString("N2"));

                if (amount > maxAmount)
                {
                    maxAmount = amount;
                }

                currentWeekStart = currentWeekEnd.AddDays(1);
                currentWeekEnd = currentWeekStart.AddDays(6);
            }

            for (int i = 0; i < columnChart.Series["Expenses"].Points.Count; i++)
            {
                double amount = columnChart.Series["Expenses"].Points[i].YValues[0];
                columnChart.Series["Default"].Points.Add(maxAmount * 1.1 - amount);
            }

            DateTime GetWeekStartDate(DateTime date)
            {
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                return date.AddDays(-1 * diff).Date;
            }
        }

        // Generates a column chart displaying daily expenses
        public void GenerateColumnChartDay(int accountId, int year, int month, int day, Chart columnChart)
        {
            // SQL query to fetch daily expenses
            string query_exp = "SELECT ExpDate, SUM(Expenses.ExpAmount) AS TotalAmount " +
                   "FROM Expenses " +
                   "WHERE Expenses.AccId = @SelectedAccId " +
                   "AND Expenses.UserId = @UserId " +
                   "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                   "GROUP BY ExpDate";

            // Create a command to execute the query
            SqlCommand commandExpenses = new SqlCommand(query_exp, dbConnection.GetCon());
            commandExpenses.Parameters.AddWithValue("@SelectedAccId", accountId);
            commandExpenses.Parameters.AddWithValue("@UserId", LoginForm.userId);
            commandExpenses.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            // Create an adapter to fetch data into a DataTable
            SqlDataAdapter adapterExpenses = new SqlDataAdapter(commandExpenses);
            DataTable dataTableExpenses = new DataTable();
            adapterExpenses.Fill(dataTableExpenses);

            // Clear existing data points in the chart series
            columnChart.Series["Expenses"].Points.Clear();
            columnChart.Series["Default"].Points.Clear();

            double maxAmount = 0;

            DateTime startDate = new DateTime(year, month, day);
            DateTime endDate = currentDate;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DataRow[] rows = dataTableExpenses.Select("ExpDate = #" + date.ToString("MM/dd/yyyy") + "#");

                double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                columnChart.Series["Expenses"].Points.Add(amount);

                int index = columnChart.Series["Expenses"].Points.Count - 1;
                columnChart.Series["Expenses"].Points[index].SetCustomProperty("Tooltip", date.ToString("dd/MM/yyyy") + "\nAmount: " + amount.ToString("N2"));

                if (amount > maxAmount)
                {
                    maxAmount = amount;
                }
            }

            for (int i = 0; i < columnChart.Series["Expenses"].Points.Count; i++)
            {
                double amount = columnChart.Series["Expenses"].Points[i].YValues[0];
                columnChart.Series["Default"].Points.Add(maxAmount * 1.1 - amount);
            }
        }
    }
}
