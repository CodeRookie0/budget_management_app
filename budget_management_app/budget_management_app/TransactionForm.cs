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

        static int selectedAccountId=-1;
        static int selectedCategoryId=-1;
        static string selectedType;

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
            string query = "SELECT Account.AccName, Category.CatName,CONVERT(varchar, InDate, 107) AS TransactionDate, '+' + CAST(Income.InAmount AS VARCHAR) AS Amount FROM Income " +
               " JOIN Account ON Income.AccId = Account.AccId " +"JOIN Category ON Income.CatId = Category.CatId "+
               " WHERE Income.UserId =" + LoginForm.userId+
               " UNION ALL " +
               " SELECT   Account.AccName, Category.CatName,CONVERT(varchar, ExpDate, 107) AS TransactionDate, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
               " JOIN Account ON Expenses.AccId = Account.AccId " +
               " JOIN Category ON Expenses.CatId = Category.CatId " +
               " WHERE Expenses.UserId = " + LoginForm.userId+
               " UNION ALL " +
               " SELECT   Account.AccName, Category.CatName,CONVERT(varchar, SavDate, 107) AS TransactionDate, '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount FROM Savings " +
               " JOIN Account ON Savings.AccId = Account.AccId " +
               " JOIN Category ON Savings.CatId = Category.CatId " +
               " WHERE Savings.UserId = " + LoginForm.userId +
               " ORDER BY TransactionDate ASC";

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataGridView_transactions.DataSource = dataTable;
        }

        // Retrieving data on existing accounts for combo_box_account
        private void getAcc()
        {
            string selectQuery = "SELECT AccName FROM Account WHERE UserId = " + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                comboBox_account.Items.Add(data.Trim());
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
                comboBox_category.Items.Add(data.Trim());
            }
            reader.Close();
            dbcon.CloseCon();
        }

        //Exit from TransactionForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            HomeForm start = new HomeForm();
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
            if (comboBox_account.SelectedItem != null)
            {
                string selectQuery = "SELECT AccId FROM Account WHERE AccName ='" + comboBox_account.SelectedItem.ToString() + "' AND UserId="+LoginForm.userId;
                SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
                dbcon.OpenCon();
                object result = comm.ExecuteScalar();
                if (result != null)
                {
                    selectedAccountId = Convert.ToInt32(result);
                }
                dbcon.CloseCon();
                UpdateDataGridView();
            }
        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_category.SelectedItem != null)
            {
                string selectQuery = "SELECT CatId FROM Category WHERE CatName ='" + comboBox_category.SelectedItem.ToString() + "'";
                SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
                dbcon.OpenCon();
                object result = comm.ExecuteScalar();
                if (result != null)
                {
                    selectedCategoryId = Convert.ToInt32(result);
                }
                dbcon.CloseCon();
                UpdateDataGridView();
            }
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_type.SelectedItem != null)
            {
                selectedType = comboBox_type.SelectedItem.ToString();
                UpdateDataGridView();
            }
        }


        // Update dataGridView based on filters
        private void UpdateDataGridView()
        {

            string query = "SELECT Account.AccName AS AccName, Category.CatName AS CatName,CONVERT(varchar, InDate, 105) AS TransDate, '+' + CAST(Income.InAmount AS VARCHAR) AS Amount FROM Income " +
               " JOIN Account ON Income.AccId = Account.AccId " + "JOIN Category ON Income.CatId = Category.CatId " +
               " WHERE Income.UserId =" + LoginForm.userId;

            if (selectedType == null)
            {
                if (selectedAccountId != -1)
                {
                    query += " AND Income.AccId =  " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Income.CatId = " + selectedCategoryId;
                }

                query += "UNION ALL " +
                         "SELECT Account.AccName AS AccName, Category.CatName AS CatName,CONVERT(varchar, ExpDate, 105) AS TransDate, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
               " JOIN Account ON Expenses.AccId = Account.AccId " + "JOIN Category ON Expenses.CatId = Category.CatId " +
               " WHERE Expenses.UserId =" + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Expenses.AccId =  " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Expenses.CatId = " + selectedCategoryId;
                }

                query += "UNION ALL " +
                        "SELECT Account.AccName AS AccName, Category.CatName AS CatName,CONVERT(varchar, SavDate, 105) AS TransDate, '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount FROM Savings " +
               " JOIN Account ON Savings.AccId = Account.AccId " + "JOIN Category ON Savings.CatId = Category.CatId " +
               " WHERE Savings.UserId =" + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Savings.AccId =  " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Savings.CatId = " + selectedCategoryId;
                }
                query += "ORDER BY TransDate ASC";
            }
            else if (selectedType == "Income")
            {
                if (selectedAccountId != -1)
                {
                    query += " AND Income.AccId =  " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Income.CatId = " + selectedCategoryId;
                }
            }
            else if (selectedType == "Expenses")
            {
                query = "SELECT Account.AccName AS AccName, Category.CatName AS CatName,CONVERT(varchar, ExpDate, 105) AS TransDate, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
               " JOIN Account ON Expenses.AccId = Account.AccId " + "JOIN Category ON Expenses.CatId = Category.CatId " +
               " WHERE Expenses.UserId =" + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Expenses.AccId =  " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Expenses.CatId = " + selectedCategoryId;
                }
            }
            else
            {
                query = "SELECT Account.AccName AS AccName, Category.CatName AS CatName,CONVERT(varchar, SavDate, 105) AS TransDate, '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount FROM Savings " +
               " JOIN Account ON Savings.AccId = Account.AccId " + "JOIN Category ON Savings.CatId = Category.CatId " +
               " WHERE Savings.UserId =" + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Savings.AccId =  " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Savings.CatId = " + selectedCategoryId;
                }
            }

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
            selectedAccountId = -1;
            selectedCategoryId = -1;
            selectedType=null;
            getTable();
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
