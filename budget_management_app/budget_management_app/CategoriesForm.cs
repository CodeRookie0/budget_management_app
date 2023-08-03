using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class CategoriesForm : Form
    {
        // An instance of the DBConnection class to manage database connections
        DBConnection dbConnection = new DBConnection();

        // A static string to store the selected category for further use in the application
        public static string selectedCategory;
        public CategoriesForm()
        {
            InitializeComponent();

            // Load category data when the form is initialized
            LoadCategoryData();
        }

        // LoadCategoryData method retrieves category data from the database and populates the UI
        private void LoadCategoryData()
        {
            try
            {
                // SQL query to fetch category names from the Category table
                string selectQuery = "SELECT CatName FROM Category";

                using (SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon()))
                {
                    dbConnection.OpenCon();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Loop through each row in the DataTable and create category buttons for display
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string categoryName = row["CatName"].ToString();

                            Guna2Button categoryButton = CreateCategoryButton(categoryName.Trim());

                            // Assign a click event handler to the category button
                            categoryButton.Click += (sender, e) => CategoryButton_Click(categoryName);

                            flowLayoutPanel1.Controls.Add(categoryButton);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseCon();
            }
        }

        // CreateCategoryButton method creates a Guna2Button with specified category description
        private Guna2Button CreateCategoryButton(string description)
        {
            Guna2Button button = new Guna2Button
            {
                Text = description,
                TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
                ForeColor = Color.FromArgb(100,120,130),
                Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 13.75f, FontStyle.Regular),
                FillColor = System.Drawing.Color.White,
                BorderRadius=5,
                Width =550,
                Height=50,
                Margin = new Padding(15,2,15,2),
            };
            button.MouseEnter += (sender, e) =>
            {
                button.FillColor = Color.FromArgb(233,31,52);
                button.ForeColor=Color.White;
            }; 
            button.MouseLeave += (sender, e) =>
            {
                button.FillColor = Color.White;
                button.ForeColor = Color.FromArgb(100,120,130);
            };
            return button;
        }

        // Event handler for the category button click
        private void CategoryButton_Click(string categoryName)
        {
            selectedCategory = categoryName;
            SubCategoryForm subCat = new SubCategoryForm();
            subCat.Show();
            this.Hide();
        }

        // Event handlers for various button clicks to navigate to other forms
        private void homeButton_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }

        private void accountsButton_Click(object sender, EventArgs e)
        {
            AccountsForm acc = new AccountsForm();
            acc.Show();
            this.Hide();
        }
        private void transactionsButton_Click(object sender, EventArgs e)
        {
            TransactionsHistoryForm trns = new TransactionsHistoryForm();
            trns.Show();
            this.Hide();
        }

        private void statisticButtonBar_Click(object sender, EventArgs e)
        {
            StatisticsForm stat = new StatisticsForm();
            stat.Show();
            this.Hide();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm set = new SettingsForm();
            set.Show();
            this.Hide();
        }
    }
}
