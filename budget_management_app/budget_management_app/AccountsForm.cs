using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace budget_management_app
{
    public partial class AccountsForm : Form
    {
        DBConnection dbConnection = new DBConnection();
        public static string selectedAccountName;
        public AccountsForm()
        {
            InitializeComponent();
            LoadAccountData();
        }

        //Loads account data from the database and populates the UI
        private void LoadAccountData()
        {
            try
            {
                // SQL query to fetch account data
                string selectQuery = "SELECT AccName, AccBalance, Currency.CurrCode FROM Account JOIN Currency ON Account.AccCurrId = Currency.CurrId WHERE UserId=@UserId";
                using (SqlConnection connection = dbConnection.GetCon())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", LoginForm.userId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                string accountBalance = row["AccBalance"].ToString().Trim();
                                string currencyCode = row["CurrCode"].ToString();
                                string accountName = row["AccName"].ToString().Trim();

                                string accountInfo = $"{accountName}\n{accountBalance}  {currencyCode}\n\n___________________________";

                                Guna2Button accountButton = CreateAccountButton(accountInfo);
                                accountButton.Click += (sender, e) => AccountButton_Click(accountName);

                                accountsFlowLayoutPanel.Controls.Add(accountButton);
                            }
                        }
                    }
                }

                // Button to add a new account
                Guna2Button addButton = new Guna2Button
                {
                    Text = "Add new account\n\n\n___________________________",
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 13.75f, FontStyle.Regular),
                    BorderRadius = 20,
                    FillColor = System.Drawing.Color.FromArgb(233, 31, 52),
                    Width = 250,
                    Height = 136,
                    Margin = new Padding(15, 15, 15, 15)
                };

                addButton.Click += AddAccountButton_Click;
                accountsFlowLayoutPanel.Controls.Add(addButton);
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

        //Creates a Guna2Button with specified description
        private Guna2Button CreateAccountButton(string description)
        {
            Guna2Button button = new Guna2Button
            {
                Text = description.Trim(),
                TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 13.75f, FontStyle.Regular),
                BorderRadius = 20,
                FillColor = System.Drawing.Color.FromArgb(30, 41, 59),
                Width = 250,
                Height = 136,
                Margin = new Padding(15, 15, 15, 15),
            };

            return button;
        }

        //Handles the click event of the back button
        private void backButton_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }

        // Handles the click event of the add account button
        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            AddAccountForm addAcc=new AddAccountForm();
            addAcc.Show();
            this.Hide();
        }

        // Handles the click event of an account button
        private void AccountButton_Click(string accountName)
        {
            selectedAccountName = accountName;
            EditAccountForm editAccount = new EditAccountForm();
            editAccount.Show();
            this.Hide();
        }
    }
}
