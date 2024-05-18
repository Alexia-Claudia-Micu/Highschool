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
    public partial class Question1 : Form
    {
        int time = 10;

        public Question1()
        {
            InitializeComponent();
        }

        private void Check_Score()
        {
            if (radioButton2.Checked == true)
            {
                Results.scor += 5;
                Results.raspunsuri[0] = true;
            }
            if (radioButton4.Checked == true)
            {
                Results.scor += 5;
                Results.raspunsuri[1] = true;
            }
            Question2 f = new Question2();
            f.Show();
            this.Hide();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Check_Score();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            labelTime.Text = time.ToString();
            if (time == 0)
            {
                timer1.Enabled = false;
                Check_Score();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
