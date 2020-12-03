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
    public partial class man_employee : Form
    {
        public man_employee()
        {
            InitializeComponent();
        }
        DatabaseConn objcon;
        SqlDataAdapter daDep;
        SqlDataReader dr;
        SqlCommand sqlCom = new SqlCommand();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string strSQL;
        string method;
        
        

        private void man_employee_Load(object sender, EventArgs e)
        {
            
            objcon = new DatabaseConn();
            objcon.ConnectDB();
            strSQL = "SELECT * FROM employee";
            daDep = new SqlDataAdapter(strSQL, objcon.Conn);
            ds = new DataSet();
            daDep.Fill(ds, "Employee");
            dataGridView1.DataSource = ds.Tables["Employee"].DefaultView;
            sqlCom.CommandType = CommandType.Text;
            sqlCom.CommandText = strSQL;
            sqlCom.Connection = objcon.Conn;
            dr = sqlCom.ExecuteReader();

            if (dr.HasRows)
            {
                dt.Load(dr);
                txt_EmpID.Text = dt.Rows[0]["empID"].ToString();
                txt_Name.Text = dt.Rows[0]["empName"].ToString();
                txt_Password.Text = dt.Rows[0]["empPassword"].ToString();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txt_EmpID.Clear();
            txt_Name.Clear();
            txt_Password.Clear();
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            method = "Add";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (method == "Add")
            {
                
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("INSERT INTO employee VALUES('" + txt_EmpID.Text + "',");
                    sb.Append("'" + txt_Name.Text + "'," + "'" + txt_Password.Text + "')");
                    strSQL = sb.ToString();
                    SqlCommand comAdd = new SqlCommand();
                    comAdd.CommandType = CommandType.Text;
                    comAdd.CommandText = strSQL;
                    comAdd.Connection = objcon.Conn;
                    comAdd.ExecuteNonQuery();
                    method = "";
                    
                    MessageBox.Show("Add Successfully");
                    
                
                }
                catch (Exception err)
                {
                   MessageBox.Show(err.Message);
                }
                
            }
            else if (method == "Edit")
            {
                StringBuilder sb = new StringBuilder();

                try
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("UPDATE employee set  empName='" + txt_Name.Text + "',");
                    sb.Append("empPassword='" + txt_Password.Text + "'");
                    sb.Append("WHERE (empID='" + txt_EmpID.Text + "')");
                    strSQL = sb.ToString();

                    SqlCommand comEdit = new SqlCommand();
                    comEdit.CommandType = CommandType.Text;
                    comEdit.CommandText = strSQL;
                    comEdit.Connection = objcon.Conn;
                    comEdit.ExecuteNonQuery();
                    method = "";
                    
                    MessageBox.Show("Edit Successfully");
                    
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                
            }
            timer1.Start();
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            method = "Edit";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                strSQL = "DELETE from employee  where empID ='" + txt_EmpID.Text.Trim() + "'";

                SqlCommand comDelete = new SqlCommand();
                comDelete.CommandType = CommandType.Text;
                comDelete.CommandText = strSQL;
                comDelete.Connection = objcon.Conn;
                comDelete.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                timer1.Start();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            timer1.Start();
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txt_EmpID.Text = row.Cells[0].Value.ToString();
                txt_Name.Text = row.Cells[1].Value.ToString();
                txt_Password.Text = row.Cells[2].Value.ToString();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            objcon = new DatabaseConn();
            objcon.ConnectDB();
            strSQL = "SELECT * FROM employee";
            daDep = new SqlDataAdapter(strSQL, objcon.Conn);
            ds = new DataSet();
            daDep.Fill(ds, "Employee");
            dataGridView1.DataSource = ds.Tables["Employee"].DefaultView;
            timer1.Stop();
        }
    }

}
