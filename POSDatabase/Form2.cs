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
    public partial class Form2 : Form
    {
        MySqlConnector Connection = new MySqlConnector();
        string Scategory;
        public Form2(string category)
        {
            Scategory = category;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(Scategory == "Member")
            {
                newToolStripMenuItem.Visible = false;
            }
            else
            {
                newToolStripMenuItem.Visible = true;
            }
            string Command = "SELECT * FROM custmorsinformations;";
            DataTable SQ = Connection.Connector(Command);
            foreach (DataRow DR in SQ.Rows)
            {
                dataGridView1.Rows.Add(DR["IdCustmers"].ToString(), DR["Name"].ToString(), DR["Company"].ToString(), DR["CompanyAddress"].ToString(), DR["Email"].ToString());
            }
            // el foeach trgamitha el for ely ta7t
            //for(int i=0 ; i<SQ.Rows.Count; i++)
            //{
            //    dataGridView1.Rows.Add(SQ.Rows[i]["IdCustmers"].ToString(), SQ.Rows[i]["Name"].ToString(), SQ.Rows[i]["Company"].ToString(), SQ.Rows[i]["CompanyAddress"].ToString(), SQ.Rows[i]["Email"].ToString());
            //}
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm3 = new Form3(Scategory);
            fm3.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string command = "select * from custmorsinformations";
            Connection.Connector(command);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 fm1 = new Form1();
            fm1.Show();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string ID = Convert.ToString(selectedRow.Cells["Column1"].Value);
            string Command = " select * from custmorsinformations join custmordata on custmorsinformations.IdCustmers = custmordata.CustmorID where IdCustmers ="+ ID+";";
            DataTable Product = Connection.Connector(Command);
            Form4 fm4 = new Form4(Product);
            fm4.Show();
        }
    }
}
