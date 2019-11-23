using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Loginform
{
    public partial class Add_User : Form
    {
        public Add_User()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            this.FormClosing += Add_User_FormClosing;
        }

        private void Add_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main Ma = new Main();
            Ma.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Username field cannot be empty");
            }
            if (textBox2.Text == null)
            {
                MessageBox.Show("Password field cannot be empty");
            }
            SqlConnection sc = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\dell\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlDataAdapter sd = new SqlDataAdapter("Select Count(*) from Autherization where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", sc);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")//or dt.rows[0][0].equals(1)  or dt.rows[0][0].tostring==1
            {
                MessageBox.Show("Username already taken try another");
                textBox1.Text = "";
            }
            else
            {
                
                SqlCommand c = new SqlCommand("insert into Login values('" + textBox1.Text + "','" + textBox2.Text + "')", sc);
                c.ExecuteNonQuery();
                
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("User Added successfully");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            

        }

       
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       

       
    }
}
