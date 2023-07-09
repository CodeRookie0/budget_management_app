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
    public partial class SubCategoryForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public static string selectedSubCat = "";
        public SubCategoryForm()
        {
            InitializeComponent();
        }

        private void SubCategoryForm_Load(object sender, EventArgs e)
        {
            label_category.Text =CategoriesForm.SelectedCat;
            getCat();
            getTable();
        }

        // Get data from database, table Category 
        private void getCat()
        {
            string selectQuerry = "SELECT CatName FROM Category WHERE CatName ='"+CategoriesForm.SelectedCat+"'";
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_selectedCat.DataSource = table;
        }


        // Get data from database, table SubCat 
        private void getTable()
        {
            string selectQuerry = "SELECT SubName FROM SubCategory WHERE CatId =(SELECT CatId FROM Category WHERE CatName='" + CategoriesForm.SelectedCat+"')";
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_subcat.DataSource = table;
        }


        //Exit from SubCategoryForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            if (HomeForm.lastForm == "AddTransactionForm")
            {
                AddTransactionForm trns = new AddTransactionForm();
                trns.Show();
                this.Hide();
            }
            else
            {
                CategoriesForm cat = new CategoriesForm();
                cat.Show();
                this.Hide();
            }
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



        // Referral to the AddSubCatForm
        private void Button_add_Click(object sender, EventArgs e)
        {
            AddSubCatForm add = new AddSubCatForm();
            add.Show();
            this.Hide();
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

        private void DataGridView_selectedCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (HomeForm.lastForm == "AddTransactionForm")
            {
                this.Hide();
            }
        }

        private void DataGridView_subcat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (HomeForm.lastForm == "AddTransactionForm")
            {
                selectedSubCat = DataGridView_subcat.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.Hide();
            }
            HomeForm.lastForm = "";
        }
    }
}
