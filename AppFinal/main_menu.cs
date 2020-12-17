using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFinal
{
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnManEmp_Click(object sender, EventArgs e)
        {
            Form man_emp = new man_employee();
            man_emp.ShowDialog();
        }

        private void btnManCus_Click(object sender, EventArgs e)
        {
            Form man_customer = new data_employee();
            man_customer.ShowDialog();
        }

        private void btnManBook_Click(object sender, EventArgs e)
        {
            Form man_book = new man_book();
            man_book.ShowDialog();
        }

        private void btnBookData_Click(object sender, EventArgs e)
        {
            Form data_book = new data_book();
            data_book.ShowDialog();
        }
    }
}
