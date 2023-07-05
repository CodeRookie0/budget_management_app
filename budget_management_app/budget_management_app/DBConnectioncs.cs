using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace budget_management_app
{
    internal class DBConnectioncs
    {
        private SqlConnection connection=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maria\Desktop\Projects_MWFs\budget_management_app\budget_management_app\Budget_management.mdf;Integrated Security=True");
        public SqlConnection GetCon()
        {
            return connection;
        }
        public void OpenCon()
        {
            if(connection.State==System.Data.ConnectionState.Closed) 
            {
            connection.Open();
            }
        }
        public void CloseCon()
        {
            if(connection.State==System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
