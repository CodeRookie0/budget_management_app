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
    public partial class AddAccountForm : Form
    {
        DBConnection dbcon = new DBConnection();
        static int currId = 0;
        static string currCode = "USD";
        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {
            getCurr();
        }

        // Getting currency from Currency table
        private void getCurr()
        {
            string selectQuery = "SELECT CurrName From Currency";
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                ComboBox_currency.Items.Add(data);
            }
            reader.Close();
            dbcon.CloseCon();
        }
        // Gets the currency code based on the selected currency name from the ComboBox_currency
        public void getCurrCode()
        {
            string selectQuery = "SELECT CurrCode FROM Currency WHERE CurrName ='" + ComboBox_currency.SelectedItem.ToString()+"'";
            SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            object result = comm.ExecuteScalar();
            if (result != null)
            {
                currCode = result.ToString();
            }
            dbcon.CloseCon();
        }
        // Gets the currency ID based on the selected value from the ComboBox_currency
        private void selectedCurrId()
        {
            string selectQuery = "SELECT CurrId FROM Currency WHERE CurrName ='" + ComboBox_currency.SelectedItem.ToString()+"'";
            SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            object result = comm.ExecuteScalar();
            if (result != null)
            {
                currId = Convert.ToInt32(result);
            }
            dbcon.CloseCon();
        }

        //Exit from AddAccountForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            AccountForm acc = new AccountForm();
            acc.Show();
            this.Hide();
        }
        // Design of label_exit
        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.White;
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.FromArgb(212, 148, 85);
        }

        private void ComboBox_currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCurrCode();
            label_currency.Text = currCode;
        }


        // Add data to Account table
        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                decimal balance=0.00m;

                if (string.IsNullOrEmpty(textBox_amount.Text))
                {
                    MessageBox.Show("Starting balance value is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!decimal.TryParse(textBox_amount.Text.Replace('.', ','), out balance))
                {
                    MessageBox.Show("Invalid entered starting balance value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (balance < 0m)
                    {
                        MessageBox.Show("Invalid entered starting balance value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (textBox_name.Text == ""|| ComboBox_currency.SelectedItem == null)
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // Checking the existence of such a account name in the data base
                    string checkQuery_accname = "SELECT COUNT(*) FROM Account WHERE AccName='" + textBox_name.Text + "'";
                    dbcon.OpenCon();
                    SqlCommand checkCommand_accname = new SqlCommand(checkQuery_accname, dbcon.GetCon());
                    int count = (int)checkCommand_accname.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The entered Account Name is already exists. Please choose a different Account Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    selectedCurrId();
                    string insertQuery = "INSERT INTO Account (UserId, AccName, AccBalance, AccCurrId) VALUES (@UserId, @AccName, @AccBalance, @AccCurrId)";
                    SqlCommand command = new SqlCommand(insertQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    command.Parameters.AddWithValue("@AccName", textBox_name.Text);
                    command.Parameters.AddWithValue("@AccBalance", balance);
                    command.Parameters.AddWithValue("@AccCurrId", currId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbcon.CloseCon();
                    AccountForm acc = new AccountForm();
                    acc.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Design of Button_add
        private void Button_add_MouseEnter(object sender, EventArgs e)
        {
            Button_add.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_add_MouseLeave(object sender, EventArgs e)
        {
            Button_add.BackColor = Color.FromArgb(250, 237, 205);
        }
    }
}
