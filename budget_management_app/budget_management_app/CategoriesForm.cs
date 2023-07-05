﻿using System;
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
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void getTable()
        {
            string selectQuerry = "SELECT CatName FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry, dbcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_categories.DataSource = table;
        }
    }
}
