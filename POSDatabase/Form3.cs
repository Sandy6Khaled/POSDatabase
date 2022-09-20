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
    public partial class Form3 : Form
    {
        string Scategory;
        MySqlConnector Connection = new MySqlConnector();
        
        public Form3(string Category)
        {
            Scategory = Category;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                if (textBox2.Text !="")
                {
                    if (textBox3.Text !="")
                    {
                        if (textBox4.Text != "")
                        {
                            Form2 fm2 = new Form2(Scategory);
                            string Command = "insert into custmorsinformations(Name , Company , CompanyAddress , Email) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "');";
                            Connection.Connector(Command);
                            this.Close();
                            fm2.Show();
                        }
                        else
                        {
                            MessageBox.Show("Fill All The Email Plz");
                            textBox4.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill All The Company Address Plz");
                        textBox3.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Fill All The Company Plz");
                    textBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show("Fill All The Name Plz");
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
