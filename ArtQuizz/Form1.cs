using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectIanuarie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "proiect" && textBoxPassword.Text == "ianuarie")
            {
                StartPage f = new StartPage();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect.");
                textBoxPassword.Text = "";
                textBoxUser.Text = "";
            }
        }
    }
}
