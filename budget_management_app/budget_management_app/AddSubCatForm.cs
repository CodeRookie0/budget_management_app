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
                    // Checking the existence of such a Subcategory name in the data base
                    string checkQuery_name = "SELECT COUNT(*) FROM [UserSubCat] WHERE Us_SubName='" + textBox_name.Text + "'";
                    dbcon.OpenCon();
                    SqlCommand checkCommand_name = new SqlCommand(checkQuery_name, dbcon.GetCon());
                    int count = (int)checkCommand_name.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The entered Subcategory Name is already taken. Please choose a different Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Checking the existence of such a Subcategory name in the data base
                    string checkQuery_Name = "SELECT COUNT(*) FROM [SubCategory] WHERE SubName='" + textBox_name.Text + "'";
                    dbcon.OpenCon();
                    SqlCommand checkCommand_Name = new SqlCommand(checkQuery_Name, dbcon.GetCon());
                    int count2 = (int)checkCommand_Name.ExecuteScalar();

                    if (count2 > 0)
                    {
                        MessageBox.Show("The entered Subcategory Name is already taken. Please choose a different Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    string insertQuery = "INSERT INTO UserSubCat (UserId,Us_CatId,Us_SubName,Us_SubType) VALUES( "+LoginForm.userId+",(SELECT CatId FROM Category WHERE CatName='" + CategoriesForm.SelectedCat+"'),'" + textBox_name.Text + "','" + ComboBox_type.SelectedItem.ToString() +"')";
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
