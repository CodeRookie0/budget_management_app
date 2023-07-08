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

namespace budget_management_app
{
    public partial class StartPageForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public static string lastForm;
        public StartPageForm()
        {
            InitializeComponent();
        }

        private void StartPageForm_Load(object sender, EventArgs e)
        {
            getTableAcc();
            getDataSum();
            getDataRecExp();
        }
        private void getTableAcc()
        {
            string selectQuerry = "SELECT AccName,AccBalance,Currency.CurrCode FROM Account JOIN Currency ON Account.AccCurrId = Currency.CurrId WHERE UserId=" + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {

                string AccInfo = row["AccBalance"].ToString().Trim()+"  "+ row["CurrCode"].ToString() + "\n"+ row["AccName"].ToString().Trim();

                Button button = new Button();
                button.Text = AccInfo.Trim();
                button.AutoSize = true;

///////        // Dodanie obsługi zdarzeń dla przycisku
                

                flowLayoutPanel_account.Controls.Add(button);
            }
            dbcon.CloseCon();
        }
        private void getDataSum()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                int currentMonth = currentDate.Month;
                int currentYear = currentDate.Year;

                string selectExpensesQuery = "SELECT SUM(ExpAmount) AS TotalExpenses FROM Expenses WHERE UserId=" + LoginForm.userId + " AND MONTH(ExpDate) = " + currentMonth + " AND YEAR(ExpDate) = " + currentYear;
                SqlCommand expensesCommand = new SqlCommand(selectExpensesQuery, dbcon.GetCon());
                decimal totalExpenses = 0.0m;
                dbcon.OpenCon();
                if (expensesCommand.ExecuteScalar() != DBNull.Value)
                {
                    totalExpenses = Convert.ToDecimal(expensesCommand.ExecuteScalar());
                }

                string selectIncomeQuery = "SELECT SUM(InAmount) AS TotalIncome FROM Income WHERE UserId=" + LoginForm.userId + " AND MONTH(InDate) = " + currentMonth + " AND YEAR(InDate) = " + currentYear;
                SqlCommand incomeCommand = new SqlCommand(selectIncomeQuery, dbcon.GetCon());
                decimal totalIncome = 0;
                if (expensesCommand.ExecuteScalar() != DBNull.Value)
                {
                    totalIncome = Convert.ToDecimal(incomeCommand.ExecuteScalar());
                }

                string selectSavingsQuery = "SELECT SUM(SavAmount) AS TotalSavings FROM Savings WHERE UserId=" + LoginForm.userId + " AND MONTH(SavDate) = " + currentMonth + " AND YEAR(SavDate) = " + currentYear;
                SqlCommand savingsCommand = new SqlCommand(selectSavingsQuery, dbcon.GetCon());
                decimal totalSavings = 0;
                if (expensesCommand.ExecuteScalar() != DBNull.Value)
                {
                    totalSavings = Convert.ToDecimal(savingsCommand.ExecuteScalar());
                }
                dbcon.CloseCon();

                decimal totalAmount = totalExpenses + totalIncome + totalSavings;

                decimal expensesPercentage = 0;
                decimal incomePercentage = 0;
                decimal savingsPercentage = 0;
                
                if (totalAmount != 0)
                {
                    expensesPercentage = (totalExpenses / totalAmount) * 100;
                    incomePercentage = (totalIncome / totalAmount) * 100;
                    savingsPercentage = (totalSavings / totalAmount) * 100;

                    chart_summary.Series["DataSeries"].Points.AddXY("Expenses", expensesPercentage);
                    chart_summary.Series["DataSeries"].Points.AddXY("Income", incomePercentage);
                    chart_summary.Series["DataSeries"].Points.AddXY("Savings", savingsPercentage);

                    chart_summary.Series["DataSeries"].IsValueShownAsLabel = true;
                }
                else
                {
                    chart_summary.Series["DataSeries"].Points.AddXY("", 100);
                    chart_summary.Series["DataSeries"].Points.Last().Color = Color.FromArgb(224, 224, 224);
                    chart_summary.Series["DataSeries"].IsVisibleInLegend = false;
                    chart_summary.Series["DataSeries"].IsValueShownAsLabel = false;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getDataRecExp()
        {
            string selectQuery = "SELECT ExpDate, ExpAmount FROM Expenses WHERE ExpDate >= DATEADD(day, -6, GETDATE()) AND UserId="+LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Utworzenie serii danych dla wykresu
            Series series = new Series("Expenses");
            series.IsVisibleInLegend = false;
            series.ChartType = SeriesChartType.Column;

            // Dodanie punktów danych do serii
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["ExpDate"]);
                    double amount = Convert.ToDouble(row["ExpAmount"]);
                    series.Points.AddXY(date.ToString("dd"), amount);
                }
            }
            else
            {
                List<DateTime> dates = new List<DateTime>();
                for (int i = -6; i <= 0; i++)
                {
                    DateTime date = DateTime.Now.AddDays(i);
                    dates.Add(date);
                }
                foreach (DateTime date in dates)
                {
                    double amount = 0;
                    series.Points.AddXY(date.ToString("dd"), amount);
                }
            }

            // Dodanie serii do wykresu
            chart_rec_exp.Series.Add(series);
        }
    }
}
