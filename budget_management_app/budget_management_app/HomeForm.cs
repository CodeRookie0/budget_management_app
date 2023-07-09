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
using static Guna.UI2.Native.WinApi;

namespace budget_management_app
{
    public partial class HomeForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public static string lastForm;
        bool sidebarExpand;
        public HomeForm()
        {
            InitializeComponent();
            panel_Sidebar.Visible = true;
        }

        private void StartPageForm_Load(object sender, EventArgs e)
        {
            getTableAcc();
            getDataSum();
            get7DaysRecExp();
            getRecTrns();
        }

        // Adding account data to flowLayoutPanel_account
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
            Button buttonAdd = new Button();
            buttonAdd.Text = "Add New\nAccount";
            buttonAdd.AutoSize = true;

            flowLayoutPanel_account.Controls.Add(buttonAdd);

            dbcon.CloseCon();
        }


        // Adding transaction data for the last month to chart_summary
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

        // Adding data about last week's transactions to chart_rec_exp
        private void get7DaysRecExp()
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

        // Adding data about the last 7 transactions flowLayoutPanel_top7
        private void getRecTrns()
        {
            string selectQuery = "SELECT Acc.AccName, Cat.CatName, ";
            selectQuery += "CASE WHEN Inc.InAmount IS NOT NULL THEN CONCAT('+', Inc.InAmount) ";
            selectQuery += "WHEN Sav.SavAmount IS NOT NULL THEN CONCAT('+', Sav.SavAmount) ";
            selectQuery += "WHEN Exp.ExpAmount IS NOT NULL THEN CONCAT('-', Exp.ExpAmount) ";
            selectQuery += "END AS Amount, ";
            selectQuery += "CASE WHEN Inc.InDate IS NOT NULL THEN Inc.InDate ";
            selectQuery += "WHEN Sav.SavDate IS NOT NULL THEN Sav.SavDate ";
            selectQuery += "WHEN Exp.ExpDate IS NOT NULL THEN Exp.ExpDate ";
            selectQuery += "END AS Date ";
            selectQuery += "FROM Income Inc ";
            selectQuery += "LEFT JOIN Account Acc ON Acc.AccId = Inc.AccId ";
            selectQuery += "LEFT JOIN Category Cat ON Cat.CatId = Inc.CatId ";
            selectQuery += "WHERE Inc.UserId = " + LoginForm.userId + " ";
            selectQuery += "UNION ALL ";
            selectQuery += "SELECT Acc.AccName, Cat.CatName, CONCAT('-', Exp.ExpAmount) AS Amount, Exp.ExpDate AS Date ";
            selectQuery += "FROM Expenses Exp ";
            selectQuery += "LEFT JOIN Account Acc ON Acc.AccId = Exp.AccId ";
            selectQuery += "LEFT JOIN Category Cat ON Cat.CatId = Exp.CatId ";
            selectQuery += "WHERE Exp.UserId = " + LoginForm.userId + " ";
            selectQuery += "UNION ALL ";
            selectQuery += "SELECT Acc.AccName, Cat.CatName, CONCAT('+', Sav.SavAmount) AS Amount, Sav.SavDate AS Date ";
            selectQuery += "FROM Savings Sav ";
            selectQuery += "LEFT JOIN Account Acc ON Acc.AccId = Sav.AccId ";
            selectQuery += "LEFT JOIN Category Cat ON Cat.CatId = Sav.CatId ";
            selectQuery += "WHERE Sav.UserId = " + LoginForm.userId + " ";
            selectQuery += "ORDER BY Date ASC ";


            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            DataTable top7 = table.AsEnumerable().Take(7).CopyToDataTable();

            foreach (DataRow row in top7.Rows)
            {
                string accName = row["AccName"].ToString();
                string catName = row["CatName"].ToString();
                string amount = row["Amount"].ToString();
                string date = row["Date"].ToString();


                string labelText = row["CatName"].ToString().Trim() + "              " + row["Amount"].ToString() + "\n" + row["AccName"].ToString().Trim() + "              " + row["Date"].ToString();

                Label label = new Label();
                label.Text = labelText;
                label.AutoSize = true;

                flowLayoutPanel_top7.Controls.Add(label);
            }
            dbcon.CloseCon();
        }


        // Animations for the sidebar
        private void pictureBox_menu_Click_1(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        private void sidebar_timer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand) 
            { 
                panel_Sidebar.Width -= 10;
                if (panel_Sidebar.Width == panel_Sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebar_timer.Stop();
                }
            }
            else
            {
                panel_Sidebar.Width += 10;
                if (panel_Sidebar.Width == panel_Sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebar_timer.Stop();
                }
            }

        }



        // Side bar button functionality
        private void button_home_Click(object sender, EventArgs e)
        {
            HomeForm home=new HomeForm();
            home.Show();
            this.Hide();
        }

        private void button_acc_Click(object sender, EventArgs e)
        {
            AccountForm acc=new AccountForm();
            acc.Show();
            this.Hide();
        }

        private void button_trns_Click(object sender, EventArgs e)
        {
            TransactionForm trns=new TransactionForm();
            trns.Show();
            this.Hide();
        }

        private void button_cat_Click(object sender, EventArgs e)
        {
            CategoriesForm categories=new CategoriesForm();
            categories.Show();
            this.Hide();
        }

        private void button_lim_Click(object sender, EventArgs e)
        {

        }

        private void button_stat_Click(object sender, EventArgs e)
        {

        }

        private void button_settings_Click(object sender, EventArgs e)
        {

        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm login=new LoginForm();
                login.Show();
                this.Hide();
            }
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to leave the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.FromArgb(212, 148, 85);
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.White;
        }

        private void button_logout_MouseEnter(object sender, EventArgs e)
        {
            button_logout.BackColor = Color.FromArgb(143, 157, 118);
        }

        private void button_logout_MouseLeave(object sender, EventArgs e)
        {
            button_logout.BackColor = Color.Transparent;
        }
    }
}
