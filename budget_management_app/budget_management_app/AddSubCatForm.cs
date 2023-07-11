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
    public partial class AddSubCatForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public AddSubCatForm()
        {
            InitializeComponent();
        }


        //Exit from AddSubCatForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            SubCategoryForm subCat = new SubCategoryForm();
            subCat.Show();
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


        // Add data to table SubCategory
        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_name.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string insertQuery = "INSERT INTO SubCategory (CatId,SubName,SubType) VALUES((SELECT CatId FROM Category WHERE CatName='" + CategoriesForm.SelectedCat+"'),'" + textBox_name.Text + "','" + ComboBox_type.SelectedItem.ToString() +"')";
                    SqlCommand command = new SqlCommand(insertQuery, dbcon.GetCon());
                    dbcon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Subcategory Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbcon.CloseCon();
                    SubCategoryForm subCat = new SubCategoryForm();
                    subCat.Show();
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
