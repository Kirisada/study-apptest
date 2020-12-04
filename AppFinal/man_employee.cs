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
        string preID;
        

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
            int rows = dt.Rows.Count - 1;
            preID = genID(dt.Rows[rows]["empID"].ToString());
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            
        }

        //ฟังก์ชัน Auto ID
        private string genID(string ID)  
        {
            char[] gen = ID.ToCharArray();
            char[] pregen = new char[4];
            string sID = "EMP0000";
            int i = 0;
            while (i < 4)
            {
                gen[i] = gen[i+3];
                i++;
            }
            pregen[0] = gen[0];
            pregen[1] = gen[1];
            pregen[2] = gen[2];
            pregen[3] = gen[3];
            string op = new string(pregen);
            int gID = int.Parse(op);
            gID += 1;
            string p = gID.ToString();
            if (gID >= 1000)
            {
                sID = "EMP" + p;
            }else if (gID >= 100)
            {
                sID = "EMP0" + p;
            }else if (gID >= 10)
            {
                sID = "EMP00" + p;
            }
            else
            {
                sID = "EMP000" + p;
            }
            return sID;
        }
        //ฟังก์ชันเปิดปิด Form
        private void Enabletxt(bool stat)
        {
            if (stat == true)
            {
                txt_Name.Enabled = true;
                txt_Password.Enabled = true;
            }
            else
            {
                txt_Name.Enabled = false;
                txt_Password.Enabled = false;
            }
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txt_Name.Clear();
            txt_Password.Clear();
            Enabletxt(true);
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            if (txt_EmpID.Text != preID)
            {
                txt_EmpID.Text = preID;
            }
            else
            {
                txt_EmpID.Text = genID(txt_EmpID.Text);
                preID = txt_EmpID.Text;
            }
            
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
                    preID = txt_EmpID.Text;
                
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
            Enabletxt(false);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Enabletxt(true);
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDel.Enabled = false;
            method = "Edit";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want delete data?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                preID = txt_EmpID.Text;
                try
                {
                    strSQL = "DELETE FROM employee  WHERE empID ='" + txt_EmpID.Text.Trim() + "'";

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
                txt_EmpID.Clear();
                txt_Name.Clear();
                txt_Password.Clear();
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
            }
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
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;

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
            txt_EmpID.Clear();
            txt_Name.Clear();
            txt_Password.Clear();
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = false;
        }
    }

}
