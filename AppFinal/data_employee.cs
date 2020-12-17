using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AppFinal
{
    public partial class data_employee : Form
    {
        public data_employee()
        {
            InitializeComponent();
        }
        DatabaseConn objcon;
        SqlDataAdapter daDep;
        DataSet ds = new DataSet();
        string strSQL;
        private void data_employee_Load(object sender, EventArgs e)
        {
            objcon = new DatabaseConn();
            objcon.ConnectDB();
            strSQL = "SELECT * FROM employee";
            daDep = new SqlDataAdapter(strSQL, objcon.Conn);
            ds = new DataSet();
            daDep.Fill(ds, "Employee");
            dataGridView1.DataSource = ds.Tables["Employee"].DefaultView;
            

        }
    }
}
