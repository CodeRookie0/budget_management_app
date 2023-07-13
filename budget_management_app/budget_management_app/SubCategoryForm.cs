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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace budget_management_app
{
    public partial class SubCategoryForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public static string selectedSubCat = "";
        public static string selectedUs_SubCat = "";
        public static string deleteSubCat = "";
        public SubCategoryForm()
        {
            InitializeComponent();
        }

        private void SubCategoryForm_Load(object sender, EventArgs e)
        {
            label_category.Text =CategoriesForm.SelectedCat;
            getCat();
            getTable();
            getMySub();
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

        // Get data from database, table UserSubCat 
        private void getMySub()
        {
            string selectQuerry = "SELECT Us_SubName FROM UserSubCat WHERE Us_CatId =(SELECT CatId FROM Category WHERE CatName='" + CategoriesForm.SelectedCat + "') AND UserId= "+LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_my_subcat.DataSource = table;
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
            HomeForm.lastForm = "";
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

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if (deleteSubCat == "")
            {
                MessageBox.Show("Subcategory not selected or cannot be deleted. Remember that you can only delete subcategories created by you", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this subcategory '" + deleteSubCat + "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM UserSubCat WHERE UserId = @UserId AND Us_SubName = @Us_SubName";

                    SqlCommand command = new SqlCommand(deleteQuery, dbcon.GetCon());
                    command.Parameters.AddWithValue("@UserId", LoginForm.userId);
                    command.Parameters.AddWithValue("@Us_SubName", deleteSubCat);

                    dbcon.OpenCon();
                    command.ExecuteNonQuery();
                    dbcon.CloseCon();

                    getMySub();
                    deleteSubCat = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_delete_MouseEnter(object sender, EventArgs e)
        {
            Button_delete.BackColor = Color.FromArgb(242, 182, 182);
        }

        private void Button_delete_MouseMove(object sender, MouseEventArgs e)
        {
            Button_delete.BackColor = Color.FromArgb(255, 192, 192);
        }

        private void DataGridView_my_subcat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (HomeForm.lastForm == "AddTransactionForm")
            {
                selectedUs_SubCat = DataGridView_my_subcat.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.Hide();
            }
            HomeForm.lastForm = "";
            deleteSubCat = DataGridView_my_subcat.SelectedRows[0].Cells[0].Value.ToString().Trim();
        }
    }
}
