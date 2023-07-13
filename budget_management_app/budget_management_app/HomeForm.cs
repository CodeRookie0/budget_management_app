using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Guna.UI2.Native.WinApi;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

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

                button.Click += button_click;

                flowLayoutPanel_account.Controls.Add(button);
            }
            Button buttonAdd = new Button();
            buttonAdd.Text = "Add New\nAccount";
            buttonAdd.AutoSize = true;

            buttonAdd.Click += button_Add_click;

            flowLayoutPanel_account.Controls.Add(buttonAdd);

            dbcon.CloseCon();
        }

        private void button_click(object sender, EventArgs e)
        {
            AccountForm acc=new AccountForm();
            acc.Show();
            this.Hide();
        }
        private void button_Add_click(object sender, EventArgs e)
        {
            AddAccountForm addAcc = new AddAccountForm();
            addAcc.Show();
            this.Hide();
        }

        // Adding transaction data for the last month to chart_summary
        private void getDataSum()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                int currentMonth = currentDate.Month;
                int currentYear = currentDate.Year;

                string selectExpensesQuery = "SELECT ISNULL(SUM(ExpAmount), 0) AS TotalExpenses FROM Expenses WHERE UserId=@UserId AND MONTH(ExpDate) = @CurrentMonth AND YEAR(ExpDate) = @CurrentYear";
                SqlCommand expensesCommand = new SqlCommand(selectExpensesQuery, dbcon.GetCon());
                expensesCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                expensesCommand.Parameters.AddWithValue("@CurrentMonth", currentMonth);
                expensesCommand.Parameters.AddWithValue("@CurrentYear", currentYear);
                decimal totalExpenses = 0.0m;

                string selectIncomeQuery = "SELECT ISNULL(SUM(InAmount), 0) AS TotalIncome FROM Income WHERE UserId=@UserId AND MONTH(InDate) = @CurrentMonth AND YEAR(InDate) = @CurrentYear";
                SqlCommand incomeCommand = new SqlCommand(selectIncomeQuery, dbcon.GetCon());
                incomeCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                incomeCommand.Parameters.AddWithValue("@CurrentMonth", currentMonth);
                incomeCommand.Parameters.AddWithValue("@CurrentYear", currentYear);
                decimal totalIncome = 0.0m;

                string selectSavingsQuery = "SELECT ISNULL(SUM(SavAmount), 0) AS TotalSavings FROM Savings WHERE UserId=@UserId AND MONTH(SavDate) = @CurrentMonth AND YEAR(SavDate) = @CurrentYear";
                SqlCommand savingsCommand = new SqlCommand(selectSavingsQuery, dbcon.GetCon());
                savingsCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                savingsCommand.Parameters.AddWithValue("@CurrentMonth", currentMonth);
                savingsCommand.Parameters.AddWithValue("@CurrentYear", currentYear);
                decimal totalSavings = 0.0m;

                dbcon.OpenCon();
                totalExpenses = Convert.ToDecimal(expensesCommand.ExecuteScalar());
                totalIncome = Convert.ToDecimal(incomeCommand.ExecuteScalar());
                totalSavings = Convert.ToDecimal(savingsCommand.ExecuteScalar());
                dbcon.CloseCon();


                decimal totalAmount = totalExpenses + totalIncome + totalSavings;

                decimal expensesPercentage = 0.0m;
                decimal incomePercentage = 0.0m;
                decimal savingsPercentage = 0.0m;
                
                if (totalAmount != 0)
                {
                    expensesPercentage = (totalExpenses / totalAmount) * 100;
                    incomePercentage = (totalIncome / totalAmount) * 100;
                    savingsPercentage = (totalSavings / totalAmount) * 100;

                    chart_summary.Series["DataSeries"].Points.AddXY("Expenses", expensesPercentage);
                    chart_summary.Series["DataSeries"].Points.AddXY("Income", incomePercentage);
                    chart_summary.Series["DataSeries"].Points.AddXY("Savings", savingsPercentage);

                    chart_summary.Series["DataSeries"].LabelFormat = "0.00'%'";
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
            DateTime currentDate = DateTime.Today;
            List<DateTime> last7Days = new List<DateTime>();
            List<decimal> expensesData = new List<decimal>();

            // Pobierz daty ostatnich 7 dni
            for (int i = 6; i >= 0; i--)
            {
                DateTime date = currentDate.AddDays(-i);
                last7Days.Add(date);
            }

            // Pobierz dane z tabeli Expenses
            foreach (DateTime date in last7Days)
            {
                string selectExpensesQuery = "SELECT ISNULL(SUM(ExpAmount), 0) AS TotalExpenses FROM Expenses WHERE ExpDate = @Date AND UserId ="+LoginForm.userId;
                SqlCommand expensesCommand = new SqlCommand(selectExpensesQuery, dbcon.GetCon());
                expensesCommand.Parameters.AddWithValue("@Date", date);
                dbcon.OpenCon();
                decimal expensesAmount = Convert.ToDecimal(expensesCommand.ExecuteScalar());
                expensesData.Add(expensesAmount);
            }

            for (int i = 0; i < last7Days.Count; i++)
            {
                DateTime date = last7Days[i];
                decimal expensesAmount = expensesData[i];

                chart_rec_exp.Series["Expenses"].Points.AddXY(date.Day.ToString(), expensesAmount);
            }


        }

        // Adding data about the last 7 transactions flowLayoutPanel_top7
        private void getRecTrns()
        {
            string selectQuery = "SELECT TOP 7 AccName, CatName, Amount, DateTrns FROM ( SELECT  Account.AccName, Category.CatName,  '+' + CAST(Income.InAmount AS VARCHAR) AS Amount,  Income.InDate AS DateTrns" + 
                " FROM Income JOIN Account ON Account.AccId = Income.AccId JOIN Category ON Category.CatId = Income.CatId" + 
                " WHERE Income.UserId = " + LoginForm.userId +
                " UNION ALL SELECT  Account.AccName, Category.CatName,  '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount, Savings.SavDate AS DateTrns" + 
                " FROM Savings JOIN Account ON Account.AccId = Savings.AccId  JOIN Category ON Category.CatId = Savings.CatId WHERE  Savings.UserId = " + LoginForm.userId +
                " UNION ALL  SELECT  Account.AccName,  Category.CatName, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount, Expenses.ExpDate AS DateTrns" + 
                "  FROM  Expenses   JOIN Account ON Account.AccId = Expenses.AccId JOIN Category ON Category.CatId = Expenses.CatId WHERE Expenses.UserId = " + LoginForm.userId + 
                " ) AS CombinedData ORDER BY DateTrns DESC";


            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
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
            DataGridView_top7trns.DataSource = table;

            dbcon.CloseCon();
        }


        // Animations for the sidebar
        private void pictureBox_sideBar_Click(object sender, EventArgs e)
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

        // Design sideBar pictureBox
        private void pictureBox_sideBar_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_sideBar.BackColor = Color.FromArgb(143,157,118);
        }

        private void pictureBox_sideBar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_sideBar.BackColor = Color.FromArgb(163, 177, 138);
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
            StatisticsForm stat=new StatisticsForm();
            stat.Show();
            this.Hide();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            SettingsForm set=new SettingsForm();
            set.Show();
            this.Hide();
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


        // Main Panel button functionality
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

        private void Button_add_trns_Click(object sender, EventArgs e)
        {
            AddTransactionForm addTrns= new AddTransactionForm();
            addTrns.Show();
            this.Hide();
        }

        private void Button_add_trns_MouseEnter(object sender, EventArgs e)
        {
            Button_add_trns.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_add_trns_MouseLeave(object sender, EventArgs e)
        {
            Button_add_trns.BackColor = Color.FromArgb(250, 237, 205);
        }

        private void Button_more_sum_Click(object sender, EventArgs e)
        {

        }

        private void Button_more_sum_MouseEnter(object sender, EventArgs e)
        {
            Button_more_sum.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_more_sum_MouseLeave(object sender, EventArgs e)
        {
            Button_more_sum.BackColor = Color.FromArgb(250, 237, 205);
        }

        private void Button_more_trns_Click(object sender, EventArgs e)
        {
            TransactionForm trns=new TransactionForm();
            trns.Show();
            this.Hide();
        }

        private void Button_more_trns_MouseEnter(object sender, EventArgs e)
        {
            Button_more_trns.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_more_trns_MouseLeave(object sender, EventArgs e)
        {
            Button_more_trns.BackColor = Color.FromArgb(250, 237, 205);
        }
    }
}
