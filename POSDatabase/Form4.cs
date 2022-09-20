using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDatabase
{
    public partial class Form4 : Form
    {
        DataTable Prod;
        public Form4(DataTable Pr)
        {
            Prod = Pr;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach(DataRow DR in Prod.Rows)
            {
                dataGridView1.Rows.Add(DR["Product"].ToString());
            }
        }
    }
}
