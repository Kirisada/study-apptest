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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        DatabaseConn objcon;
        SqlDataAdapter daDep;
        SqlDataReader dr;
        SqlCommand sqlCom = new SqlCommand();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string sql;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("Pls Fill Form.", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "SELECT * FROM employee WHERE empID = '" + txtUser.Text.Trim() + "' AND empPassword = '" + txtPassword.Text.Trim() + "'";
            daDep = new SqlDataAdapter(sql, objcon.Conn);
            ds = new DataSet();
            daDep.Fill(ds, "Employee");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.CommandText = sql;
            sqlCom.Connection = objcon.Conn;
            dr = sqlCom.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
                txtUser.Text = dt.Rows[0]["empID"].ToString();
                txtPassword.Text = dt.Rows[0]["empPassword"].ToString();
                MessageBox.Show("Login Successfully.", "Login Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form main_menu = new main_menu();
                main_menu.ShowDialog();
                this.Show();
                txtUser.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Login Fail, Pls Recheck Username/Password.", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Text = "";
                txtPassword.Text = "";
            }
            dr.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
            objcon = new DatabaseConn();
            objcon.ConnectDB();
        }
    }
}
