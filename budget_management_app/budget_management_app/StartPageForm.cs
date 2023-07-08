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
            DateTime currentDate=DateTime.Now;
            int currentMonth=currentDate.Month;
            int currentYear=currentDate.Year;

            string selectExpensesQuery = "SELECT SUM(ExpAmount) AS TotalExpenses FROM Expenses WHERE UserId=" + LoginForm.userId + " AND MONTH(ExpDate) = " + currentMonth + " AND YEAR(ExpDate) = " + currentYear;
            SqlCommand expensesCommand = new SqlCommand(selectExpensesQuery, dbcon.GetCon());
            decimal totalExpenses = Convert.ToDecimal(expensesCommand.ExecuteScalar());

            string selectIncomeQuery = "SELECT SUM(InAmount) AS TotalIncome FROM Income WHERE UserId=" + LoginForm.userId + " AND MONTH(InDate) = " + currentMonth + " AND YEAR(InDate) = " + currentYear;
            SqlCommand incomeCommand = new SqlCommand(selectIncomeQuery, dbcon.GetCon());
            decimal totalIncome = Convert.ToDecimal(incomeCommand.ExecuteScalar());

            string selectSavingsQuery = "SELECT SUM(SavAmount) AS TotalSavings FROM Savings WHERE UserId=" + LoginForm.userId + " AND MONTH(SavDate) = " + currentMonth + " AND YEAR(SavDate) = " + currentYear;
            SqlCommand savingsCommand = new SqlCommand(selectSavingsQuery, dbcon.GetCon());
            decimal totalSavings = Convert.ToDecimal(savingsCommand.ExecuteScalar());

            decimal totalAmount = totalExpenses + totalIncome + totalSavings;

            decimal expensesPercentage = (totalExpenses / totalAmount) * 100;
            decimal incomePercentage = (totalIncome / totalAmount) * 100;
            decimal savingsPercentage = (totalSavings / totalAmount) * 100;

            chart_summary.Series["DataSeries"].Points.AddXY("Expenses", expensesPercentage);
            chart_summary.Series["DataSeries"].Points.AddXY("Income", incomePercentage);
            chart_summary.Series["DataSeries"].Points.AddXY("Savings", savingsPercentage);
        }
    }
}
