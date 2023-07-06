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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace budget_management_app
{
    public partial class AddTransactionForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public AddTransactionForm()
        {
            InitializeComponent();
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            getAcc();
        }

        // Retrieving the currency code for the given account
        private void getCurr()
        {
            string selectQuery = "SELECT Currency.CurrCode " +
                     "FROM Account " +
                     "JOIN Currency ON Account.AccCurrId = Currency.CurrId " +
                     "WHERE Account.AccName ="+selectedAcc;
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            string currCode=command.ExecuteScalar()?.ToString();
            label_currency.Text =currCode;
        }

        // Retrieving data on existing accounts for combo_box_account
        private void getAcc() 
        {
            string selectQuery = "SELECT AccName FROM Account";
            SqlCommand command=new SqlCommand(selectQuery,dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                ComboBox_account.Items.Add(data);
            }
            reader.Close();
            dbcon.CloseCon();
        }


        //Exit from AddTransactionForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            TransactionForm trns = new TransactionForm();
            trns.Show();
            this.Hide();
        }
        // Design of label_exit
        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.FromArgb(212, 148, 85);
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.White;
        }

        private void ComboBox_account_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_category_Click(object sender, EventArgs e)
        {
            CategoriesForm cat=new CategoriesForm();
            cat.Show();
            this.Hide();
        }

        private void Button_add_Click(object sender, EventArgs e)
        {

        }

        private void Button_add_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Button_add_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
