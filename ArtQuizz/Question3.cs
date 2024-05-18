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
    public partial class Question3 : Form
    {

        int ct = 1,time=10;


        public Question3()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(ct==1)
            {
                Results.scor += 2;
                Results.raspunsuri[3] = true;
            }
            ct++;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ct == 2)
            {
                Results.scor += 2;
                Results.raspunsuri[4] = true;
            }
            ct++;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (ct == 3)
            {
                Results.scor += 2;
                Results.raspunsuri[5] = true;
            }
            ct++;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (ct == 4)
            {
                Results.scor += 2;
                Results.raspunsuri[6] = true;
            }
            ct++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ct == 5)
            {
                Results.scor += 2;
                Results.raspunsuri[7] = true;
            }
            ct++;
        }

        private void check_score()
        {
            Question4 f = new Question4();
            f.Show();
            this.Hide();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            check_score();
            timer1.Enabled = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            time--;
            labelTime.Text = time.ToString();
            if (time == 0)
            {
                timer1.Enabled = false;
                check_score();
            }
        }
    }
}
