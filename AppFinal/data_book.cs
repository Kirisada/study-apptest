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
    public partial class data_book : Form
    {
        public data_book()
        {
            InitializeComponent();
        }
        DatabaseConn objcon;
        SqlDataAdapter daDep;
        DataSet ds = new DataSet();
        string strSQL;
        private void data_book_Load(object sender, EventArgs e)
        {
            objcon = new DatabaseConn();
            objcon.ConnectDB();
            strSQL = "SELECT * FROM book";
            daDep = new SqlDataAdapter(strSQL, objcon.Conn);
            ds = new DataSet();
            daDep.Fill(ds, "Book");
            dataGridView1.DataSource = ds.Tables["Book"].DefaultView;
        }
    }
}
