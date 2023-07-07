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
    public partial class AddAccountForm : Form
    {
        DBConnection dbcon=new DBConnection();
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
            label_exit.ForeColor = Color.FromArgb(212, 148, 85);
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.White;
        }

        private void ComboBox_currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label_currency
            //data from table Currency
        }


        // Add data to Account table
        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                decimal balance = Convert.ToDecimal(textBox_amount.Text);
                int currId = 0;

                string selectQuery = "SELECT CurrId FROM Currency WHERE CurrName ="+ ComboBox_currency.SelectedIndex.ToString();
                SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
                object result = comm.ExecuteScalar();
                if (result != null)
                {
                    currId = Convert.ToInt32(result);
                }

                if (textBox_name.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (balance <= 0)
                {
                    MessageBox.Show("Invalid entered starting balance value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string insertQuery = "INSERT INTO Account VALUES " + LoginForm.userId + ",'" + textBox_name.Text + "','" + balance + "'," + currId;
                    SqlCommand command = new SqlCommand(insertQuery, dbcon.GetCon());
                    dbcon.OpenCon();
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
