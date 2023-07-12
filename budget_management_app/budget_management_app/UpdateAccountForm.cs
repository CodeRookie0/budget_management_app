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

namespace budget_management_app
{
    public partial class UpdateAccountForm : Form
    {
        DBConnection dbcon=new DBConnection();
        static string newCurrCode;
        static int newAccCurrId;
        static int accId;
        public UpdateAccountForm()
        {
            InitializeComponent();
            getCurr();
            getData();
            textBox_name.Text = AccountForm.accToUpdate;
        }

        private void getData()
        {
            string selectQuery = "SELECT AccId,AccCurrId, AccBalance,AccName FROM Account WHERE AccName = '"+ AccountForm.accToUpdate+"'";
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();

            int accCurrId=0;
            while (reader.Read())
            {
                accId = reader.GetInt32(0);
                textBox_amount.Text = reader.GetDecimal(2).ToString();
                accCurrId = reader.GetInt32(1);
                label_name_acc.Text = reader.GetString(3).Trim();
            }
            reader.Close();
            string selectQueryCurr = "SELECT CurrCode FROM Currency WHERE CurrId = " + accCurrId;
            SqlCommand commandCurr = new SqlCommand(selectQueryCurr, dbcon.GetCon());
            SqlDataReader readerCurr = commandCurr.ExecuteReader();

            while (readerCurr.Read())
            {
                label_currency.Text=readerCurr.GetString(0).ToString();
            }
            dbcon.CloseCon();
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
                ComboBox_currency.Items.Add(data.Trim());
            }
            reader.Close();
            dbcon.CloseCon();
        }

        // Gets the currency code based on the selected currency name from the ComboBox_currency
        public void getCurrCode()
        {
            string selectQuery = "SELECT CurrCode FROM Currency WHERE CurrName ='" + ComboBox_currency.SelectedItem.ToString() + "'";
            SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            object result = comm.ExecuteScalar();
            if (result != null)
            {
                newCurrCode = result.ToString();
            }
            dbcon.CloseCon();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            AccountForm acc = new AccountForm();
            acc.Show();
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

        private void Button_update_Click(object sender, EventArgs e)
        {
            try
            {
                decimal balance = 0.00m;

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

                if (string.IsNullOrEmpty(textBox_name.Text) || ComboBox_currency.SelectedItem == null)
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // Update the account in the database
                    string updateQuery = "UPDATE Account SET AccName = @AccName, AccBalance = @AccBalance, AccCurrId = @AccCurrId WHERE AccId = @AccId";
                    SqlCommand command = new SqlCommand(updateQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.Parameters.AddWithValue("@AccName", textBox_name.Text);
                    command.Parameters.AddWithValue("@AccBalance", balance);
                    command.Parameters.AddWithValue("@AccCurrId", newAccCurrId);
                    command.Parameters.AddWithValue("@AccId", accId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account Updated Successfully", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Button_update_MouseEnter(object sender, EventArgs e)
        {
            Button_update.BackColor = Color.FromArgb(212, 163, 115);
        }

        private void Button_update_MouseLeave(object sender, EventArgs e)
        {
            Button_update.BackColor = Color.FromArgb(250, 237, 205);
        }

        private void ComboBox_currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCurrCode();
            string selectQuery = "SELECT CurrId FROM Currency WHERE CurrName ='" + ComboBox_currency.SelectedItem.ToString() + "'";
            SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            object result = comm.ExecuteScalar();
            if (result != null)
            {
                newAccCurrId = Convert.ToInt32(result);
            }
            dbcon.CloseCon();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteAccountQuery = "DELETE FROM Account WHERE AccName = " + AccountForm.accToUpdate + " AND UserId= " + LoginForm.userId;

                    string deleteExpensesQuery = "DELETE FROM Expenses WHERE AccId = " + accId + " AND UserId= " + LoginForm.userId;
                    string deleteIncomeQuery = "DELETE FROM Income WHERE AccId =  " + accId + " AND UserId= " + LoginForm.userId;
                    string deleteSavingsQuery = "DELETE FROM Savings WHERE AccId = " + accId + " AND UserId= " + LoginForm.userId;

                    SqlCommand command = new SqlCommand(deleteAccountQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.ExecuteNonQuery();
                    SqlCommand command2 = new SqlCommand(deleteSavingsQuery, dbcon.GetCon());
                    command2.ExecuteNonQuery();
                    SqlCommand command3 = new SqlCommand(deleteAccountQuery, dbcon.GetCon());
                    command3.ExecuteNonQuery();

                    dbcon.CloseCon();
                    MessageBox.Show("Account was Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_delete_MouseEnter(object sender, EventArgs e)
        {
            button_delete.BackColor = Color.FromArgb(242, 182, 182);
        }

        private void button_delete_MouseLeave(object sender, EventArgs e)
        {
            button_delete.BackColor = Color.FromArgb(255, 192, 192);
        }
    }
}
