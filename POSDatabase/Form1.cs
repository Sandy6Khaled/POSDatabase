using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        MySqlConnector Connection = new MySqlConnector();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Command = "SELECT * FROM users where UserName = '"+textBox1.Text+"' and Password = '"+textBox2.Text+"';";
            DataTable Cd = Connection.Connector(Command);
            if ( Cd.Rows.Count > 0)
            {
                if (textBox1.Text == Cd.Rows[0]["username"].ToString() && textBox2.Text == Cd.Rows[0]["Password"].ToString())
                {
                    Form2 Fm2 = new Form2(Cd.Rows[0]["Category"].ToString());
                    Fm2.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Wrong UserName Or Passward", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Text = null;
                textBox2.Text = null;
                textBox1.Focus();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
            {
                button2.Focus();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
            {
                button1.Focus();
            }
        }
    }
}
