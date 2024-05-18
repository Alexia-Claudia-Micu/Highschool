using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace ProiectIanuarie
{
    public partial class Question6 : Form
    {
        WindowsMediaPlayer music = new WindowsMediaPlayer();

        int i = 0;

        public Question6()
        {
            InitializeComponent();
            music.URL = "Chopin.mp3";
            music.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked==true)
            {
                Results.scor += 10-i;
                Results.raspunsuri[22] = true;
            }
            music.controls.stop();
            Questions78 f = new Questions78();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = 5;
            radioButton2.Visible = false;
            radioButton4.Visible = false;
        }
    }
}
