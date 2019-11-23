using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Data.SqlClient;

namespace Loginform
{
    public partial class UnLocking : Form
    {
        public string Address,ad;
        public UnLocking()
        {
            InitializeComponent();
            this.FormClosing += UnLocking_FormClosing;
            
        }
        private void UnLocking_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main Ma = new Main();
            Ma.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            richTextBox2.Text = folderBrowserDialog2.SelectedPath;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Address = richTextBox2.Text + richTextBox1.Text;

            ad = Address;
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\dell\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string nname;
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from Folderinfo where Address='" + Address + "' and Password='" + textBox1.Text + "'", conn);
            DataTable d = new DataTable();
            sda.Fill(d);
            if (d.Rows[0][0].ToString() == "1")
            {
                using (var command = new SqlCommand("select NName from Folderinfo where Address='" + Address + "' and Password='" + textBox1.Text + "'", conn))
                {
                    conn.Open();
                    nname = (string)command.ExecuteScalar();
                    conn.Close();
                }
                string on = richTextBox1.Text;
                Address = Address.TrimEnd(richTextBox1.Text.ToCharArray());
                Address = Address + nname;
                string rname = richTextBox1.Text;
                l();
                SqlCommand s = new SqlCommand("Delete from Folderinfo where Address='" + ad + "'", conn);
                conn.Open();
                s.ExecuteNonQuery();
                conn.Close();
                richTextBox1.Text = textBox1.Text = richTextBox2.Text = "";
            }
            else
            {
                MessageBox.Show("wrong password, name combination please try again");
                richTextBox1.Text = textBox1.Text = richTextBox2.Text = "";
            }
        }

        public void l1()
        {

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("ren " + Address + " " + richTextBox1.Text + "");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

        }


        public void l()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("attrib -h -s " + Address + "");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            l1();
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UnLocking_Load(object sender, EventArgs e)
        {

        }
    }
}
