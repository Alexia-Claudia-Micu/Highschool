using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProiectIanuarie
{
    public partial class Ouestion910 : Form
    {

        StreamReader f = new StreamReader("910.txt");

        Image[] imagini = new Image[9];
        string intrebare;
        string[] ani = new string[10];
        string[] nume = new string[10];
        int k = 0, raspuns, q, time = 10;

        private void AssignImages()
        {
            imagini[0] = Properties.Resources._102;
            imagini[1] = Properties.Resources._103;
            imagini[2] = Properties.Resources._104;
            imagini[3] = Properties.Resources.aeroplane;
            imagini[4] = Properties.Resources.l2;
            imagini[5] = Properties.Resources.l4;
        }

        private void ReadAnswer()
        {
            intrebare = f.ReadLine();
            for (int i = 0; i < 4; i++)
                ani[i] = f.ReadLine();
            raspuns = int.Parse(f.ReadLine());
            label2.Text = intrebare;
            for (int i = 0; i < 3; i++)
                nume[i] = f.ReadLine();
        }

        private void check_answer()
        {
            switch (raspuns)
            {
                case 1:
                    if (radioButton1.Checked == true)
                    {
                        Results.raspunsuri[25 + q] = true;
                        Results.scor += 10;
                    }
                    break;
                case 2:
                    if (radioButton2.Checked == true)
                    {
                        Results.raspunsuri[25 + q] = true;
                        Results.scor += 10;
                    }
                    break;
                case 3:
                    if (radioButton3.Checked == true)
                    {
                        Results.raspunsuri[25 + q] = true;
                        Results.scor += 10;
                    }
                    break;
                case 4:
                    if (radioButton4.Checked == true)
                    {
                        Results.raspunsuri[25 + q] = true;
                        Results.scor += 10;
                    }
                    break;
            }
        }

        private void MoveOn()
        {
            check_answer();
            if (q == 0)
            {
                ReadAnswer();
                timer1.Enabled = true;
                time = 10;
                labelTime.Text = 10.ToString();
                ShowImages();
                q++;
            }
            else
            {
                timer1.Enabled = false;
                Results f = new Results();
                f.Show();
                this.Hide();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            MoveOn();
        }

        private void ShowImages()
        {
            pictureBox1.Image = imagini[k++];
            pictureBox2.Image = imagini[k++];
            pictureBox3.Image = imagini[k++];
            radioButton1.Text = ani[0 + q*4];
            radioButton2.Text = ani[1 + q*4];
            radioButton3.Text = ani[2 + q*4];
            radioButton4.Text = ani[3 + q*4];
            label3.Text = nume[0 + q * 3];
            label4.Text = nume[1 + q * 3];
            label5.Text = nume[2 + q * 3];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            labelTime.Text = time.ToString();
            if (time == 0)
            {
                timer1.Enabled = false;
                MoveOn();
            }
        }

        public Ouestion910()
        {
            InitializeComponent();
            AssignImages();
            ReadAnswer();
            ShowImages();
        }
    }
}
