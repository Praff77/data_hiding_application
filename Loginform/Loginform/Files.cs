using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;

namespace Loginform
{
    public partial class Files : Form
    {
        public Files()
        {
            InitializeComponent();
            this.FormClosing += Files_FormClosing;
        }

        private void Files_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main Ma = new Main();
            Ma.Show();
        }

        private void Files_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fileBrowserDialog1 = new OpenFileDialog();
            if (fileBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileBrowserDialog1.FileName;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String path = textBox1.Text;
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            FileAttributes atbt = File.GetAttributes(path);
            File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.ReadOnly);
            MessageBox.Show("Permission is set to read only");

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            String path = textBox1.Text;
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            FileAttributes atbt = File.GetAttributes(path);

            //Removing read only attribute
            atbt = RemoveAttributes(atbt, FileAttributes.ReadOnly);
            File.SetAttributes(path, atbt);



            //Showing message box
            MessageBox.Show("Permission is set to Writable");
        }
        private static FileAttributes RemoveAttributes(FileAttributes atbt, FileAttributes attributesToRemove)
        {
            return atbt & ~attributesToRemove;
        }

        private void filenm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Permission_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                try
                {
                    string filePath = textBox1.Text;
                    string adminUserName = Environment.UserName;// getting your adminUserName
                    DirectorySecurity ds = Directory.GetAccessControl(filePath);
                    FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                    ds.AddAccessRule(fsa);
                    Directory.SetAccessControl(filePath, ds);
                    MessageBox.Show("permissions Denied");
                }

                catch
                {
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {

                try
                {

                    string folderPath = textBox1.Text;
                    string adminUserName = Environment.UserName;// getting your adminUserName
                    DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                    FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                    ds.RemoveAccessRule(fsa);
                    Directory.SetAccessControl(folderPath, ds);
                    MessageBox.Show("Permissions allowed");
                }
                catch
                {
                }
            }
        }
    }
}

