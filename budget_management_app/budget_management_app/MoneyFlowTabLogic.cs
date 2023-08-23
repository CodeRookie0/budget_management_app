using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace budget_management_app
{
    internal class MoneyFlowTabLogic
    {
        private DBConnection dbConnection = new DBConnection();
        Timer timer=new Timer();

        // Initialize variables to store total amounts and animation values
        private decimal expensesTotalAmount;
        private decimal currentExpensesTotalAmount;
        private decimal incomeTotalAmount;
        private decimal currentIncomeTotalAmount;
        private decimal maxAmount = 0;
        private int animationDuration = 40;

        private DateTime currentDate = DateTime.Today;

        // Update the money flow chart based on selected filters
        public void UpdateMoneyFlowChart(int accountId, int year, int month, int day, Chart expensesChart, Chart incomeChart, Label amountDifference, Label amountExpenses, Label amountIncome)
        {
            // SQL query to calculate total expenses and income within the selected date range
            string sumQuery = "SELECT " +
                   "  (SELECT SUM(ExpAmount) " +
                   "FROM Expenses " +
                   "WHERE AccId = @SelectedAccId " +
                   "AND UserId = @UserId " +
                   "AND ExpDate BETWEEN @StartDate AND GETDATE()) AS ExpTotalAmount, " +
                   "  (SELECT SUM(InAmount) " +
                   "FROM Income " +
                   "WHERE AccId = @SelectedAccId " +
                   "AND UserId = @UserId " +
                   "AND InDate BETWEEN @StartDate AND GETDATE()) AS InTotalAmount";

            SqlCommand command = new SqlCommand(sumQuery, dbConnection.GetCon());
            command.Parameters.AddWithValue("@SelectedAccountId", accountId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Clear existing data points and initialize variables
            expensesChart.Series["Expenses"].Points.Clear();
            expensesChart.Series["Default"].Points.Clear();
            incomeChart.Series["Income"].Points.Clear();
            incomeChart.Series["Default"].Points.Clear();
            expensesTotalAmount = 0;
            incomeTotalAmount = 0;

            // Retrieve and update total expenses and income
            object expTotalAmountObj = dataTable.Rows[0]["ExpTotalAmount"];
            if (expTotalAmountObj != DBNull.Value)
            {
                expensesTotalAmount = Convert.ToDecimal(expTotalAmountObj);
            }

            object inTotalAmountObj = dataTable.Rows[0]["InTotalAmount"];
            if (inTotalAmountObj != DBNull.Value)
            {
                incomeTotalAmount = Convert.ToDecimal(inTotalAmountObj);
            }

            // Calculate the maximum amount and difference between income and expenses
            maxAmount = Math.Max(expensesTotalAmount, incomeTotalAmount);
            decimal diff_in_exp = (incomeTotalAmount - expensesTotalAmount);
            amountDifference.Text = "";

            if (diff_in_exp >= 0)
            {
                amountDifference.Text = "+";
                amountDifference.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
            }
            else
            {
                amountDifference.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            }

            amountDifference.Text += (diff_in_exp).ToString();

            // Initialize current total amounts
            currentExpensesTotalAmount = 0;
            currentIncomeTotalAmount = 0;

            // Attach timer event handler for animation
            timer.Tick += (sender, e) => timer_Tick(sender, e, expensesChart,incomeChart);
            timer.Interval = animationDuration;
            timer.Start();

            // Update labels displaying total income and expenses
            amountIncome.Text = "+" + incomeTotalAmount.ToString();
            amountExpenses.Text = "-" + expensesTotalAmount.ToString();
        }

        // Timer tick event for animation
        public void timer_Tick(object sender, EventArgs e, Chart expensesChart, Chart incomeChart)
        {
            // Calculate step values for the animation
            decimal stepExpenses = expensesTotalAmount / (decimal)(animationDuration);
            decimal stepIncome = incomeTotalAmount / (decimal)(animationDuration);

            // Initialize chart series if maxAmount is 0
            if (maxAmount == 0)
            {
                maxAmount = 1;
                expensesChart.Series["Expenses"].Points.Add(0);
                expensesChart.Series["Default"].Points.Add(Convert.ToDouble(maxAmount));
                incomeChart.Series["Income"].Points.Add(0);
                incomeChart.Series["Default"].Points.Add(Convert.ToDouble(maxAmount));
            }

            // Update Expenses series
            currentExpensesTotalAmount += stepExpenses;
            if (currentExpensesTotalAmount > expensesTotalAmount)
                currentExpensesTotalAmount = expensesTotalAmount;

            // Update the series data
            expensesChart.Series["Expenses"].Points.Clear();
            expensesChart.Series["Default"].Points.Clear();
            expensesChart.Series["Expenses"].Points.Add(Convert.ToDouble(currentExpensesTotalAmount));
            expensesChart.Series["Default"].Points.Add(Convert.ToDouble(maxAmount - currentExpensesTotalAmount));

            // Update Income series
            currentIncomeTotalAmount += stepIncome;
            if (currentIncomeTotalAmount > incomeTotalAmount)
                currentIncomeTotalAmount = incomeTotalAmount;

            // Update the series data
            incomeChart.Series["Income"].Points.Clear();
            incomeChart.Series["Default"].Points.Clear();
            incomeChart.Series["Income"].Points.Add(Convert.ToDouble(currentIncomeTotalAmount));
            incomeChart.Series["Default"].Points.Add(Convert.ToDouble(maxAmount - currentIncomeTotalAmount));

            // Check if the animation is finished and stop the timer
            if (currentExpensesTotalAmount >= expensesTotalAmount && currentIncomeTotalAmount >= incomeTotalAmount)
            {
                timer.Stop();
            }
        }

        // Update the Cartesian chart for the selected month
        public void UpdateCartesianChartMonth(int accountId, int year, int month, int day, LiveCharts.WinForms.CartesianChart cartesianChart)
        {
            // SQL query to retrieve total expenses and income for each month
            string query = "SELECT " +
                "  DATEPART(MONTH, Date) AS MonthNumber, " +
                "  DATEPART(YEAR, Date) AS YearNumber, " +
                "SUM(ExpAmount) AS TotalExpenses, " +
                "SUM(InAmount) AS TotalIncome " +
                "FROM ( " +
                "    SELECT ExpDate AS Date, ExpAmount, NULL AS InAmount " +
                "    FROM Expenses " +
                "    WHERE Expenses.AccId = @SelectedAccId " +
                "    AND Expenses.UserId = @UserId " +
                "    AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                "    UNION ALL " +
                "    SELECT InDate AS Date, NULL AS ExpAmount, InAmount " +
                "    FROM Income " +
                "    WHERE Income.AccId = @SelectedAccId " +
                "    AND Income.UserId = @UserId " +
                "    AND Income.InDate BETWEEN @StartDate AND GETDATE() " +
                ") AS CombinedData " +
                " GROUP BY DATEPART(MONTH, Date), DATEPART(YEAR, Date) ";

            SqlCommand command = new SqlCommand(query, dbConnection.GetCon());
            command.Parameters.AddWithValue("@SelectedAccountId", accountId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Clear existing series and axes
            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            // Create series for "Expenses" and "Income"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F87171")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#34D399")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            // Calculate data for each month and add to series
            int startYear = year;
            int endYear = currentDate.Year;

            List<string> dates = new List<string>();

            for (int currentYear = startYear; currentYear <= endYear; currentYear++)
            {
                int startMonth = (currentYear == year) ? month : 1;
                int endMonth = (currentYear == currentDate.Year) ? currentDate.Month : 12;

                for (int currentMonth = startMonth; currentMonth <= endMonth; currentMonth++)
                {
                    DataRow[] rows = dataTable.Select("MonthNumber = " + currentMonth + " AND YearNumber = " + currentYear);
                    dates.Add(new DateTime(currentYear, currentMonth, 1).ToString("MMM"));

                    double amountExpenses = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                    double amountIncome = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                    expensesSeries.Values.Add(amountExpenses);
                    incomeSeries.Values.Add(amountIncome);
                }
            }

            // Configure X and Y axes and add series to the chart
            cartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                Labels = dates,
                LabelsRotation = 45,
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13,
                Separator = new LiveCharts.Wpf.Separator { Step = 1 }
            });
            cartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelFormatter = value => value.ToString(),
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13,
                MinValue = 0,
            });

            cartesianChart.Series.Add(expensesSeries);
            cartesianChart.Series.Add(incomeSeries);
        }

        // Update the Cartesian chart for the selected week
        public void UpdateCartesianChartWeek(int accountId, int year, int month, int day, LiveCharts.WinForms.CartesianChart cartesianChart)
        {
            // SQL query to retrieve total expenses and income for each day in the selected week
            string query = "SELECT Date, " +
                "SUM(ExpAmount) AS TotalExpenses, " +
                "SUM(InAmount) AS TotalIncome " +
                "FROM ( " +
                "    SELECT ExpDate AS Date, ExpAmount, NULL AS InAmount " +
                "    FROM Expenses " +
                "    WHERE Expenses.AccId = @SelectedAccId " +
                "    AND Expenses.UserId = @UserId " +
                "    AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                "    UNION ALL " +
                "    SELECT InDate AS Date, NULL AS ExpAmount, InAmount " +
                "    FROM Income " +
                "    WHERE Income.AccId = @SelectedAccId " +
                "    AND Income.UserId = @UserId " +
                "    AND Income.InDate BETWEEN @StartDate AND GETDATE() " +
                ") AS CombinedData " +
                "GROUP BY Date ";

            SqlCommand command = new SqlCommand(query, dbConnection.GetCon());
            command.Parameters.AddWithValue("@SelectedAccountId", accountId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Clear existing series and axes
            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            // Create series for "Expenses" and "Income"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F87171")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#34D399")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            // Calculate data for each day in the selected week and add to series
            DateTime startDate = new DateTime(year, month, day);
            DateTime endDate = currentDate;

            DateTime currentWeekStart = GetWeekStartDate(startDate);
            DateTime currentWeekEnd = currentWeekStart.AddDays(6);

            List<string> dates = new List<string>();

            while (currentWeekStart <= endDate)
            {
                DataRow[] rows = dataTable.Select("Date >= #" + currentWeekStart.ToString("MM/dd/yyyy") + "# AND Date <= #" + currentWeekEnd.ToString("MM/dd/yyyy") + "#");
                dates.Add(currentWeekStart.ToString("d.MM") + "-" + currentWeekEnd.ToString("d.MM"));

                double amount_exp = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                double amount_in = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                expensesSeries.Values.Add(amount_exp);
                incomeSeries.Values.Add(amount_in);

                currentWeekStart = currentWeekEnd.AddDays(1);
                currentWeekEnd = currentWeekStart.AddDays(6);
            }

            // Configure X and Y axes and add series to the chart
            cartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                Labels = dates,
                MinValue = 0,
                MaxValue = 12,
                LabelsRotation = 45,
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13,
            });
            cartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelFormatter = value => value.ToString(),
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13,
                MinValue = 0,
            });

            cartesianChart.Series.Add(expensesSeries);
            cartesianChart.Series.Add(incomeSeries);

            // Helper function to calculate the start date of the week for a given date
            DateTime GetWeekStartDate(DateTime date)
            {
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                return date.AddDays(-1 * diff).Date;
            }
        }

        // Update the Cartesian chart for the selected day
        public void UpdateCartesianChartDay(int accountId, int year, int month, int day, LiveCharts.WinForms.CartesianChart cartesianChart)
        {
            // SQL query to retrieve total expenses and income for the selected day
            string query = "SELECT Date, " +
                "SUM(ExpAmount) AS TotalExpenses, " +
                "SUM(InAmount) AS TotalIncome " +
                "FROM ( " +
                "    SELECT ExpDate AS Date, ExpAmount, NULL AS InAmount " +
                "    FROM Expenses " +
                "    WHERE Expenses.AccId = @SelectedAccId " +
                "    AND Expenses.UserId = @UserId " +
                "    AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                "    UNION ALL " +
                "    SELECT InDate AS Date, NULL AS ExpAmount, InAmount " +
                "    FROM Income " +
                "    WHERE Income.AccId = @SelectedAccId " +
                "    AND Income.UserId = @UserId " +
                "    AND Income.InDate BETWEEN @StartDate AND GETDATE() " +
                ") AS CombinedData " +
                "GROUP BY Date ";

            SqlCommand command = new SqlCommand(query, dbConnection.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", accountId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(year, month, day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Clear existing series and axes
            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            // Create series for "Expenses" and "Income"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F87171")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#34D399")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            // Calculate data for each day and add to series
            DateTime startDate = new DateTime(year, month, day);
            DateTime endDate = currentDate;

            List<string> dates = new List<string>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DataRow[] rows = dataTable.Select("Date = #" + date.ToString("MM/dd/yyyy") + "#");
                dates.Add(date.ToString("d.MMM"));

                double amount_exp = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                double amount_in = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                expensesSeries.Values.Add(amount_exp);
                incomeSeries.Values.Add(amount_in);
            }

            // Configure X and Y axes and add series to the chart
            cartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                Labels = dates,
                LabelsRotation = 45,
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13,
            });
            cartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelFormatter = value => value.ToString(),
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13,
                MinValue = 0,
            });

            cartesianChart.Series.Add(expensesSeries);
            cartesianChart.Series.Add(incomeSeries);
        }
    }
}
