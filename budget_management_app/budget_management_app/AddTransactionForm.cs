using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace budget_management_app
{
    public partial class AddTransactionForm : Form
    {
        DBConnection dbcon=new DBConnection();
        static string selectedAcc ="";
        static int accId;
        static int subCatId;
        static int catId;
        public AddTransactionForm()
        {
            InitializeComponent();
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            maskedTextBox_date.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            getAcc();
            getCat();
        }

        // Retrieving the currency code for the given account
        private void getCurr()
        {
            string selectQuery = "SELECT Currency.CurrCode " +
                     "FROM Account " +
                     "JOIN Currency ON Account.AccCurrId = Currency.CurrId " +
                     "WHERE Account.AccName ='"+ ComboBox_account.SelectedItem.ToString()+"'";
            dbcon.OpenCon();
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            string currCode=command.ExecuteScalar()?.ToString();
            dbcon.CloseCon();
            label_currency.Text =currCode;
        }

        // Retrieving data on existing accounts for combo_box_account
        private void getAcc() 
        {
            string selectQuery = "SELECT AccName FROM Account WHERE Account.UserId="+LoginForm.userId;
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

        // Retrieving data on existing categories for combo_box_cat
        private void getCat()
        {
            string selectQuery = "SELECT CatName FROM Category";
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                ComboBox_cat.Items.Add(data.Trim());
            }
            reader.Close();
            dbcon.CloseCon();
        }


        //Exit from AddTransactionForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            HomeForm start = new HomeForm();
            start.Show();
            this.Close();
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
            getCurr();
            selectedAcc=ComboBox_account.SelectedItem.ToString();
        }

        private void ComboBox_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriesForm.SelectedCat=ComboBox_cat.SelectedItem.ToString();
            HomeForm.lastForm = "AddTransactionForm";
            SubCategoryForm subcat=new SubCategoryForm();
            subcat.Show();
        }

        private void getSubCatId()
        {
            string selectQuery = "SELECT SubId FROM SubCategory WHERE SubName = @SubName";
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            command.Parameters.AddWithValue("@SubName", SubCategoryForm.selectedSubCat);
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                subCatId = reader.GetInt32(0);
            }

            reader.Close();
            dbcon.CloseCon();
        }
        private void getCatId()
        {
            string selectQuery = "SELECT CatId FROM Category WHERE CatName = @CatName";
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            command.Parameters.AddWithValue("@CatName", CategoriesForm.SelectedCat);
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                catId = reader.GetInt32(0);
            }

            reader.Close();
            dbcon.CloseCon();
        }
        private void getAccId()
        {
            string selectQuery = "SELECT AccId FROM Account WHERE AccName ='"+selectedAcc+ "' AND UserId="+LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                accId = reader.GetInt32(0);
            }

            reader.Close();
            dbcon.CloseCon();
        }

        // Add data to Transaction table(Income or Expenses or Savings)
        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount=0.00m;

                if (string.IsNullOrEmpty(textBox_amount.Text))
                {
                    MessageBox.Show("Invalid entered transaction value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!decimal.TryParse(textBox_amount.Text.Replace('.', ','), out amount))
                {
                    MessageBox.Show("Invalid entered transaction value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (amount <= 0m)
                    {
                        MessageBox.Show("Invalid entered transaction value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string insertQuery = "";

                if (CategoriesForm.SelectedCat == ""||selectedAcc==""|| ComboBox_type.SelectedItem == null|| string.IsNullOrWhiteSpace(maskedTextBox_date.Text))
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(!DateTime.TryParseExact(maskedTextBox_date.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime userDate))
                {
                    MessageBox.Show("Incorrect data. Please, try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (userDate > DateTime.Today)
                {
                    MessageBox.Show("Incorrect data. Please, try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    getCatId();
                    getAccId();

                    if (SubCategoryForm.selectedSubCat != "")
                    {
                        getSubCatId();
                        if (ComboBox_type.SelectedItem.ToString() == "Income")
                        {
                            insertQuery = "INSERT INTO Income (UserId, AccId, CatId, SubId, InAmount, InDate) VALUES (@UserId, @AccId, @CatId, @SubId, @Amount, @Date)";
                        }
                        else if (ComboBox_type.SelectedItem.ToString() == "Expenses")
                        {
                            insertQuery = "INSERT INTO Expenses (UserId, AccId, CatId, SubId, ExpAmount, ExpDate) VALUES (@UserId, @AccId, @CatId, @SubId, @Amount, @Date)";
                        }
                        else if (ComboBox_type.SelectedItem.ToString() == "Savings")
                        {
                            insertQuery = "INSERT INTO Savings (UserId, AccId, CatId, SubId, SavAmount, SavDate) VALUES (@UserId, @AccId, @CatId, @SubId, @Amount, @Date)";
                        }
                        SubCategoryForm.selectedSubCat = "";
                    }
                    else
                    {
                        if (ComboBox_type.SelectedItem.ToString() == "Income")
                        {
                            insertQuery = "INSERT INTO Income (UserId, AccId, CatId, InAmount, InDate) VALUES (@UserId, @AccId, @CatId, @Amount, @Date)";
                        }
                        else if (ComboBox_type.SelectedItem.ToString() == "Expenses")
                        {
                            insertQuery = "INSERT INTO Expenses (UserId, AccId, CatId, ExpAmount, ExpDate) VALUES (@UserId, @AccId, @CatId, @Amount, @Date)";
                        }
                        else if (ComboBox_type.SelectedItem.ToString() == "Savings")
                        {
                            insertQuery = "INSERT INTO Savings (UserId, AccId, CatId, SavAmount, SavDate) VALUES (@UserId, @AccId, @CatId, @Amount, @Date)";
                        }
                    }
                    CategoriesForm.SelectedCat = "";

                    SqlCommand command = new SqlCommand(insertQuery, dbcon.GetCon());
                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    command.Parameters.AddWithValue("@AccId", accId);
                    command.Parameters.AddWithValue("@CatId", catId);
                    command.Parameters.AddWithValue("@SubId", subCatId);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Date", userDate);

                    dbcon.OpenCon();
                    command.ExecuteNonQuery();

                    string updateQuery = "";
                    if (ComboBox_type.SelectedItem.ToString() == "Income")
                    {
                        updateQuery = "UPDATE Account SET AccBalance = (AccBalance + @Amount) WHERE UserId = @UserId AND AccId = @AccId";
                    }
                    else
                    {
                        updateQuery = "UPDATE Account SET AccBalance = (AccBalance - @Amount) WHERE UserId = @UserId AND AccId = @AccId";
                    }
                    SqlCommand comm = new SqlCommand(updateQuery, dbcon.GetCon());

                    comm.Parameters.AddWithValue("@Amount", amount);
                    comm.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    comm.Parameters.AddWithValue("@AccId", accId);

                    comm.ExecuteNonQuery();

                    MessageBox.Show("Transaction Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbcon.CloseCon();
                    TransactionForm trns = new TransactionForm();
                    trns.Show();
                    this.Hide();

                }
            }
            catch(Exception ex)
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
