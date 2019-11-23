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
using header;
using System.Data.SqlClient;

namespace Loginform
{
    public partial class Locking : Form
    {
        string Address,a;
        char[] nb = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
    //    public string pname = "";
        public string nname = "";
        string Nm;
        string Password;
        public Locking()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox1.PasswordChar = '*';
            this.FormClosing += Locking_FormClosing;
        }

        private void Locking_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main Ma = new Main();
            Ma.Show();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Nm = richTextBox1.Text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

           a= Address = richTextBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            richTextBox2.Text = folderBrowserDialog1.SelectedPath;
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

            cmd.StandardInput.WriteLine("ren " + Address + " " + nname + "");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            a = Address;
            Address = Address.TrimEnd(richTextBox1.Text.ToCharArray());
            Address = Address + nname;
         
            l1();
            
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

            cmd.StandardInput.WriteLine("attrib +h +s "+Address+"");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            
        }
        

        public void random_name()
        {
            //RANDOM NAME GENERATION START

               char[] no = { '0', '1', '2', '3', '4'};
               Random ri = new Random();
                int j = no[ri.Next(0, 4)];
               // char[] nb = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
                
            Random rand = new Random();

                for (int i = 0; i < j; i++)
                {
                    
                    nname += nb[rand.Next(0, 61)].ToString();
                   
                   
                }
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == null)//check the name
            {
                MessageBox.Show("Enter the name of folder");
            }
            
            if (textBox1.Text == textBox2.Text) //check the password
            {
                Password = textBox1.Text;
                random_name();
                /* for (int i = 0; i < 5; i++)
                {
                    random_name();
                    nname+=pname+"-";
                    MessageBox.Show(nname);
                }
                
                nname += pname + "}";*/

       //         MessageBox.Show(nname);
                //RANDOM NAME GENERATED
        
                
                //DATABASE
                SqlConnection sc = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\dell\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

                string rnm = richTextBox1.Text;
                string ps = textBox1.Text;
                try
                {
                    SqlCommand c = new SqlCommand("insert into Folderinfo values('" + nname + "','" + rnm + "','" + a + "','" + ps + "')", sc);
                    sc.Open();
                    c.ExecuteNonQuery();
                    sc.Close();
                    l();
                   
                }
                catch 
                {
                    MessageBox.Show("The name already exists in this location please change the name or the location of the folder");
                }
                    richTextBox1.Text = textBox1.Text = richTextBox2.Text = textBox2.Text = "";
               // SqlCommand cm = new SqlCommand("insert into Folderinfo(Rname,Nname,Address,Password) values("", con);
                //values in database = old name, new name, address of folder, password
                
                
            }
            else
            {
                MessageBox.Show("Password in both fields should be same");
            }
            
        }
    }
}
