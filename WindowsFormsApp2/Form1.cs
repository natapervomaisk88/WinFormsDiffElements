using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty) 
            { 
                webBrowser1.Navigate(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.DocumentText != string.Empty)
            {
                string myFile = @"./site.txt";
                using (StreamWriter sr = File.CreateText(myFile))
                {
                    sr.Write(webBrowser1.DocumentText);
                    Process.Start("notepad.exe", myFile);
                };
            }
            else
                MessageBox.Show("No content");
            
        }

        private void tabPage2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Coral;
            label1.Text = "X: " + e.X + " Y: " + e.Y;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "MyApp";
            notifyIcon1.BalloonTipText = "Приложение свёрнуто!";
            notifyIcon1.Text = "Имя программы";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState== FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
           
        }

     

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(idTextBox.Text!=string.Empty && nameTextBox.Text!=string.Empty && surnameTextBox.Text!=string.Empty)
            {
                ListViewItem item = new ListViewItem(idTextBox.Text);
                item.SubItems.Add(nameTextBox.Text);
                item.SubItems.Add(surnameTextBox.Text);
                listView1.Items.Add(item);
                idTextBox.Clear();
                nameTextBox.Clear();
                surnameTextBox.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count>0)
            {
                listView1.Items.Remove(listView1.Items[0]);
            }
        }
    }
}
