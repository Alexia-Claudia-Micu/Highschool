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
    public partial class Question5 : Form
    {
        int time = 15;

        public Question5()
        {
            InitializeComponent();
        }

        private void check_score()
        {

            if (textBox6.Text == "1")
            {
                Results.scor += 2;
                Results.raspunsuri[17] = true;
            }
            if (textBox8.Text == "1")
            {
                Results.scor += 2;
                Results.raspunsuri[18] = true;
            }
            if (textBox7.Text == "4")
            {
                Results.scor += 2;
                Results.raspunsuri[19] = true;
            }
            if (textBox9.Text == "3")
            {
                Results.scor += 2;
                Results.raspunsuri[20] = true;
            }
            if (textBox5.Text == "2")
            {
                Results.scor += 2;
                Results.raspunsuri[21] = true;
            }
            Question6 f = new Question6();
            f.Show();
            this.Hide();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            check_score();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
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
