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
    public partial class AccountForm : Form
    {
        DBConnection dbcon=new DBConnection();
        public static string accToUpdate;
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        // Get data from database, table Account 
        private void getTable()
        {
            string selectQuerry = "SELECT AccName,AccBalance,Cur.CurrCode FROM Account JOIN Currency Cur ON AccCurrId = Cur.CurrId WHERE UserId =" + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_acc.DataSource = table;
            foreach (DataGridViewRow row in DataGridView_acc.Rows)
            {
                row.Height = 50;

                string accName = row.Cells["AccName"].Value.ToString().Trim();
                row.Cells["AccName"].Value = accName;
            }
        }

        //Exit from AccountForm
        private void label_exit_Click(object sender, EventArgs e)
        {
            HomeForm home=new HomeForm();
            home.Show();
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


        // Referral to the AddAccountForm
        private void Button_add_Click(object sender, EventArgs e)
        {
            AddAccountForm addAcc=new AddAccountForm();
            addAcc.Show();
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


        // Referral to the AddAccountForm to retrieve or update info about account
        private void DataGridView_acc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            accToUpdate= DataGridView_acc.SelectedRows[0].Cells[0].Value.ToString().Trim();
            AddAccountForm addAcc = new AddAccountForm();
            addAcc.Show();
            this.Hide();
        }
    }
}
