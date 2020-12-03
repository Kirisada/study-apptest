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
    }
}
