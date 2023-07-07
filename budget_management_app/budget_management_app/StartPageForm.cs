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
    public partial class StartPageForm : Form
    {
        public StartPageForm()
        {
            InitializeComponent();
        }

        private void StartPageForm_Load(object sender, EventArgs e)
        {
            TransactionForm trns=new TransactionForm();
            trns.Show();
            this.Hide();
        }
    }
}
