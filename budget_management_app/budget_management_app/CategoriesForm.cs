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
    public partial class CategoriesForm : Form
    {
        DBConnection dbcon = new DBConnection();
        public static string SelectedCat;
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            getTable();
        }


        // Get data from database, table Category 
        private void getTable()
        {
            string selectQuerry = "SELECT CatName FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_categories.DataSource = table;
        }

        //Exit from CategoriesForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            HomeForm start=new HomeForm();
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

        private void DataGridView_categories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedCat = DataGridView_categories.SelectedRows[0].Cells[0].Value.ToString().Trim();
            SubCategoryForm subCat=new SubCategoryForm();
            subCat.Show();
            this.Hide();
        }
    }
}
