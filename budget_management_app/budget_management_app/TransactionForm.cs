using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class TransactionForm : Form
    {
        DBConnection dbcon = new DBConnection();

        static int selectedAccountId=-1;
        static int selectedCategoryId=-1;
        static string selectedType;
        static int selectedTrnsId = -1;
        static string selecetedTrnsType = "";

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
            string query = "SELECT 'Income' AS TransactionType, Income.InId AS TransactionId, Account.AccName, Category.CatName,Income.InDate AS TransactionDate, '+' + CAST(Income.InAmount AS VARCHAR) AS Amount FROM Income " +
               " JOIN Account ON Income.AccId = Account.AccId " +"JOIN Category ON Income.CatId = Category.CatId "+
               " WHERE Income.UserId =" + LoginForm.userId+
               " UNION ALL " +
               " SELECT 'Expenses' AS TransactionType, Expenses.ExpId AS TransactionId,  Account.AccName, Category.CatName,Expenses.ExpDate AS TransactionDate, '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
               " JOIN Account ON Expenses.AccId = Account.AccId " +
               " JOIN Category ON Expenses.CatId = Category.CatId " +
               " WHERE Expenses.UserId = " + LoginForm.userId+
               " UNION ALL " +
               " SELECT 'Savings' AS TransactionType, Savings.SavId AS TransactionId,  Account.AccName, Category.CatName,Savings.SavDate AS TransactionDate, '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount FROM Savings " +
               " JOIN Account ON Savings.AccId = Account.AccId " +
               " JOIN Category ON Savings.CatId = Category.CatId " +
               " WHERE Savings.UserId = " + LoginForm.userId +
               " ORDER BY TransactionDate DESC";

            SqlCommand command = new SqlCommand(query, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (row[i] != null && row[i] != DBNull.Value)
                    {
                        row[i] = row[i].ToString().Trim();
                    }
                }
                
            }

            DataGridView_transactions.DataSource = dataTable;
            DataGridView_transactions.Columns["TransactionDate"].DefaultCellStyle.Format = "dd MMM yyyy";
            DataGridView_transactions.Columns["TransactionType"].Visible = false;
            DataGridView_transactions.Columns["TransactionId"].Visible = false;

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

            string query = "SELECT 'Income' AS TransactionType, Income.InId AS TransactionId, Account.AccName AS AccName, Category.CatName AS CatName,Income.InDate AS TransactionDate," +
                " '+' + CAST(Income.InAmount AS VARCHAR) AS Amount FROM Income " +
               " JOIN Account ON Income.AccId = Account.AccId " + "JOIN Category ON Income.CatId = Category.CatId " +
               " WHERE Income.UserId = " + LoginForm.userId;

            if (selectedType == null)
            {
                if (selectedAccountId != -1)
                {
                    query += " AND Income.AccId = " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Income.CatId = " + selectedCategoryId;
                }

                query += " UNION ALL " +
                         "SELECT 'Expenses' AS TransactionType, Expenses.ExpId AS TransactionId, Account.AccName AS AccName, Category.CatName AS CatName,Expenses.ExpDate AS TransactionDate," +
                         " '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
               " JOIN Account ON Expenses.AccId = Account.AccId " + "JOIN Category ON Expenses.CatId = Category.CatId " +
               " WHERE Expenses.UserId =" + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Expenses.AccId = " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Expenses.CatId = " + selectedCategoryId;
                }

                query += " UNION ALL " +
                        "SELECT 'Savings' AS TransactionType, Savings.SavId AS TransactionId,Account.AccName AS AccName, Category.CatName AS CatName,Savings.SavDate AS TransactionDate," +
                        " '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount FROM Savings " +
               " JOIN Account ON Savings.AccId = Account.AccId " + "JOIN Category ON Savings.CatId = Category.CatId " +
               " WHERE Savings.UserId = " + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Savings.AccId = " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Savings.CatId = " + selectedCategoryId;
                }
                query += "ORDER BY TransactionDate DESC";
            }
            else if (selectedType == "Income")
            {
                if (selectedAccountId != -1)
                {
                    query += " AND Income.AccId = " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Income.CatId = " + selectedCategoryId;
                }
                query += "ORDER BY TransactionDate DESC";
            }
            else if (selectedType == "Expenses")
            {
                query = "SELECT 'Expenses' AS TransactionType, Expenses.ExpId AS TransactionId, Account.AccName AS AccName, Category.CatName AS CatName,Expenses.ExpDate AS TransactionDate," +
                    " '-' + CAST(Expenses.ExpAmount AS VARCHAR) AS Amount FROM Expenses " +
               " JOIN Account ON Expenses.AccId = Account.AccId " + "JOIN Category ON Expenses.CatId = Category.CatId " +
               " WHERE Expenses.UserId = " + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Expenses.AccId = " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Expenses.CatId = " + selectedCategoryId;
                }
                query += "ORDER BY TransactionDate DESC";
            }
            else
            {
                query = "SELECT 'Savings' AS TransactionType, Savings.SavId AS TransactionId, Account.AccName AS AccName, Category.CatName AS CatName,Savings.SavDate AS TransactionDate," +
                    " '-' + CAST(Savings.SavAmount AS VARCHAR) AS Amount FROM Savings " +
               " JOIN Account ON Savings.AccId = Account.AccId " + "JOIN Category ON Savings.CatId = Category.CatId " +
               " WHERE Savings.UserId = " + LoginForm.userId;

                if (selectedAccountId != -1)
                {
                    query += " AND Savings.AccId = " + selectedAccountId;
                }
                if (selectedCategoryId != -1)
                {
                    query += " AND Savings.CatId = " + selectedCategoryId;
                }
                query += "ORDER BY TransactionDate DESC";
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

        private void Button_add_Click(object sender, EventArgs e)
        {
            AddTransactionForm addTrns=new AddTransactionForm();
            addTrns.Show();
            this.Hide();
        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTrnsId == -1)
                {
                    MessageBox.Show("Have not selected a transaction to delete. Please, try again", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete selected transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string deleteQuery = "";
                    if (selecetedTrnsType == "Income")
                    {
                        deleteQuery= "DELETE FROM Income WHERE InId =  " + selectedTrnsId + " AND UserId= " + LoginForm.userId;
                    }
                    else if (selecetedTrnsType == "Expenses")
                    {
                        deleteQuery = "DELETE FROM Expenses WHERE ExpId = " + selectedTrnsId + " AND UserId= " + LoginForm.userId;
                    }
                    else
                    {
                        deleteQuery = "DELETE FROM Savings WHERE SavId = " + selectedTrnsId + " AND UserId= " + LoginForm.userId;
                    }

                    SqlCommand command = new SqlCommand(deleteQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.ExecuteNonQuery();

                    dbcon.CloseCon();
                    MessageBox.Show("Transaction was Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                selectedTrnsId = -1;
                selecetedTrnsType = "";
                getTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_transactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selecetedTrnsType = DataGridView_transactions.Rows[e.RowIndex].Cells["TransactionType"].Value.ToString();
                selectedTrnsId = Convert.ToInt32(DataGridView_transactions.Rows[e.RowIndex].Cells["TransactionId"].Value.ToString());
            }
        }

    }
}
