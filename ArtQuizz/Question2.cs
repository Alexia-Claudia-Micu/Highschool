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
    public partial class Question2 : Form
    {
        int time = 10;

        public Question2()
        {
            InitializeComponent();
        }

        private void check_score()
        {
            if (radioButton3.Checked == true)
            {
                Results.scor += 10;
                Results.raspunsuri[2] = true;
            }
            Question3 f = new Question3();
            f.Show();
            this.Hide();
        }

        private void buttonFinnish_Click(object sender, EventArgs e)
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
