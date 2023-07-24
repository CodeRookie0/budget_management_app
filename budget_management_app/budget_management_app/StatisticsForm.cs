using LiveCharts.Wpf;
using LiveCharts;
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
using System.Runtime.InteropServices.ComTypes;
using System.Management;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Timers;
using System.Windows.Threading;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using LiveCharts.Definitions.Charts;
using System.Windows.Media;
using System.Windows;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace budget_management_app
{
    public partial class StatisticsForm : Form
    {

        private DBConnection dbcon = new DBConnection();
        private bool bottombarExpand;
        private int selectedAccId;
        private DateTime currentDate = DateTime.Today;
        private static int selectedDay;
        private static int selectedMonth;
        private static int selectedYear;

        private decimal expTotalAmount;
        private decimal currentExpTotalAmount;
        private decimal inTotalAmount;
        private decimal currentInTotalAmount;
        private decimal max_amount = 0;
        private int animationDuration = 40;

        public StatisticsForm()
        {
            InitializeComponent();

            getAcc();
            comboBox_account.SelectedIndex = 0;
            getSelectedAcc();

            DateTime startDateTime = currentDate.AddMonths(-2);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            UpdateSelectedDate(1, startMonth, startYear);

            DataGridView_7High_exp.Columns[1].Width = 100;
            DataGridView_7High_exp.Columns[2].Width = 90;

        }
        private void label_exit_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = System.Drawing.Color.FromArgb(212, 148, 85);
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = System.Drawing.Color.White;
        }

        private void UpdateSelectedDate(int startDay, int startMonth, int startYear)
        {

            selectedDay = startDay;
            selectedMonth = startMonth;
            selectedYear = startYear;

            if (selectedMonth < 1)
            {
                selectedMonth += 12;
                selectedYear--;
            }
            else if (selectedMonth > 12)
            {
                selectedMonth -= 12;
                selectedYear++;
            }

            int daysInSelectedMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            if (selectedDay > daysInSelectedMonth)
            {
                selectedDay = daysInSelectedMonth;
            }

            label_exp_from_date.Text = selectedDay.ToString() + "." + selectedMonth.ToString() + "." + selectedYear.ToString();
            UpdateCharts();
        }
        private void UpdateCharts()
        {
            getPieChart();
            getHighestExpensees();

            DateTime selectedDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime currentDate = DateTime.Today;
            int daysDifference = (currentDate - selectedDate).Days;

            if (daysDifference > 123)
            {
                getColumnChart_Month();
                getCashFlow_Month();
                getCartesianChart_Month();
            }
            else if (daysDifference > 31 && daysDifference <= 123)
            {
                getColumnChart_Week();
                getCashFlow_Week();
                getCartesianChart_Week();
            }
            else
            {
                getColumnChart_Day();
                getCashFlow_Day();
                getCartesianChart_Day();
            }

            getMoneyFlowChart();
            getRaportMf();
            label_raport_ledger.Text = label_raport_mf.Text;
            getRaportExp();
            getRaportIn();
        }

        private void button_7D_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-6);
            int startDay = startDateTime.Day;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 7 DAYS";
            label_last_X_cf.Text = "LAST 7 DAYS";
            label_last_X_mf.Text = "LAST 7 DAYS";
            label_last_X_raport_mf.Text = "LAST 7 DAYS";
            label_last_X_raport_ledger.Text = "LAST 7 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);
            getColumnChart_Day();
            getCashFlow_Day();
        }

        private void button_30D_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-30);
            int startDay = startDateTime.Day;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 30 DAYS";
            label_last_X_cf.Text = "LAST 30 DAYS";
            label_last_X_mf.Text = "LAST 30 DAYS";
            label_last_X_raport_mf.Text = "LAST 30 DAYS";
            label_last_X_raport_ledger.Text = "LAST 30 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);
            getColumnChart_Day();
            getCashFlow_Day();
        }

        private void button_12W_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-2);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 3 MONTH";
            label_last_X_cf.Text = "LAST 3 MONTH";
            label_last_X_mf.Text = "LAST 3 MONTH";
            label_last_X_raport_mf.Text = "LAST 3 MONTH";
            label_last_X_raport_ledger.Text = "LAST 3 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);
            getColumnChart_Week();
            getCashFlow_Week();
        }

        private void button_6M_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-5);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 6 MONTH";
            label_last_X_cf.Text = "LAST 6 MONTH";
            label_last_X_mf.Text = "LAST 6 MONTH";
            label_last_X_raport_mf.Text = "LAST 6 MONTH";
            label_last_X_raport_ledger.Text = "LAST 6 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);
            getColumnChart_Month();
            getCashFlow_Month();
        }

        private void button_1Y_Click(object sender, EventArgs e)
        {
            label_exp_last_X.Text = "LAST 12 MONTH";
            label_last_X_cf.Text = "LAST 12 MONTH";
            label_last_X_mf.Text = "LAST 12 MONTH";
            label_last_X_raport_mf.Text = "LAST 12 MONTH";
            label_last_X_raport_ledger.Text = "LAST 12 MONTH";
            UpdateSelectedDate(1, 1, currentDate.Year);
            getColumnChart_Month();
            getCashFlow_Month();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_bottomBar.Size = new System.Drawing.Size(50, 40);
            pictureBox_bottomBar.Location = new System.Drawing.Point(191, -9);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_bottomBar.Size = new System.Drawing.Size(50, 31);
            pictureBox_bottomBar.Location = new System.Drawing.Point(191, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer_bottomBar.Start();
        }

        private void timer_bottomBar_Tick(object sender, EventArgs e)
        {
            if (bottombarExpand)
            {
                panel_bottomBar.Location = new System.Drawing.Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y + 10);
                panel_bottomBar.Height -= 10;
                if (panel_bottomBar.Height == panel_bottomBar.MinimumSize.Height)
                {
                    bottombarExpand = false;
                    timer_bottomBar.Stop();
                }
            }
            else
            {
                panel_bottomBar.Location = new System.Drawing.Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y - 10);
                panel_bottomBar.Height += 10;
                if (panel_bottomBar.Height == panel_bottomBar.MaximumSize.Height)
                {
                    bottombarExpand = true;
                    timer_bottomBar.Stop();
                }
            }
        }

        // Retrieving data on existing accounts for combo_box_account
        private void getAcc()
        {
            string selectQuery = "SELECT AccName FROM Account WHERE UserId = " + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                comboBox_account.Items.Add(data.Trim());
            }
            reader.Close();
            dbcon.CloseCon();
        }

        private void getSelectedAcc()
        {
            string selectQuery = "SELECT AccId FROM Account WHERE AccName ='" + comboBox_account.SelectedItem.ToString() + "' AND UserId=" + LoginForm.userId;
            SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            object result = comm.ExecuteScalar();
            if (result != null)
            {
                selectedAccId = Convert.ToInt32(result);
            }
            dbcon.CloseCon();
        }

        private void comboBox_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_account.SelectedItem != null)
            {
                getSelectedAcc();
                DateTime startDateTime = currentDate.AddMonths(-2);
                int startMonth = startDateTime.Month;
                int startYear = startDateTime.Year;
                UpdateSelectedDate(1, startMonth, startYear);
            }
        }

        private void getPieChart()
        {
            string query_exp = "SELECT Category.CatName, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "JOIN Category ON Expenses.CatId = Category.CatId " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY Category.CatName";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));


            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            chart_exp_cat.Series.Clear();

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
                        LabelPoint = point => $"{point.Participation:P}"
                    };

                    chart_exp_cat.Series.Add(dataPoint);
                    chart_exp_cat.LegendLocation = LegendLocation.Bottom;
                }
            }
        }
        private void getHighestExpensees()
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
               "WHERE Expenses.AccId = " + selectedAccId +
               " AND Expenses.UserId = " + LoginForm.userId +
               " AND Expenses.ExpDate BETWEEN '" + selectedYear + "-" + selectedMonth + "-" + selectedDay +
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
            DataGridView_7High_exp.DataSource = table;
            dbcon.CloseCon();
        }
        private void getColumnChart_Month()
        {
            string query_exp = "SELECT DATEPART(MONTH, ExpDate) AS MonthNumber, DATEPART(YEAR, ExpDate) AS YearNumber, SUM(Expenses.ExpAmount) AS TotalAmount " +
               "FROM Expenses " +
               "WHERE Expenses.AccId = @SelectedAccId " +
               "AND Expenses.UserId = @UserId " +
               "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
               "GROUP BY DATEPART(MONTH, ExpDate), DATEPART(YEAR, ExpDate)";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            chart_exp_column.Series["Expenses"].Points.Clear();
            chart_exp_column.Series["Default"].Points.Clear();

            double max_amount = 0;

            int startYear = selectedYear;
            int endYear = currentDate.Year;

            for (int year = startYear; year <= endYear; year++)
            {
                int startMonth = (year == selectedYear) ? selectedMonth : 1;
                int endMonth = (year == currentDate.Year) ? currentDate.Month : 12;

                for (int month = startMonth; month <= endMonth; month++)
                {
                    DataRow[] rows = dataTable_exp.Select("MonthNumber = " + month + " AND YearNumber = " + year);

                    double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                    chart_exp_column.Series["Expenses"].Points.Add(amount);

                    if (amount > max_amount)
                    {
                        max_amount = amount;
                    }
                }
            }

            for (int i = 0; i < chart_exp_column.Series["Expenses"].Points.Count; i++)
            {
                double amount = chart_exp_column.Series["Expenses"].Points[i].YValues[0];
                chart_exp_column.Series["Default"].Points.Add(max_amount * 1.1 - amount);
            }
        }
        private void getColumnChart_Week()
        {
            string query_exp = "SELECT ExpDate, SUM(Expenses.ExpAmount) AS TotalAmount " +
                   "FROM Expenses " +
                   "WHERE Expenses.AccId = @SelectedAccId " +
                   "AND Expenses.UserId = @UserId " +
                   "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                   "GROUP BY ExpDate";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            chart_exp_column.Series["Expenses"].Points.Clear();
            chart_exp_column.Series["Default"].Points.Clear();

            double max_amount = 0;

            DateTime startDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime endDate = currentDate;

            DateTime currentWeekStart = GetWeekStartDate(startDate);
            DateTime currentWeekEnd = currentWeekStart.AddDays(6);

            while (currentWeekStart <= endDate)
            {
                DataRow[] rows = dataTable_exp.Select("ExpDate >= #" + currentWeekStart.ToString("MM/dd/yyyy") + "# AND ExpDate <= #" + currentWeekEnd.ToString("MM/dd/yyyy") + "#");

                double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                chart_exp_column.Series["Expenses"].Points.Add(amount);

                if (amount > max_amount)
                {
                    max_amount = amount;
                }

                currentWeekStart = currentWeekEnd.AddDays(1);
                currentWeekEnd = currentWeekStart.AddDays(6);
            }

            for (int i = 0; i < chart_exp_column.Series["Expenses"].Points.Count; i++)
            {
                double amount = chart_exp_column.Series["Expenses"].Points[i].YValues[0];
                chart_exp_column.Series["Default"].Points.Add(max_amount * 1.1 - amount);
            }

            DateTime GetWeekStartDate(DateTime date)
            {
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                return date.AddDays(-1 * diff).Date;
            }
        }
        private void getColumnChart_Day()
        {
            string query_exp = "SELECT ExpDate, SUM(Expenses.ExpAmount) AS TotalAmount " +
                   "FROM Expenses " +
                   "WHERE Expenses.AccId = @SelectedAccId " +
                   "AND Expenses.UserId = @UserId " +
                   "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                   "GROUP BY ExpDate";

            SqlCommand command_exp = new SqlCommand(query_exp, dbcon.GetCon());
            command_exp.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_exp.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);
            DataTable dataTable_exp = new DataTable();
            adapter_exp.Fill(dataTable_exp);

            chart_exp_column.Series["Expenses"].Points.Clear();
            chart_exp_column.Series["Default"].Points.Clear();

            double max_amount = 0;

            DateTime startDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime endDate = currentDate;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DataRow[] rows = dataTable_exp.Select("ExpDate = #" + date.ToString("MM/dd/yyyy") + "#");

                double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;
                chart_exp_column.Series["Expenses"].Points.Add(amount);

                if (amount > max_amount)
                {
                    max_amount = amount;
                }
            }

            for (int i = 0; i < chart_exp_column.Series["Expenses"].Points.Count; i++)
            {
                double amount = chart_exp_column.Series["Expenses"].Points[i].YValues[0];
                chart_exp_column.Series["Default"].Points.Add(max_amount * 1.1 - amount);
            }
        }

        private void getMoneyFlowChart()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            chart_exp_mf.Series["Expenses"].Points.Clear();
            chart_exp_mf.Series["Default"].Points.Clear();

            chart_in_mf.Series["Income"].Points.Clear();
            chart_in_mf.Series["Default"].Points.Clear();

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
            label_amount_diff_mf.Text = "";

            if (diff_in_exp >= 0)
            {
                label_amount_diff_mf.Text = "+";
                label_amount_diff_mf.ForeColor = System.Drawing.Color.FromArgb(138, 201, 38);
            }
            else
            {
                label_amount_diff_mf.ForeColor = System.Drawing.Color.Red;
            }

            label_amount_diff_mf.Text += (diff_in_exp).ToString();

            currentExpTotalAmount = 0;
            currentInTotalAmount = 0;

            // Initialize the animation timer
            timer_mf.Tick += timer_mf_Tick;
            timer_mf.Interval = animationDuration;
            timer_mf.Start();

            label_in_amount_mf.Text = "+" + inTotalAmount.ToString();
            label_exp_amount_mf.Text = "-" + expTotalAmount.ToString();
        }



        private void timer_mf_Tick(object sender, EventArgs e)
        {
            decimal step_exp = expTotalAmount / (decimal)(animationDuration);
            decimal step_in = inTotalAmount / (decimal)(animationDuration);

            if (max_amount == 0)
            {
                max_amount = 1;
                chart_exp_mf.Series["Expenses"].Points.Add(0);
                chart_exp_mf.Series["Default"].Points.Add(Convert.ToDouble(max_amount));
                chart_in_mf.Series["Income"].Points.Add(0);
                chart_in_mf.Series["Default"].Points.Add(Convert.ToDouble(max_amount));
            }

            // Update Expenses series
            currentExpTotalAmount += step_exp;
            if (currentExpTotalAmount > expTotalAmount)
                currentExpTotalAmount = expTotalAmount;

            // Update the series data
            chart_exp_mf.Series["Expenses"].Points.Clear();
            chart_exp_mf.Series["Default"].Points.Clear();
            chart_exp_mf.Series["Expenses"].Points.Add(Convert.ToDouble(currentExpTotalAmount));
            chart_exp_mf.Series["Default"].Points.Add(Convert.ToDouble(max_amount - currentExpTotalAmount));

            // Update Income series
            currentInTotalAmount += step_in;
            if (currentInTotalAmount > inTotalAmount)
                currentInTotalAmount = inTotalAmount;

            // Update the series data
            chart_in_mf.Series["Income"].Points.Clear();
            chart_in_mf.Series["Default"].Points.Clear();
            chart_in_mf.Series["Income"].Points.Add(Convert.ToDouble(currentInTotalAmount));
            chart_in_mf.Series["Default"].Points.Add(Convert.ToDouble(max_amount - currentInTotalAmount));

            // Check if the animation is finished and stop the timer
            if (currentExpTotalAmount >= expTotalAmount && currentInTotalAmount >= inTotalAmount)
            {
                timer_mf.Stop();
            }
        }
        private void getCashFlow_Month()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (var series in chart_cash_flow.Series)
            {
                series.Points.Clear();
            }

            double max_exp = 0;
            double max_in = 0;

            int startYear = selectedYear;
            int endYear = currentDate.Year;

            for (int year = startYear; year <= endYear; year++)
            {
                int startMonth = (year == selectedYear) ? selectedMonth : 1;
                int endMonth = (year == currentDate.Year) ? currentDate.Month : 12;

                for (int month = startMonth; month <= endMonth; month++)
                {
                    DataRow[] rows = dataTable.Select("MonthNumber = " + month + " AND YearNumber = " + year);

                    double amount_exp = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                    double amount_in = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                    chart_cash_flow.Series["Expenses"].Points.Add(-amount_exp);
                    chart_cash_flow.Series["Income"].Points.Add(amount_in);
                    

                    if (amount_exp > max_exp)
                    {
                        max_exp = amount_exp;
                    }
                    if (amount_in > max_in)
                    {
                        max_in = amount_in;
                    }
                }
            }

            for (int i = 0; i < chart_cash_flow.Series["Expenses"].Points.Count; i++)
            {
                double amount_exp = chart_cash_flow.Series["Expenses"].Points[i].YValues[0];
                double amount_in = chart_cash_flow.Series["Income"].Points[i].YValues[0];
                chart_cash_flow.Series["Default_down"].Points.Add(-max_exp *1.1-amount_exp);
                chart_cash_flow.Series["Default_up"].Points.Add(max_in * 1.1-amount_in);
                double money_flow = amount_in + amount_exp;
                chart_cash_flow.Series["Money_flow"].Points.Add(money_flow);
            }
        }
        private void getCashFlow_Week()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (var series in chart_cash_flow.Series)
            {
                series.Points.Clear();
            }

            double max_exp = 0;
            double max_in = 0;

            DateTime startDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime endDate = currentDate;

            DateTime currentWeekStart = GetWeekStartDate(startDate);
            DateTime currentWeekEnd = currentWeekStart.AddDays(6);

            while (currentWeekStart <= endDate)
            {
                DataRow[] rows = dataTable.Select("Date >= #" + currentWeekStart.ToString("MM/dd/yyyy") + "# AND Date <= #" + currentWeekEnd.ToString("MM/dd/yyyy") + "#");

                double amount_exp = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                double amount_in = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                chart_cash_flow.Series["Expenses"].Points.Add(-amount_exp);
                chart_cash_flow.Series["Income"].Points.Add(amount_in);

                if (amount_exp > max_exp)
                {
                    max_exp = amount_exp;
                }
                if (amount_in > max_in)
                {
                    max_in = amount_in;
                }

                currentWeekStart = currentWeekEnd.AddDays(1);
                currentWeekEnd = currentWeekStart.AddDays(6);
            }

            for (int i = 0; i < chart_cash_flow.Series["Expenses"].Points.Count; i++)
            {
                double amount_exp = chart_cash_flow.Series["Expenses"].Points[i].YValues[0];
                double amount_in = chart_cash_flow.Series["Income"].Points[i].YValues[0];
                chart_cash_flow.Series["Default_down"].Points.Add(-max_exp * 1.1 - amount_exp);
                chart_cash_flow.Series["Default_up"].Points.Add(max_in * 1.1 - amount_in);

                double money_flow = amount_in + amount_exp;
                chart_cash_flow.Series["Money_flow"].Points.Add(money_flow);
            }

            DateTime GetWeekStartDate(DateTime date)
            {
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                return date.AddDays(-1 * diff).Date;
            }
        }
        private void getCashFlow_Day()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (var series in chart_cash_flow.Series)
            {
                series.Points.Clear();
            }

            double max_exp = 0;
            double max_in = 0;

            DateTime startDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime endDate = currentDate;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DataRow[] rows = dataTable.Select("Date = #" + date.ToString("MM/dd/yyyy") + "#");

                double amount_exp = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                double amount_in = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                chart_cash_flow.Series["Expenses"].Points.Add(-amount_exp);
                chart_cash_flow.Series["Income"].Points.Add(amount_in);

                if (amount_exp > max_exp)
                {
                    max_exp = amount_exp;
                }
                if (amount_in > max_in)
                {
                    max_in = amount_in;
                }
            }

            for (int i = 0; i < chart_cash_flow.Series["Expenses"].Points.Count; i++)
            {
                double amount_exp = chart_cash_flow.Series["Expenses"].Points[i].YValues[0];
                double amount_in = chart_cash_flow.Series["Income"].Points[i].YValues[0];
                if (max_exp == 0)
                {
                    max_exp = 100;
                }
                if (max_in == 0)
                {
                    max_in = 100;
                }
                
                chart_cash_flow.Series["Default_down"].Points.Add(-max_exp * 1.1 - amount_exp);
                chart_cash_flow.Series["Default_up"].Points.Add(max_in * 1.1 - amount_in);


                double money_flow = amount_in + amount_exp;
                chart_cash_flow.Series["Money_flow"].Points.Add(money_flow);
            }
        }

        private void getCartesianChart_Month()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            // Tworzenie serii "Expenses"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#B2FF0000")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            // Tworzenie serii "Amount"
            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#B33CB666")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            int startYear = selectedYear;
            int endYear = currentDate.Year;

            List<string> dates = new List<string>();

            for (int year = startYear; year <= endYear; year++)
            {
                int startMonth = (year == selectedYear) ? selectedMonth : 1;
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

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                Labels = dates,
                LabelsRotation = 45,
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13,
                Separator = new LiveCharts.Wpf.Separator { Step = 1 }
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelFormatter = value => value.ToString(),
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13
            });

            cartesianChart1.Series.Add(expensesSeries);
            cartesianChart1.Series.Add(incomeSeries);
        }

        private void getCartesianChart_Week()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            // Tworzenie serii "Expenses"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#B2FF0000")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            // Tworzenie serii "Amount"
            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#B33CB666")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))

            };

            DateTime startDate = new DateTime(selectedYear, selectedMonth, selectedDay);
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

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
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
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelFormatter = value => value.ToString(),
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13
            });

            cartesianChart1.Series.Add(expensesSeries);
            cartesianChart1.Series.Add(incomeSeries);

            DateTime GetWeekStartDate(DateTime date)
            {
                int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
                return date.AddDays(-1 * diff).Date;
            }
        }

        private void getCartesianChart_Day()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            // Tworzenie serii "Expenses"
            LineSeries expensesSeries = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Circle,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#B2FF0000")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#40D29191"))
            };

            // Tworzenie serii "Amount"
            LineSeries incomeSeries = new LineSeries
            {
                Title = "Income",
                Values = new ChartValues<double>(),
                PointGeometry = DefaultGeometries.Diamond,
                Stroke = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#B33CB666")),
                Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#408DC499"))
                
            };

            DateTime startDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime endDate = currentDate;

            List<string> dates = new List<string>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DataRow[] rows = dataTable.Select("Date = #" + date.ToString("MM/dd/yyyy") + "#");
                dates.Add(date.ToString("d.MM"));

                double amount_exp = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalExpenses"]) ? Convert.ToDouble(rows[0]["TotalExpenses"]) : 0;
                double amount_in = rows.Length > 0 && !Convert.IsDBNull(rows[0]["TotalIncome"]) ? Convert.ToDouble(rows[0]["TotalIncome"]) : 0;
                expensesSeries.Values.Add(amount_exp);
                incomeSeries.Values.Add(amount_in);
            }

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                Labels = dates,
                LabelsRotation = 45,
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal, 
                FontSize = 13,
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelFormatter = value => value.ToString(),
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Normal,
                FontSize = 13
            });

            cartesianChart1.Series.Add(expensesSeries);
            cartesianChart1.Series.Add(incomeSeries);
        }

        private void getRaportMf()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DataGridView_raport_mf.Rows.Clear();

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


            DataGridView_raport_mf.Rows.Add("Number", num_income, num_exp);
            DataGridView_raport_mf.Rows[0].DefaultCellStyle.BackColor= System.Drawing.Color.FromArgb(255, 245, 245, 245);
            DataGridView_raport_mf.Rows[0].DefaultCellStyle.SelectionBackColor= System.Drawing.Color.FromArgb(255, 245, 245, 245);
            DataGridView_raport_mf.Rows.Add("Average/Day","+"+Math.Round(income / days, 2), Math.Round(-exp / days,2));
            DataGridView_raport_mf.Rows.Add("Average/Entry", "+" + Math.Round(income / num_income, 2), Math.Round(-exp / num_exp, 2));
            DataGridView_raport_mf.Rows[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            DataGridView_raport_mf.Rows[2].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 245, 245);
            DataGridView_raport_mf.Rows.Add("Total", "+" + income, -exp);

            if (income - exp > 0)
            {
                label_raport_mf.Text = "+"+(income - exp).ToString();
            }
            else
            {
                label_raport_mf.Text = (income - exp).ToString();
            }
            

            DataGridView_raport_mf.ClearSelection();
            DataGridView_raport_mf.ColumnHeadersDefaultCellStyle.Font= new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dbcon.CloseCon();
        }

        private void getRaportExp()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

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
            command_cat.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command_cat.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_cat.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter_cat = new SqlDataAdapter(command_cat);
            DataTable dataTable_cat = new DataTable();
            adapter_cat.Fill(dataTable_cat);

            DataGridView_raport_exp.Rows.Clear();

            double totalAmount = 0;

            foreach (DataRow row_cat in dataTable_cat.Rows)
            {
                string catName = row_cat["CatName"].ToString().Trim();
                double catAmount = -(row_cat["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row_cat["TotalAmount"]) : 0);
                DataGridView_raport_exp.Rows.Add(catName,catAmount.ToString());

                foreach (DataRow row in dataTable.Rows)
                {
                    if(row["CatName"].ToString().Trim() == catName)
                    {
                        string subName = "          "+row["SubName"].ToString().Trim();
                        double subAmount = -(row["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row["TotalAmount"]) : 0);
                        DataGridView_raport_exp.Rows.Add(subName, "            " + subAmount);
                        int rowIndex = DataGridView_raport_exp.Rows.Count - 1;
                        DataGridView_raport_exp.Rows[rowIndex].Cells[0].Style.Font =new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                        DataGridView_raport_exp.Rows[rowIndex].Cells[1].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular);
                        DataGridView_raport_exp.Rows[rowIndex].Cells[0].Style.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                totalAmount += catAmount;
            }

            label_raport_total_exp.Text = totalAmount.ToString();
        }

        private void getRaportIn()
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
            command.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

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
            command_cat.Parameters.AddWithValue("@SelectedAccId", selectedAccId);
            command_cat.Parameters.AddWithValue("@UserId", LoginForm.userId);
            command_cat.Parameters.AddWithValue("@StartDate", new DateTime(selectedYear, selectedMonth, selectedDay));

            SqlDataAdapter adapter_cat = new SqlDataAdapter(command_cat);
            DataTable dataTable_cat = new DataTable();
            adapter_cat.Fill(dataTable_cat);

            DataGridView_raport_in.Rows.Clear();

            double totalAmount = 0;

            foreach (DataRow row_cat in dataTable_cat.Rows)
            {
                string catName = row_cat["CatName"].ToString().Trim();
                double catAmount = row_cat["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row_cat["TotalAmount"]) : 0;
                DataGridView_raport_in.Rows.Add(catName, "+"+catAmount.ToString());

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["CatName"].ToString().Trim() == catName)
                    {
                        string subName = "          " + row["SubName"].ToString().Trim();
                        double subAmount = row["TotalAmount"] != DBNull.Value ? Convert.ToDouble(row["TotalAmount"]) : 0;
                        DataGridView_raport_in.Rows.Add(subName, "            " + "+" + subAmount);
                        int rowIndex = DataGridView_raport_in.Rows.Count - 1;
                        DataGridView_raport_in.Rows[rowIndex].Cells[0].Style.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                        DataGridView_raport_in.Rows[rowIndex].Cells[1].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular);
                        DataGridView_raport_in.Rows[rowIndex].Cells[0].Style.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                totalAmount += catAmount;
            }

            label_raport_total_in.Text = "+" + totalAmount.ToString();
        }

        private void printMf()
        {
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "Report.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        PdfWriter.GetInstance(doc, stream);

                        doc.Open();

                        int x = 50;
                        int y = 50;
                        int lineHeight = 20;
                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(128, 128, 128));

                        iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
                        paragraph.Font = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                        Chunk textChunk = new Chunk("Money flow table");
                        paragraph.Add(textChunk);
                        doc.Add(paragraph);

                        y += 5 * lineHeight;
                        iTextSharp.text.Paragraph last_X_DaysParagraph = new iTextSharp.text.Paragraph(label_last_X_raport_mf.Text, font);
                        last_X_DaysParagraph.SpacingAfter = 20;
                        doc.Add(last_X_DaysParagraph);

                        PdfPTable table = new PdfPTable(3);
                        BaseColor smokeWhite = new BaseColor(245, 245, 245);

                        table.AddCell(new PdfPCell(new Phrase("Quick view", new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD, new BaseColor(128, 128, 128)))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT 
                        });
                        table.AddCell(new PdfPCell(new Phrase("Income", font)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT 
                        });
                        table.AddCell(new PdfPCell(new Phrase("Expenses", new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(255, 0, 0)))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT 
                        });

                        foreach (DataGridViewRow row in DataGridView_raport_mf.Rows)
                        {
                            string column1Value= row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string incomeValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0";
                            string expValue = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "0";

                            BaseColor color;
                            if (table.Rows.Count % 2 == 1) { color = smokeWhite; }
                            else { color = BaseColor.WHITE; }

                            table.AddCell(new PdfPCell(new Phrase(column1Value, font)) 
                            { 
                                BackgroundColor = color, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT 
                            });
                            table.AddCell(new PdfPCell(new Phrase(incomeValue, new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)))
                            { 
                                BackgroundColor = color, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT 
                            });
                            table.AddCell(new PdfPCell(new Phrase(expValue, new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(255, 0, 0)))) 
                            { 
                                BackgroundColor = color, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT 
                            });
                        }

                        table.SpacingBefore = 10;
                        table.SpacingAfter = 10;
                        table.HorizontalAlignment = Element.ALIGN_LEFT;

                        float[] columnWidths = { 0.35f, 0.5f, 0.5f };
                        table.SetWidths(columnWidths);
                        doc.Add(table);
                        iTextSharp.text.Paragraph flowParagraph = new iTextSharp.text.Paragraph("Money flow : "+label_raport_mf.Text, new iTextSharp.text.Font(baseFont, 13, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                        flowParagraph.Alignment = Element.ALIGN_LEFT;
                        doc.Add(flowParagraph);

                        doc.Close();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred while creating the PDF file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void printLedger()
        {
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "Report_Ledger.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        PdfWriter.GetInstance(doc, stream);

                        doc.Open();

                        int x = 50;
                        int y = 50;
                        int lineHeight = 20;
                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
                        paragraph.Font = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                        Chunk textChunk = new Chunk("Revenue and expense ledger");
                        paragraph.Add(textChunk);
                        doc.Add(paragraph);

                        y += 5 * lineHeight;
                        iTextSharp.text.Paragraph last_X_DaysParagraph = new iTextSharp.text.Paragraph(label_last_X_raport_ledger.Text, new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(128, 128, 128)));
                        doc.Add(last_X_DaysParagraph);
                        iTextSharp.text.Paragraph totalAmountParagraph = new iTextSharp.text.Paragraph(label_raport_ledger.Text, new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                        totalAmountParagraph.SpacingAfter = 20;
                        doc.Add(totalAmountParagraph);

                        PdfPTable table = new PdfPTable(2);

                        BaseColor smokeWhite = new BaseColor(245, 245, 245);

                        table.AddCell(new PdfPCell(new Phrase("Income", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_LEFT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });
                        table.AddCell(new PdfPCell(new Phrase(label_raport_total_in.Text, new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });
                        
                        foreach(DataGridViewRow row in DataGridView_raport_in.Rows)
                        {
                            string name = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string amount = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0";
                            
                            int fontSize = 13;
                            BaseColor fontColor = BaseColor.BLACK;
                            if (name.Contains("  "))
                            {
                                fontSize = 11;
                                fontColor = new BaseColor(128, 128, 128);
                            }

                            table.AddCell(new PdfPCell(new Phrase(name, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL,fontColor))) 
                            { 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_LEFT, 
                                PaddingTop = 5 
                            });
                            table.AddCell(new PdfPCell(new Phrase(amount, new iTextSharp.text.Font(baseFont, fontSize-1, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                            { 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_LEFT, 
                                PaddingTop = 5 
                            });
                        }

                        table.AddCell(new PdfPCell(new Phrase("Expenses", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_LEFT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });
                        table.AddCell(new PdfPCell(new Phrase(label_raport_total_exp.Text, new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });

                        foreach (DataGridViewRow row in DataGridView_raport_exp.Rows)
                        {
                            string name = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string amount = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0";

                            int fontSize = 13;
                            BaseColor fontColor = BaseColor.BLACK;
                            if (name.Contains("  "))
                            {
                                fontSize = 11;
                                fontColor = new BaseColor(128, 128, 128);
                            }

                            table.AddCell(new PdfPCell(new Phrase(name, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL, fontColor)))
                            {
                                Border = iTextSharp.text.Rectangle.NO_BORDER,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                PaddingTop = 5
                            });
                            table.AddCell(new PdfPCell(new Phrase(amount, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)))
                            {
                                Border = iTextSharp.text.Rectangle.NO_BORDER,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                PaddingTop = 5
                            });
                        }

                        table.SpacingBefore = 10;
                        table.SpacingAfter = 10;
                        table.HorizontalAlignment = Element.ALIGN_LEFT;
                        
                        float[] columnWidths = { 1.5f, 0.5f};
                        table.SetWidths(columnWidths);
                        doc.Add(table);

                        doc.Close();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred while creating the PDF file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button_more_trns_Click(object sender, EventArgs e)
        {
            TransactionForm trns = new TransactionForm();
            trns.Show();
            this.Hide();
        }

        private void Button_more_trns_MouseEnter(object sender, EventArgs e)
        {
            Button_more_trns_exp.BackColor = System.Drawing.Color.FromArgb(212, 163, 115);
        }

        private void Button_more_trns_MouseLeave(object sender, EventArgs e)
        {
            Button_more_trns_exp.BackColor = System.Drawing.Color.FromArgb(250, 237, 205);
        }
        private void button_print_raport_mf_Click(object sender, EventArgs e)
        {
            printMf();
        }

        private void button_print_raport_mf_MouseEnter(object sender, EventArgs e)
        {
            button_print_raport_mf.BackColor = System.Drawing.Color.FromArgb(212, 163, 115);
        }

        private void button_print_raport_mf_MouseLeave(object sender, EventArgs e)
        {
            button_print_raport_mf.BackColor = System.Drawing.Color.FromArgb(250, 237, 205);
        }
        private void button_print_raport_ledger_Click(object sender, EventArgs e)
        {
            printLedger();
        }

        private void button_print_raport_ledger_MouseEnter(object sender, EventArgs e)
        {
            button_print_raport_ledger.BackColor = System.Drawing.Color.FromArgb(212, 163, 115);
        }

        private void button_print_raport_ledger_MouseLeave(object sender, EventArgs e)
        {
            button_print_raport_ledger.BackColor = System.Drawing.Color.FromArgb(250, 237, 205);
        }

    }
}


