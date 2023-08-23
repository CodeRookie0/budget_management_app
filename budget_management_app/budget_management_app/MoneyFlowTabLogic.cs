using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using LiveCharts.WinForms;

namespace budget_management_app
{
    internal class MoneyFlowTabLogic
    {
        private DBConnection dbcon = new DBConnection();
        Timer timer=new Timer();
        private decimal expTotalAmount;
        private decimal currentExpTotalAmount;
        private decimal inTotalAmount;
        private decimal currentInTotalAmount;
        private decimal max_amount = 0;
        private int animationDuration = 40;

        private DateTime currentDate = DateTime.Today;

        public void getMoneyFlowChart(int AccId, int Year, int Month, int Day, Chart expensesChart, Chart incomeChart,Label amountDiffrence,Label amountExpenses,Label amountIncome)
        {
            string query_sum = "SELECT " +
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

            SqlCommand command = new SqlCommand(query_sum, dbcon.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", AccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            expensesChart.Series["Expenses"].Points.Clear();
            expensesChart.Series["Default"].Points.Clear();

            incomeChart.Series["Income"].Points.Clear();
            incomeChart.Series["Default"].Points.Clear();

            expTotalAmount = 0;
            inTotalAmount = 0;

            object expTotalAmountObj = dataTable.Rows[0]["ExpTotalAmount"];
            if (expTotalAmountObj != DBNull.Value)
            {
                expTotalAmount = Convert.ToDecimal(expTotalAmountObj);
            }

            object inTotalAmountObj = dataTable.Rows[0]["InTotalAmount"];
            if (inTotalAmountObj != DBNull.Value)
            {
                inTotalAmount = Convert.ToDecimal(inTotalAmountObj);
            }

            max_amount = Math.Max(expTotalAmount, inTotalAmount);
            decimal diff_in_exp = (inTotalAmount - expTotalAmount);
            amountDiffrence.Text = "";

            if (diff_in_exp >= 0)
            {
                amountDiffrence.Text = "+";
                amountDiffrence.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
            }
            else
            {
                amountDiffrence.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            }

            amountDiffrence.Text += (diff_in_exp).ToString();

            currentExpTotalAmount = 0;
            currentInTotalAmount = 0;

            // Initialize the animation timer
            timer.Tick += (sender, e) => timer_Tick(sender, e, expensesChart,incomeChart);
            timer.Interval = animationDuration;
            timer.Start();

            amountIncome.Text = "+" + inTotalAmount.ToString();
            amountExpenses.Text = "-" + expTotalAmount.ToString();
        }



        public void timer_Tick(object sender, EventArgs e, Chart expensesChart, Chart incomeChart)
        {
            decimal step_exp = expTotalAmount / (decimal)(animationDuration);
            decimal step_in = inTotalAmount / (decimal)(animationDuration);

            if (max_amount == 0)
            {
                max_amount = 1;
                expensesChart.Series["Expenses"].Points.Add(0);
                expensesChart.Series["Default"].Points.Add(Convert.ToDouble(max_amount));
                incomeChart.Series["Income"].Points.Add(0);
                incomeChart.Series["Default"].Points.Add(Convert.ToDouble(max_amount));
            }

            // Update Expenses series
            currentExpTotalAmount += step_exp;
            if (currentExpTotalAmount > expTotalAmount)
                currentExpTotalAmount = expTotalAmount;

            // Update the series data
            expensesChart.Series["Expenses"].Points.Clear();
            expensesChart.Series["Default"].Points.Clear();
            expensesChart.Series["Expenses"].Points.Add(Convert.ToDouble(currentExpTotalAmount));
            expensesChart.Series["Default"].Points.Add(Convert.ToDouble(max_amount - currentExpTotalAmount));

            // Update Income series
            currentInTotalAmount += step_in;
            if (currentInTotalAmount > inTotalAmount)
                currentInTotalAmount = inTotalAmount;

            // Update the series data
            incomeChart.Series["Income"].Points.Clear();
            incomeChart.Series["Default"].Points.Clear();
            incomeChart.Series["Income"].Points.Add(Convert.ToDouble(currentInTotalAmount));
            incomeChart.Series["Default"].Points.Add(Convert.ToDouble(max_amount - currentInTotalAmount));

            // Check if the animation is finished and stop the timer
            if (currentExpTotalAmount >= expTotalAmount && currentInTotalAmount >= inTotalAmount)
            {
                timer.Stop();
            }
        }
        public void getCartesianChart_Month(int AccId, int Year, int Month, int Day, LiveCharts.WinForms.CartesianChart cartesianChart)
        {
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

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", AccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            // Tworzenie serii "Expenses"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F87171")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            // Tworzenie serii "Amount"
            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#34D399")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            int startYear = Year;
            int endYear = currentDate.Year;

            List<string> dates = new List<string>();

            for (int year = startYear; year <= endYear; year++)
            {
                int startMonth = (year == Year) ? Month : 1;
                int endMonth = (year == currentDate.Year) ? currentDate.Month : 12;

                for (int month = startMonth; month <= endMonth; month++)
                {
                    DataRow[] rows = dataTable.Select("MonthNumber = " + month + " AND YearNumber = " + year);
                    dates.Add(new DateTime(year, month, 1).ToString("MMM"));

                    double amount_exp = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                    double amount_in = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                    expensesSeries.Values.Add(amount_exp);
                    incomeSeries.Values.Add(amount_in);
                }
            }

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

        public void getCartesianChart_Week(int AccId, int Year, int Month, int Day, LiveCharts.WinForms.CartesianChart cartesianChart)
        {
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

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", AccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            // Tworzenie serii "Expenses"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F87171")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            // Tworzenie serii "Amount"
            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#34D399")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            DateTime startDate = new DateTime(Year, Month, Day);
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

            DateTime GetWeekStartDate(DateTime date)
            {
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                return date.AddDays(-1 * diff).Date;
            }
        }

        public void getCartesianChart_Day(int AccId, int Year, int Month, int Day, LiveCharts.WinForms.CartesianChart cartesianChart)
        {
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

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            command.Parameters.AddWithValue("@SelectedAccId", AccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(Year, Month, Day));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            // Tworzenie serii "Expenses"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#F87171")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            // Tworzenie serii "Amount"
            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#34D399")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            DateTime startDate = new DateTime(Year,Month, Day);
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
