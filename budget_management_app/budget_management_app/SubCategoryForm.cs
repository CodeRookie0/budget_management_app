using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class SubCategoryForm : Form
    {
        public SubCategoryForm()
        {
            InitializeComponent();
        }

        //Exit from SubCategoryForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            CategoriesForm cat = new CategoriesForm();
            cat.Show();
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
    }
}
