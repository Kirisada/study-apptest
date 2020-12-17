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
    public partial class man_book : Form
    {
        public man_book()
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
        string preMin, preMax, preNow, preNext, preIndex = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (method == "Add")
            {

                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("INSERT INTO book VALUES('" + txt_BookID.Text + "',");
                    sb.Append("'" + txt_Name.Text + "'," + "'" + txt_Writer.Text + "')");
                    strSQL = sb.ToString();
                    SqlCommand comAdd = new SqlCommand();
                    comAdd.CommandType = CommandType.Text;
                    comAdd.CommandText = strSQL;
                    comAdd.Connection = objcon.Conn;
                    comAdd.ExecuteNonQuery();
                    method = "";
                    preNow = preNext;
                    if (preMax == preNow)
                    {

                    }
                    else if (preIndex != "")
                    {
                        preNow = preMax;
                        preIndex = "";
                    }
                    else
                    {
                        preMax = genID(preMax);
                    }

                    MessageBox.Show("Add Successfully");
                    txt_BookID.Clear();
                    txt_Name.Clear();
                    txt_Writer.Clear();

                }
                catch (Exception err)
                {
                    MessageBox.Show("Fail pls re-check data", err.Message);
                }

            }
            else if (method == "Edit")
            {

                StringBuilder sb = new StringBuilder();

                try
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("UPDATE book set  bookName='" + txt_Name.Text + "',");
                    sb.Append("bookWriter='" + txt_Writer.Text + "'");
                    sb.Append("WHERE (bookID='" + txt_BookID.Text + "')");
                    strSQL = sb.ToString();

                    SqlCommand comEdit = new SqlCommand();
                    comEdit.CommandType = CommandType.Text;
                    comEdit.CommandText = strSQL;
                    comEdit.Connection = objcon.Conn;
                    comEdit.ExecuteNonQuery();
                    method = "";

                    MessageBox.Show("Edit Successfully");
                    txt_BookID.Clear();
                    txt_Name.Clear();
                    txt_Writer.Clear();

                }
                catch (Exception err)
                {
                    MessageBox.Show("Fail pls re-check data", err.Message);

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
            btnDel.Enabled = true;
            method = "Edit";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want delete data?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                preIndex = txt_BookID.Text;
                try
                {
                    strSQL = "DELETE FROM book  WHERE bookID ='" + txt_BookID.Text.Trim() + "'";
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
                    MessageBox.Show("Fail pls re-check data", err.Message);

                }
                timer1.Start();
                txt_BookID.Clear();
                txt_Name.Clear();
                txt_Writer.Clear();
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txt_BookID.Text = row.Cells[0].Value.ToString();
                txt_Name.Text = row.Cells[1].Value.ToString();
                txt_Writer.Text = row.Cells[2].Value.ToString();

            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            objcon = new DatabaseConn();
            objcon.ConnectDB();
            strSQL = "SELECT * FROM book";
            daDep = new SqlDataAdapter(strSQL, objcon.Conn);
            ds = new DataSet();
            daDep.Fill(ds, "Book");
            dataGridView1.DataSource = ds.Tables["Book"].DefaultView;
            timer1.Stop();
            txt_BookID.Clear();
            txt_Name.Clear();
            txt_Writer.Clear();
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = false;
            preNext = genID(preNow);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txt_Name.Clear();
            txt_Writer.Clear();
            Enabletxt(true);
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            //MessageBox.Show("Next_" + preNext + "_Max_" + preMax + "_Now_" + preNow + "_Index_" + preIndex);
            if (preIndex != "")
            {
                txt_BookID.Text = preIndex;
            }
            else if (preNext == preMax)
            {
                txt_BookID.Text = genID(preNext);
            }
            else
            {
                txt_BookID.Text = preNext;
            }


            method = "Add";
        }

        private void man_book_Load(object sender, EventArgs e)
        {
            objcon = new DatabaseConn();
            objcon.ConnectDB();
            strSQL = "SELECT * FROM book";
            daDep = new SqlDataAdapter(strSQL, objcon.Conn);
            ds = new DataSet();
            daDep.Fill(ds, "Book");
            dataGridView1.DataSource = ds.Tables["Book"].DefaultView;
            sqlCom.CommandType = CommandType.Text;
            sqlCom.CommandText = strSQL;
            sqlCom.Connection = objcon.Conn;
            dr = sqlCom.ExecuteReader();

            if (dr.HasRows)
            {

                dt.Load(dr);
                txt_BookID.Text = dt.Rows[0]["bookID"].ToString();
                txt_Name.Text = dt.Rows[0]["bookName"].ToString();
                txt_Writer.Text = dt.Rows[0]["bookWriter"].ToString();

            }
            int rows = dt.Rows.Count - 1;
            preMax = dt.Rows[rows]["bookID"].ToString();
            preMin = "B000001";
            preNow = preMax;
            preNext = genID(preNow);
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
        }

        //ฟังก์ชัน Auto ID
        private string genID(string ID)
        {
            char[] gen = ID.ToCharArray();
            char[] pregen = new char[6];
            string sID = "B000000";
            int i = 0;
            while (i < 6)
            {
                gen[i] = gen[i + 1];
                i++;
            }
            pregen[0] = gen[0];
            pregen[1] = gen[1];
            pregen[2] = gen[2];
            pregen[3] = gen[3];
            pregen[4] = gen[4];
            pregen[5] = gen[5];
            string op = new string(pregen);
            int gID = int.Parse(op);
            gID += 1;
            string p = gID.ToString();
            if (gID > 999999)
            {
                MessageBox.Show("Not enough storage space.");
            }
            else if (gID >= 100000)
            {
                sID = "B" + p;
            }
            else if (gID >= 10000)
            {
                sID = "B0" + p;
            }
            else if (gID >= 1000)
            {
                sID = "B00" + p;
            }
            else if (gID >= 100)
            {
                sID = "B000" + p;
            }
            else if (gID >= 10)
            {
                sID = "B0000" + p;
            }
            else
            {
                sID = "B00000" + p;
            }
            return sID;
        }
        //ฟังก์ชันเปิดปิด Form
        private void Enabletxt(bool stat)
        {
            if (stat == true)
            {
                txt_Name.Enabled = true;
                txt_Writer.Enabled = true;
            }
            else
            {
                txt_Name.Enabled = false;
                txt_Writer.Enabled = false;
            }

        }
    }
}
