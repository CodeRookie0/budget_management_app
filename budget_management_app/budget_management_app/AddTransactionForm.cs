﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace budget_management_app
{
    public partial class AddTransactionForm : Form
    {
        DBConnection dbcon=new DBConnection();
        static string selectedAcc="";
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
                     "WHERE Account.AccName ="+ ComboBox_account.SelectedIndex.ToString();
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

        private void ComboBox_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCurr();
            selectedAcc=ComboBox_account.SelectedIndex.ToString();
        }

        private void button_category_Click(object sender, EventArgs e)
        {
            CategoriesForm cat=new CategoriesForm();
            StartPageForm.lastForm = "AddTransactionForm";
            cat.Show();
        }

        // Add data to Transaction table(Income or Expenses or Savings)
        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount;
                if (CategoriesForm.SelectedCat == ""||selectedAcc=="")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(decimal.TryParse(textBox_amount.Text, out amount) || amount < 0.00m)
                {
                    MessageBox.Show("Invalid entered transaction value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string insertQuery="";
                    if (SubCategoryForm.selectedSubCat != "")
                    {
                        if (ComboBox_type.SelectedItem.ToString() == "Income")
                        {
                            insertQuery = "INSERT INTO Income (UserId,AccId,CatId,SubId,InAmount,InDate) VALUES " + LoginForm.userId + ",'" + selectedAcc + "','" + CategoriesForm.SelectedCat + "','" + SubCategoryForm.selectedSubCat + "'," + amount + ",'" + maskedTextBox_date.Text + "'";
                        }
                        else if(ComboBox_type.SelectedItem.ToString() == "Expenses")
                        {
                            insertQuery = "INSERT INTO Expenses (UserId,AccId,CatId,SubId,ExpAmount,ExpDate) VALUES " + LoginForm.userId + ",'" + selectedAcc + "','" + CategoriesForm.SelectedCat + "','" + SubCategoryForm.selectedSubCat + "'," + amount + ",'" + maskedTextBox_date.Text + "'";
                        }
                        else if (ComboBox_type.SelectedItem.ToString() == "Savings")
                        {
                            insertQuery = "INSERT INTO Savings (UserId,AccId,CatId,SubId,SavAmount,SavDate) VALUES " + LoginForm.userId + ",'" + selectedAcc + "','" + CategoriesForm.SelectedCat + "','" + SubCategoryForm.selectedSubCat + "'," + amount + ",'" + maskedTextBox_date.Text + "'";
                        }
                        SubCategoryForm.selectedSubCat = "";
                    }
                    else
                    {
                        if (ComboBox_type.SelectedItem.ToString() == "Income")
                        {
                            insertQuery = "INSERT INTO Income (UserId,AccId,CatId,SubId,InAmount,InDate) VALUES " + LoginForm.userId + ",'" + selectedAcc + "','" + CategoriesForm.SelectedCat + "'," + amount + ",'" + maskedTextBox_date.Text + "'";
                        }
                        else if (ComboBox_type.SelectedItem.ToString() == "Expenses")
                        {
                            insertQuery = "INSERT INTO Expenses (UserId,AccId,CatId,SubId,ExpAmount,ExpDate) VALUES " + LoginForm.userId + ",'" + selectedAcc + "','" + CategoriesForm.SelectedCat + "'," + amount + ",'" + maskedTextBox_date.Text + "'";
                        }
                        else if (ComboBox_type.SelectedItem.ToString() == "Savings")
                        {
                            insertQuery = "INSERT INTO Savings (UserId,AccId,CatId,SubId,SavAmount,SavDate) VALUES " + LoginForm.userId + ",'" + selectedAcc + "','" + CategoriesForm.SelectedCat + "'," + amount + ",'" + maskedTextBox_date.Text + "'";
                        }
                    }
                    CategoriesForm.SelectedCat = "";
                    SqlCommand command = new SqlCommand(insertQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.ExecuteNonQuery();
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
