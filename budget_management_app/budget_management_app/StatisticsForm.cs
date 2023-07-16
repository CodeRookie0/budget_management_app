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

        public StatisticsForm()
        {
            InitializeComponent();

            getAcc();
            comboBox_account.SelectedIndex = 0;
            getSelectedAcc();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.FromArgb(212, 148, 85);
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.White;
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

            label_exp_from_date.Text=selectedDay.ToString() + "." + selectedMonth.ToString() + "." + selectedYear.ToString();
        }
       private void UpdateCharts()
        {
            getPieCharts();
            getHighestExpensees();
        }

        private void button_7D_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-7);
            int startDay = startDateTime.Day;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text="LAST 7 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);
        }

        private void button_30D_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-30);
            int startDay = 1;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 30 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);
        }

        private void button_12W_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-2);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 3 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);
        }

        private void button_6M_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-5);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 6 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);
        }

        private void button_1Y_Click(object sender, EventArgs e)
        {
            label_exp_last_X.Text = "LAST 12 MONTH";
            UpdateSelectedDate(1, 1, currentDate.Year);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_bottomBar.Size = new Size(50, 40);
            pictureBox_bottomBar.Location = new Point(191, -9);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_bottomBar.Size = new Size(50, 31);
            pictureBox_bottomBar.Location = new Point(191, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer_bottomBar.Start();
        }

        private void timer_bottomBar_Tick(object sender, EventArgs e)
        {
            if (bottombarExpand)
            {
                panel_bottomBar.Location = new Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y + 10);
                panel_bottomBar.Height -= 10;
                if (panel_bottomBar.Height == panel_bottomBar.MinimumSize.Height)
                {
                    bottombarExpand = false;
                    timer_bottomBar.Stop();
                }
            }
            else
            {
                panel_bottomBar.Location = new Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y - 10);
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

        private void getPieCharts()
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
/// <summary>
/// ////////////
/// </summary>
        private void Button_more_trns_Click(object sender, EventArgs e)
        {
            TransactionForm trns = new TransactionForm();
            trns.Show();
            this.Hide();
        }

        private void Button_more_trns_MouseEnter(object sender, EventArgs e)
        {
            Button_more_trns_exp.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_more_trns_MouseLeave(object sender, EventArgs e)
        {
            Button_more_trns_exp.BackColor = Color.FromArgb(250, 237, 205);
        }
    }
}


