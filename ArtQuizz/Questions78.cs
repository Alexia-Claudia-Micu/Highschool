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
    public partial class Questions78 : Form
    {
        StreamReader f = new StreamReader("78.txt");

        Image[] imagini = new Image[9];
        string descriere;
        int k = 0, raspuns, q, time = 20;

        private void AssignImages ()
        {
            imagini[0] = Properties.Resources.history1;
            imagini[1] = Properties.Resources.history2;
            imagini[2] = Properties.Resources.history3;
            imagini[3] = Properties.Resources.history4;
            imagini[4] = Properties.Resources.Rembrandt9;
            imagini[5] = Properties.Resources.Rembrandt7;
            imagini[6] = Properties.Resources.Rembrandt8;
            imagini[7] = Properties.Resources.Rembrandt;
        }

        private void ShowImages ()
        {
            pictureBox1.Image = imagini[k++];
            pictureBox2.Image = imagini[k++];
            pictureBox3.Image = imagini[k++];
            pictureBox4.Image = imagini[k++];
        }

        private void ReadAnswer ()
        {
            descriere = f.ReadLine();
            raspuns = int.Parse(f.ReadLine());
            richTextBox1.Text = descriere;
        }

        private void check_answer()
        {
            switch(raspuns)
            {
                case 1: if(radioButton1.Checked==true)
                    {
                        Results.raspunsuri[23 + q] = true;
                        Results.scor += 10;
                    }
                    break;
                case 2: if(radioButton2.Checked==true)
                    {
                        Results.raspunsuri[23 + q] = true;
                        Results.scor += 10;
                    }
                    break;
                case 3: if(radioButton3.Checked==true)
                    {
                        Results.raspunsuri[23 + q] = true;
                        Results.scor += 10;
                    }
                    break;
                case 4: if(radioButton4.Checked==true)
                    {
                        Results.raspunsuri[23 + q] = true;
                        Results.scor += 10;
                    }
                    break;
            }
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

        private void MoveOn ()
        {
            check_answer();
            if (q==0)
            {
                ReadAnswer();
                timer1.Enabled = true;
                time = 20;
                labelTime.Text = 20.ToString();
                ShowImages();
                q++;
            }
            else
            {
                timer1.Enabled = false;
                Ouestion910 f = new Ouestion910();
                f.Show();
                this.Hide();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            MoveOn();
        }

        public Questions78()
        {
            InitializeComponent();
            AssignImages();
            ShowImages();
            ReadAnswer();
        }
    }
}
