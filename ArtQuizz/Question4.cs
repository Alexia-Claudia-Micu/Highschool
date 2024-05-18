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
    public partial class Question4 : Form
    {
        int time = 40;
        String c;

        PictureBox firstClicked;
        Image secondClicked;
        int[,] a = new int[10, 10];
        int[,] b = new int[10, 10];

        private void citire() // se ia matricea din fisierul de transfer
        {
            StreamReader f = new StreamReader("Puzzle.txt");
            string[] s = null;
            string linie = null;
            int i, j;

            //se citeste cate o linie pana la intalnirea sfarsitului de fisier
            i = 1;
            while (i<=3)
            {
                linie = f.ReadLine();
                s = linie.Split(' ');//desparte linia in stringuri-echivalentul lui strtok              
                for (j = 1; j <= 3; j++)
                    b[i, j] = int.Parse(s[j-1]);
                i++;
            }

            i = 1;
            while (i<=3)
            {
                linie = f.ReadLine();
                s = linie.Split(' ');//desparte linia in stringuri-echivalentul lui strtok              
                for (j = 1; j <= 3; j++)
                    a[i, j] = int.Parse(s[j-1]);
                i++;
            }

            f.Close();

        }

        private void CallToPicture ( int x )
        {
            int aux,u;
            switch(c)
            {
                case "pictureBox1": pictureBox1.Image = secondClicked;
                    if (x%3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[1, 1];
                    b[1, 1] = b[(x + 2) / 3, aux];
                    b[(x+2)/3, aux] = u;
                                    break;
                case "pictureBox2": pictureBox2.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[1, 2];
                    b[1, 2] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
                case "pictureBox3": pictureBox3.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[1, 3];
                    b[1, 3] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
                case "pictureBox4": pictureBox4.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[2, 1];
                    b[2, 1] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
                case "pictureBox5": pictureBox5.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[2, 2];
                    b[2, 2] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
                case "pictureBox6": pictureBox6.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[2, 3];
                    b[2, 3] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
                case "pictureBox7": pictureBox7.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[3, 1];
                    b[3, 1] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
                case "pictureBox8": pictureBox8.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[3, 2];
                    b[3, 2] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
                case "pictureBox9": pictureBox9.Image = secondClicked;
                    if (x % 3 == 0)
                        aux = 3;
                    else
                        aux = x % 3;
                    u = b[3, 3];
                    b[3, 3] = b[(x + 2) / 3, aux];
                    b[(x + 2) / 3, aux] = u;
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox1.Image;
                c = pictureBox1.Name;
            }
            else
            {
                secondClicked = pictureBox1.Image;
                pictureBox1.Image = firstClicked.Image;
                CallToPicture(1);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox2.Image;
                c = pictureBox2.Name;
            }
            else
            {
                secondClicked = pictureBox2.Image;
                pictureBox2.Image = firstClicked.Image;
                CallToPicture(2);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox3.Image;
                c = pictureBox3.Name;
            }
            else
            {
                secondClicked = pictureBox3.Image;
                pictureBox3.Image = firstClicked.Image;
                CallToPicture(3);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox4.Image;
                c = pictureBox4.Name;
            }
            else
            {
                secondClicked = pictureBox4.Image;
                pictureBox4.Image = firstClicked.Image;
                CallToPicture(4);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox5.Image;
                c = pictureBox5.Name;
            }
            else
            {
                secondClicked = pictureBox5.Image;
                pictureBox5.Image = firstClicked.Image;
                CallToPicture(5);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox6.Image;
                c = pictureBox6.Name;
            }
            else
            {
                secondClicked = pictureBox6.Image;
                pictureBox6.Image = firstClicked.Image;
                CallToPicture(6);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox7.Image;
                c = pictureBox7.Name;
            }
            else
            {
                secondClicked = pictureBox7.Image;
                pictureBox7.Image = firstClicked.Image;
                CallToPicture(7);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox8.Image;
                c = pictureBox8.Name;
            }
            else
            {
                secondClicked = pictureBox8.Image;
                pictureBox8.Image = firstClicked.Image;
                CallToPicture(8);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (firstClicked.Image == null)
            {
                firstClicked.Image = pictureBox9.Image;
                c = pictureBox9.Name;
            }
            else
            {
                secondClicked = pictureBox9.Image;
                pictureBox9.Image = firstClicked.Image;
                CallToPicture(9);
                secondClicked = null;
                firstClicked.Image = null;
            }    
        }

        public Question4()
        {
            InitializeComponent();
            firstClicked = pictureBox10;
            firstClicked.Image = null;
            secondClicked = null;
            citire();
        }

        private void check_score()
        {
            int x=0;
            Results.scor += 1;
            for (int i = 1; i <= 3; i++)
                for (int j = 1; j <= 3; j++)
                    if(a[i,j]==b[i,j])
                    {
                        Results.scor += 1;
                        Results.raspunsuri[7 + (i - 1) * 3 + j] = true;
                        x++;
                    }
            Question5 f = new Question5();
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
