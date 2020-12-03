using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AppFinal
{
    class DatabaseConn
    {
        string strCon = Properties.Settings.Default.bookshopConnString;
        public SqlConnection Conn = new SqlConnection();

        public void ConnectDB()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            else
            {
                Conn.ConnectionString = strCon;
                Conn.Open();
            }

        }
    }
}
