using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Loginform
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.FormClosing += Main_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Locking l = new Locking();
            l.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Files fi = new Files();
            fi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_User au = new Add_User();
            au.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Remove_User ru = new Remove_User();
            ru.Show();
          
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UnLocking ul = new UnLocking();
            ul.Show();
        }

       
    }
}
