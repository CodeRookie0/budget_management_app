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
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'budget_managementDataSet1.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.budget_managementDataSet1.Category);

        }
    }
}
