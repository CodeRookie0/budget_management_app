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

namespace budget_management_app
{
    public partial class TransactionForm : Form
    {
        DBConnection dbcon = new DBConnection();

        public TransactionForm()
        {
            InitializeComponent();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            getAcc();
            getCat();
            getTable();
        }

        // Retrieving data for dataGridView
        public void getTable()
        {
            string query = "SELECT 'Income' AS TransactionType, InDate AS TransactionDate, InAmount AS Amount FROM Income " +
               "UNION ALL " +
               "SELECT 'Expense' AS TransactionType, ExpDate AS TransactionDate, ExpAmount FROM Expense " +
               "UNION ALL " +
               "SELECT 'Savings' AS TransactionType, SavDate AS TransactionDate, SavAmount FROM Savings " +
               "ORDER BY TransactionDate ASC";

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataGridView_transactions.DataSource = dataTable;
        }

        // Retrieving data on existing accounts for combo_box_account
        private void getAcc()
        {
            string selectQuery = "SELECT AccName FROM Account";
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                comboBox_account.Items.Add(data);
            }
            reader.Close();
            dbcon.CloseCon();
        }

        // Retrieving data Categories for combo_box_category
        private void getCat()
        {
            string selectQuery = "SELECT CatName FROM Category";
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                comboBox_category.Items.Add(data);
            }
            reader.Close();
            dbcon.CloseCon();
        }

        //Exit from TransactionForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            StartPageForm start = new StartPageForm();
            start.Show();
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


        // Filtering data in dataGridView
        private void comboBox_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }


        // Update dataGridView based on filters
        private void UpdateDataGridView()
        {
            int selectedAccountId = Convert.ToInt32(comboBox_account.SelectedValue);
            int selectedCategoryId = Convert.ToInt32(comboBox_category.SelectedValue);
            string selectedType = comboBox_type.SelectedItem.ToString();

            string query = "SELECT 'Income' AS TransactionType, InDate AS TransactionDate, InAmount AS Amount FROM Income WHERE AccId  = " + selectedAccountId + "AND CatId = " + selectedCategoryId + " AND 'Income' =" + selectedType +
                           "UNION ALL " +
                           "SELECT 'Expense' AS TransactionType, ExpDate AS TransactionDate, ExpAmount AS Amount FROM Expense WHERE AccId  = " + selectedAccountId + "AND CatId  = " + selectedCategoryId + "AND 'Expense'=" + selectedType +
                           "UNION ALL " +
                           "SELECT 'Savings' AS TransactionType, SavDate AS TransactionDate, SavAmount AS Amount FROM Savings WHERE AccId = " + selectedAccountId + "AND CatId = " + selectedCategoryId + "AND 'Savings'=" + selectedType +
                           "ORDER BY TransactionDate ASC";

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataGridView_transactions.DataSource = dataTable;
        }


        // Clear All Selected filters
        private void label_clear_Click(object sender, EventArgs e)
        {
            comboBox_account.ResetText();
            comboBox_category.ResetText();
            comboBox_type.ResetText();
        }
        // Design of Label_clear
        private void label_clear_MouseEnter(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Red;
        }

        private void label_clear_MouseLeave(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.FromArgb(163, 177, 138);
        }
    }
}
