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
    public partial class Results : Form
    {
        public static bool[] raspunsuri = new bool[50];
        public static int scor = 0;
        Label[,] mat = new Label[50, 2];

        private void MatriceLabel()
        {
            int i, j;
            for (i = 0; i < 14; i++)
                for (j = 0; j < 2; j++)
                {
                    mat[i, j] = new Label();
                    mat[i, j].Font = new Font("Poor Richard", 14, FontStyle.Regular);
                    mat[i, j].Height = 30;
                    mat[i, j].Top = 10 + (i + 1) * 30;
                    mat[i, j].BackColor = Color.White;
                    mat[i, j].BorderStyle = BorderStyle.None;
                    mat[i, j].TextAlign = ContentAlignment.MiddleLeft;
                    if (j == 0)
                    {
                        mat[i, j].Width = 110;
                        mat[i, j].Left =20;
                        mat[i, j].Text = "Intrebarea " + (i + 1).ToString();
                    }
                    else
                    {
                        mat[i, j].Width = 70;
                        mat[i, j].Left = 130;
                        if (raspunsuri[i] == true)
                            mat[i, j].Text = "Corecta";
                        else
                            mat[i, j].Text = "Gresita";
                    }
                    this.Controls.Add(mat[i, j]);
                }
                for (i = 0; i < 13; i++)
                    for (j = 0; j < 2; j++)
                    {
                        mat[i+14, j] = new Label();
                        mat[i+14, j].Font = new Font("Poor Richard", 14, FontStyle.Regular);
                        mat[i+14, j].Height = 30;
                        mat[i+14, j].Top = 10 + (i + 1) * 30;
                        mat[i+14, j].BackColor = Color.White;
                        mat[i+14, j].BorderStyle = BorderStyle.None;
                        mat[i+14, j].TextAlign = ContentAlignment.MiddleLeft;
                        if (j == 0)
                        {
                             mat[i + 14, j].Width = 110;
                             mat[i+14, j].Text = "Intrebarea " + (i+14 + 1).ToString();
                             mat[i + 14, j].Left =210;
                        }
                        else
                        {
                            mat[i+14, j].Width = 70;
                            mat[i + 14, j].Left =320;
                            if (raspunsuri[i+14] == true)
                                mat[i+14, j].Text = "Corecta";
                            else
                                mat[i+14, j].Text = "Gresita";
                        }
                        this.Controls.Add(mat[i+14, j]);
                    }
        }

        public Results()
        {
            InitializeComponent();
            labelScore.Text += " " + scor.ToString() + "% ";
            MatriceLabel();
            if (scor < 30)
                labelFinal.Text = "Nu iti place arta clasica.";
            else
                if (scor < 50)
                labelFinal.Text = "Ai o cunostinta generala despre artele clasice.";
            else
                if (scor < 80)
                labelFinal.Text = "Bravo, cunosti artele clasice!";
            else
                if (scor <= 99)
                    labelFinal.Text = "Bravo, cunosti artele clasice foarte bine!";
            else
                labelFinal.Text = "Felicitari, esti un cunoscator adevarat al artelor!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
