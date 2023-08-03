using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class AddSubcategoryForm : Form
    {
        // Create a new instance of the DBConnection class to manage database connections
        DBConnection dBConnection =new DBConnection();

        public AddSubcategoryForm()
        {
            InitializeComponent();

            // Set the categoryTextBox to display the selected category from the CategoriesForm
            categoryTextBox.Text = CategoriesForm.selectedCategory;
        }

        // Event handler for the addButton Click event
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the entered subcategory name and selected subcategory type
                string subcategoryName = subcategoryNameTextBox.Text.Trim();
                string subcategoryType = subcategoryTypeComboBox.SelectedItem?.ToString();

                // Check if the subcategory name or type is empty
                if (string.IsNullOrEmpty(subcategoryName) || string.IsNullOrEmpty(subcategoryType))
                {
                    MessageBox.Show("Missing Information. Please enter subcategory name and type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Check if the subcategory name is already taken in either UserSubCat or SubCategory table
                    if (IsSubcategoryNameTaken(subcategoryName))
                    {
                        MessageBox.Show("The entered Subcategory Name is already taken. Please choose a different Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Insert the new subcategory into the UserSubCat table
                    InsertSubcategory(LoginForm.userId, CategoriesForm.selectedCategory, subcategoryName, subcategoryType);


                    MessageBox.Show("Subcategory Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBConnection.CloseCon();

                    SubcategoriesForm subcategories = new SubcategoriesForm();
                    subcategories.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Function to check if the subcategory name is already taken in the database
        private bool IsSubcategoryNameTaken(string subcategoryName)
        {
            // Define SQL queries to check for the subcategory name in UserSubCat and SubCategory tables
            string checkQueryUserSubCat = "SELECT COUNT(*) FROM [UserSubCat] WHERE Us_SubName = @SubcategoryName";
            string checkQuerySubCategory = "SELECT COUNT(*) FROM [SubCategory] WHERE SubName = @SubcategoryName";
            
            dBConnection.OpenCon();

            // Execute the queries with the provided subcategory name as a parameter
            SqlCommand checkCommandUserSubCat = new SqlCommand(checkQueryUserSubCat, dBConnection.GetCon());
            checkCommandUserSubCat.Parameters.AddWithValue("@SubcategoryName", subcategoryName);
            int countUserSubCat = (int)checkCommandUserSubCat.ExecuteScalar();

            SqlCommand checkCommandSubCategory = new SqlCommand(checkQuerySubCategory, dBConnection.GetCon());
            checkCommandSubCategory.Parameters.AddWithValue("@SubcategoryName", subcategoryName);
            int countSubCategory = (int)checkCommandSubCategory.ExecuteScalar();

            dBConnection.CloseCon();

            // Return true if the subcategory name is found in either UserSubCat or SubCategory table, false otherwise
            return countUserSubCat > 0 || countSubCategory > 0;
        }

        // Function to insert the new subcategory into the UserSubCat table
        private void InsertSubcategory(int userId, string selectedCategory, string subcategoryName, string subcategoryType)
        {
            string insertQuery = "INSERT INTO UserSubCat (UserId, Us_CatId, Us_SubName, Us_SubType) VALUES (@UserId, (SELECT CatId FROM Category WHERE CatName = @SelectedCategory), @SubcategoryName, @SubcategoryType)";
            SqlCommand command = new SqlCommand(insertQuery, dBConnection.GetCon());
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@SelectedCategory", selectedCategory);
            command.Parameters.AddWithValue("@SubcategoryName", subcategoryName);
            command.Parameters.AddWithValue("@SubcategoryType", subcategoryType);

            dBConnection.OpenCon();
            command.ExecuteNonQuery();
            dBConnection.CloseCon();
        }

        // Event handler for the backButton Click event
        private void backButton_Click(object sender, EventArgs e)
        {
            SubcategoriesForm subcategories = new SubcategoriesForm();
            subcategories.Show();
            this.Hide();
        }
    }
}
