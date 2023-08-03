using Guna.UI2.WinForms;
using LiveCharts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media;

namespace budget_management_app
{
    public partial class HomeForm : Form
    {
        // Create a new instance of the DBConnection class
        private DBConnection dbConnection =new DBConnection();

        // Static field to store the name of the last form used
        public static string lastForm;

        // Field to store the tooltip for expenses on the chart
        private string expensesTooltip = "";

        // Constructor for the HomeForm
        public HomeForm()
        {
            InitializeComponent();
        }

        // Event handler for the form's Load event
        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Load various data when the form is loaded
            LoadUserName();
            LoadAccountData();
            LoadSummaryData();
            LoadLastWeekTransactions();
            LoadTop7Transactions();
        }

        // Method to load the user name and display a greeting message
        private void LoadUserName()
        {
            try
            {
                // SQL query to retrieve the user's name from the database
                string selectQuery = "SELECT UserName FROM [User] WHERE UserId = @UserId";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    dbConnection.OpenCon();
                    string userName = command.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(userName))
                    {
                        hiLabel.Text = "Hi, " + userName.Trim();
                    }
                    else
                    {
                        hiLabel.Text = "Hi, User";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Method to load account data and display it as buttons on the form
        private void LoadAccountData()
        {
            try
            {
                // SQL query to retrieve account data from the database
                string selectQuery = "SELECT AccName, AccBalance, Currency.CurrCode FROM Account JOIN Currency ON Account.AccCurrId = Currency.CurrId WHERE UserId=@UserId";
                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    dbConnection.OpenCon();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Iterate through the rows of the DataTable to create account buttons
                    foreach (DataRow row in table.Rows)
                    {
                        // Extract relevant account data from the current row
                        string accBalance = row["AccBalance"].ToString().Trim();
                        string currCode = row["CurrCode"].ToString();
                        string accName = row["AccName"].ToString().Trim();

                        // Create a string to display account information on the button
                        string accInfo = $"\n{accName}\n{accBalance}  {currCode}\n\n\n__________________________________";

                        // Create a Guna2Button with the account information
                        Guna2Button button = new Guna2Button
                        {
                            Text = accInfo.Trim(),
                            TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                            ForeColor = System.Drawing.Color.White,
                            Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 15.75f, FontStyle.Regular),
                            BorderRadius = 20,
                            FillColor = System.Drawing.Color.FromArgb(233, 31, 52),
                            Width = flowLayoutPanel_account.Width - 200,
                            Height = flowLayoutPanel_account.Height - 30,
                            Margin = new Padding(15, 0, 15, 0)
                        };

                        // Attach the AccountButton_Click event handler to the button's Click event
                        button.Click += AccountButton_Click;

                        // Add the button to the flowLayoutPanel_account
                        flowLayoutPanel_account.Controls.Add(button);
                    }


                    // Create an "Add new account" button
                    Guna2Button buttonAdd = new Guna2Button
                    {
                        Text = "Add new account\n\n\n\n__________________________________",
                        TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                        ForeColor = System.Drawing.Color.White,
                        Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 15.75f, FontStyle.Regular),
                        BorderRadius = 20,
                        FillColor = System.Drawing.Color.FromArgb(233, 31, 52),
                        Width = flowLayoutPanel_account.Width - 200,
                        Height = flowLayoutPanel_account.Height - 30,
                        Margin = new Padding(15, 0, 15, 0)
                    };

                    // Attach the AddAccountButton_Click event handler to the button's Click event
                    buttonAdd.Click += AddAccountButton_Click;

                    // Add the "Add new account" button to the flowLayoutPanel_account
                    flowLayoutPanel_account.Controls.Add(buttonAdd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for account buttons' Click event
        private void AccountButton_Click(object sender, EventArgs e)
        {
            AccountsForm accountForm = new AccountsForm();
            accountForm.Show();
            this.Hide();
        }
        // Event handler for "Add new account" button's Click event
        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm();
            addAccountForm.Show();
            this.Hide();
        }

        // Method to load summary data and display it as a pie chart
        private void LoadSummaryData()
        {
            try
            {
                // Get the current date
                DateTime currentDate = DateTime.Now;
                int currentMonth = currentDate.Month;
                int currentYear = currentDate.Year;

                dbConnection.OpenCon();

                // SQL queries to retrieve total expenses and total income for the current month and year
                string selectExpensesQuery = "SELECT ISNULL(SUM(ExpAmount), 0) AS TotalExpenses FROM Expenses WHERE UserId=@UserId AND MONTH(ExpDate) = @CurrentMonth AND YEAR(ExpDate) = @CurrentYear";
                string selectIncomeQuery = "SELECT ISNULL(SUM(InAmount), 0) AS TotalIncome FROM Income WHERE UserId=@UserId AND MONTH(InDate) = @CurrentMonth AND YEAR(InDate) = @CurrentYear";

                decimal totalExpense, totalIncome;

                // Create SqlCommand objects with the queries and database connection
                SqlCommand expensesCommand = new SqlCommand(selectExpensesQuery, dbConnection.GetCon());
                expensesCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                expensesCommand.Parameters.AddWithValue("@CurrentMonth", currentMonth);
                expensesCommand.Parameters.AddWithValue("@CurrentYear", currentYear);
                totalExpense = Convert.ToDecimal(expensesCommand.ExecuteScalar());

                SqlCommand incomeCommand = new SqlCommand(selectIncomeQuery, dbConnection.GetCon());
                incomeCommand.Parameters.AddWithValue("@UserId", LoginForm.userId);
                incomeCommand.Parameters.AddWithValue("@CurrentMonth", currentMonth);
                incomeCommand.Parameters.AddWithValue("@CurrentYear", currentYear);
                totalIncome = Convert.ToDecimal(incomeCommand.ExecuteScalar());

                // Clear existing series from the pie chart
                pieChart1.Series.Clear();

                decimal totalAmount = totalExpense + totalIncome;

                // If the total amount is not zero, create and add pie chart series for expenses and income
                if (totalAmount != 0)
                {
                    // Create a pie series for expenses
                    var dataPointExpenses = new LiveCharts.Wpf.PieSeries
                    {
                        Title = "Expense",
                        Values = new ChartValues<decimal> { totalExpense },
                        DataLabels = false,
                        LabelPoint = point => "    "+totalExpense.ToString()+"    ",
                        FontSize=13,
                        Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(86,88,102)),
                    };
                    pieChart1.Series.Add(dataPointExpenses);

                    // Create a pie series for income
                    var dataPointIncome = new LiveCharts.Wpf.PieSeries
                    {
                        Title = "Income",
                        Values = new ChartValues<decimal> { totalIncome },
                        DataLabels = false,
                        LabelPoint = point => "    "+totalIncome.ToString()+ "    ",
                        FontSize=13,
                        Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(128,130,142)),
                    };
                    pieChart1.Series.Add(dataPointIncome);
                }

                // Set the legend location and appearance for the pie chart
                pieChart1.LegendLocation = LegendLocation.Right;
                pieChart1.DefaultLegend.FontSize = 17;
                pieChart1.DefaultLegend.FontFamily = new System.Windows.Media.FontFamily("Segoe UI Variable Display");
                pieChart1.DefaultLegend.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(30,41,59));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Method to load last week's transaction data and display it as a chart
        private void LoadLastWeekTransactions()
        {
            try
            {
                // SQL query to retrieve last week's expenses data from the database
                string query_exp = "SELECT ExpDate, SUM(Expenses.ExpAmount) AS TotalAmount " +
                       "FROM Expenses " +
                       "WHERE Expenses.UserId = @UserId " +
                       "AND Expenses.ExpDate BETWEEN @StartDate AND GETDATE() " +
                       "GROUP BY ExpDate";

                // Create a SqlCommand with the query and database connection
                SqlCommand command_exp = new SqlCommand(query_exp, dbConnection.GetCon());
                command_exp.Parameters.AddWithValue("@UserId", LoginForm.userId);
                command_exp.Parameters.AddWithValue("@StartDate", DateTime.Today.AddDays(-6));
                dbConnection.OpenCon();

                // Create a data adapter to retrieve data from the database
                SqlDataAdapter adapter_exp = new SqlDataAdapter(command_exp);

                // Create a DataTable to hold the retrieved data
                DataTable dataTable_exp = new DataTable();
                adapter_exp.Fill(dataTable_exp);

                // Clear existing points from the chart series
                lastWeekExpensesChart.Series["Expenses"].Points.Clear();
                lastWeekExpensesChart.Series["Default"].Points.Clear();

                double max_amount = 0;

                // Define the start and end dates for the last week
                DateTime startDate = DateTime.Today.AddDays(-6);
                DateTime endDate = DateTime.Today;

                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    // Select the row from the DataTable that matches the current date
                    DataRow[] rows = dataTable_exp.Select("ExpDate = #" + date.ToString("MM/dd/yyyy") + "#");

                    // Get the total amount for the current date (if available)
                    double amount = rows.Length > 0 ? Convert.ToDouble(rows[0]["TotalAmount"]) : 0;

                    // Add the amount as a data point to the "Expenses" series on the chart
                    lastWeekExpensesChart.Series["Expenses"].Points.Add(amount);

                    // Set a custom tooltip for the data point
                    int index = lastWeekExpensesChart.Series["Expenses"].Points.Count - 1;
                    lastWeekExpensesChart.Series["Expenses"].Points[index].SetCustomProperty("Tooltip", date.ToString("dd/MM/yyyy") + "\nAmount: " + amount.ToString());

                    // Find the maximum amount for scaling the "Default" series on the chart
                    if (amount > max_amount)
                    {
                        max_amount = amount;
                    }
                }

                // Calculate and add points to the "Default" series for visual scaling
                for (int i = 0; i < lastWeekExpensesChart.Series["Expenses"].Points.Count; i++)
                {
                    double amount = lastWeekExpensesChart.Series["Expenses"].Points[i].YValues[0];
                    lastWeekExpensesChart.Series["Default"].Points.Add(max_amount * 1.1 - amount);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handler for the MouseMove event on the lastWeekExpensesChart
        private void lastWeekExpensesChart_MouseMove(object sender, MouseEventArgs e)
        {
            var chart = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;

            // Perform a hit test to determine if the mouse is over a data point
            var hitTestResult = chart.HitTest(e.X, e.Y);

            // If the mouse is over a data point, get its tooltip and set it for both series
            if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = hitTestResult.PointIndex;

                expensesTooltip = chart.Series["Expenses"].Points[pointIndex].GetCustomProperty("Tooltip");
            }
            else
            {
                expensesTooltip = "";
            }
            chart.Series["Expenses"].ToolTip = expensesTooltip;
            chart.Series["Default"].ToolTip = expensesTooltip;
        }

        // Method to load the top 7 transactions and display them in the DataGridView_top7trns
        private void LoadTop7Transactions()
        {
            try
            {
                // SQL query to retrieve the top 7 transactions for the current user
                string selectQuery = "SELECT TOP 7 AccName, CatName, Amount, DateTrns FROM (SELECT Account.AccName, Category.CatName,  '+' + CAST(Income.InAmount AS VARCHAR) AS Amount, Income.InDate AS DateTrns" +
                " FROM Income JOIN Account ON Account.AccId = Income.AccId JOIN Category ON Category.CatId = Income.CatId" +
                " WHERE Income.UserId = @UserId" +
                " UNION ALL SELECT Account.AccName, Category.CatName,  '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount, Savings.SavDate AS DateTrns" +
                " FROM Savings JOIN Account ON Account.AccId = Savings.AccId JOIN Category ON Category.CatId = Savings.CatId WHERE Savings.UserId = @UserId" +
                " UNION ALL SELECT Account.AccName, Category.CatName, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount, Expenses.ExpDate AS DateTrns" +
                " FROM Expenses JOIN Account ON Account.AccId = Expenses.AccId JOIN Category ON Category.CatId = Expenses.CatId WHERE Expenses.UserId = @UserId" +
                ") AS CombinedData ORDER BY DateTrns DESC";

                dbConnection.OpenCon();

                // Create a SqlCommand with the query and database connection
                SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon());
                command.Parameters.AddWithValue("@UserId", LoginForm.userId);

                // Create a data adapter to retrieve data from the database
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Create a DataTable to hold the retrieved data
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Trim whitespace from each cell in the DataTable
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

                // Bind the DataTable to the DataGridView_top7trns to display the top 7 transactions
                DataGridView_top7trns.DataSource = table;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // Event handlers for various button clicks to navigate to other forms
        private void accountsButton_Click(object sender, EventArgs e)
        {
            AccountsForm acc = new AccountsForm();
            acc.Show();
            this.Hide();
        }
        private void transactionsButton_Click(object sender, EventArgs e)
        {
            TransactionsHistoryForm trns = new TransactionsHistoryForm();
            trns.Show();
            this.Hide();
        }

        private void categoriesButton_Click(object sender, EventArgs e)
        {
            CategoriesForm categories = new CategoriesForm();
            categories.Show();
            this.Hide();
        }

        private void statisticButtonBar_Click(object sender, EventArgs e)
        {
            StatisticsForm stat = new StatisticsForm();
            stat.Show();
            this.Hide();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm set = new SettingsForm();
            set.Show();
            this.Hide();
        }

        // Event handler for the "Exit" label's Click event to prompt the user before exiting the application
        private void exitLabel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to leave the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        // Event handlers to change the color of the "Exit" label on mouse hover
        private void exitLabel_MouseEnter(object sender, EventArgs e)
        {
            exitLabel.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
        }

        private void exitLabel_MouseLeave(object sender, EventArgs e)
        {
            exitLabel.ForeColor = System.Drawing.Color.White;
        }

        // Event handler for the "Add Transaction" button's Click event
        private void addTransactionButton_Click(object sender, EventArgs e)
        {
            AddTransactionForm addTransaction = new AddTransactionForm();
            addTransaction.Show();
            this.Hide();
        }

        // Event handlers for other buttons to navigate to relevant forms
        private void statisticButtonPage_Click(object sender, EventArgs e)
        {
            StatisticsForm statistics=new StatisticsForm();
            statistics.Show();
            this.Hide();
        }


        private void historyButton_Click(object sender, EventArgs e)
        {
            TransactionsHistoryForm transactions = new TransactionsHistoryForm();
            transactions.Show();
            this.Hide();
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm();
            addAccountForm.Show();
            this.Hide();
        }


        private void moreTransactionsButton_Click(object sender, EventArgs e)
        {
            TransactionsHistoryForm transactions = new TransactionsHistoryForm();
            transactions.Show();
            this.Hide();
        }

        private void moreStaticsticButton_Click(object sender, EventArgs e)
        {
            StatisticsForm statistics = new StatisticsForm();
            statistics.Show();
            this.Hide();
        }
    }
}
