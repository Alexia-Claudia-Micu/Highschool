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

namespace scufita
{
    public partial class Scufita : Form
    {
        int n, m, nrf, solf = 0, nrsol = 0, pasiMin = 100,xw,yw;

        int[,] a = new int[20, 20];
        int[,] b = new int[20, 20];
        int[,] sol = new int[20, 20];
        int[] di = new int[9];
        int[] dj = new int[9];

        TextBox[,] mat = new TextBox[20, 20];
        Button[,] matb = new Button[20, 20];

        /*
         * n,m - coordonate
         * nrf - numarul de flori care se modifica pe parcursul bt
         * solf - optimizarea nrf
         * pasimin - al doilea criteriu pentru optimizare: lungimea drumului
         * xw, yw - coordonate lup
         * a - matricea cu valori pentru pomi, flori si lup
         * b - traseul bt
         * mat - maricea de textbox-uri din care se preiau pozitiile pentru pomi si flori
         * matb - matricea finala, cu imagini
        */

        public Scufita()
        {
            InitializeComponent();
        }

        /*
         *                             int inew, jnew;
                            for (int t = 0; t < 4; t++)
                            {
                                inew = i + di[t];
                                jnew = j + dj[t];
                                if(okePasi(inew,jnew))
                                    if(a[inew,jnew]==a[i,j]+1)
                                    {
                                        switch(t)
                                        {
                                            case 0: matb[i, j].Image = scufita.Properties.Resources.fpUp;
                                                break;
                                            case 1: matb[i, j].Image = scufita.Properties.Resources.fpright;
                                                break;
                                            case 2: matb[i, j].Image = scufita.Properties.Resources.fpdown;
                                                break;
                                            case 3: matb[i, j].Image = scufita.Properties.Resources.fpleft;
                                                break;
                                        }
                                        break;
                                    }
                            }
         */

        private void AfisareFisier()
        {
            //Scufita a ajuns in siguranta la bunica in " + nrpas + " pasi, cu " + nrf + " flori"
            StreamWriter f = new StreamWriter("RaspunsDirect.txt");
            f.WriteLine("Scufita a ajuns in siguranta la bunica in " + pasiMin + " pasi, cu " + solf + " flori.");
            f.Close();

            StreamWriter g = new StreamWriter("RaspunsSol.txt");
            for (int i = 1; i <= n; i++)
            {
                int j;
                for (j = 1; j <= m; j++)
                    g.Write(sol[i, j] + " ");
                g.WriteLine();
            }
            g.Close();
        }

        private void button1_Click_1(object sender, EventArgs e) // transfer mat a in proiectul ajutascufita
        {
            //StreamReader g = new StreamReader("Transfer.txt");
            //string prop = null;
            //while ((prop = f.ReadLine()) != null)
            //  Console.WriteLine(prop);

            StreamWriter g = new StreamWriter("Transfer.txt");
            g.WriteLine(n);
            g.WriteLine(m);
            g.WriteLine(xw);
            g.WriteLine(yw);
            g.WriteLine(solf);

            for (int i = 1; i <= n; i++)
            {
                int j;
                for ( j = 1; j <= m; j++)
                    g.Write(a[i,j]+" ");
                g.WriteLine();
            }

            g.Close();

            AjutaScufita f = new AjutaScufita();
            f.Show();

            if (nrsol != 0)
                AfisareFisier();
        }

        private bool okePasi ( int x, int y )
        {
            if (x > n || x < 1 || y > m || y < 1)
                return false;
            return true;
        }

        private void AfisareLabel ()
        {
            labelSolutii.Visible = true; // eticheta cu solutii
            if (nrsol != 0) // daca exista solutii
            {
                matb[xw, yw].Image = scufita.Properties.Resources.wolf3__3_; // lupul pleaca
                labelSolutii.Text = "Din " + nrsol + " solutii, cea mai optima are " + solf + " flori si " + pasiMin + " pasi.";
                matb[n, m].Image = scufita.Properties.Resources.gh1__3_; // scufita ajunge la bunica
            }
            else
                labelSolutii.Text = "Scufita nu ajunge la bunica.";
        }

        private void afisare()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    if (sol[i, j] != 0)
                    {
                        if (a[i, j] == 1)
                        {
                            matb[i, j].Image = scufita.Properties.Resources.flower; // florile culese
                            matb[i, j].BackColor = Color.White;
                        }
                        else
                        {
                            matb[i, j].BackColor = Color.White; // drumul scufitei

                            int t, inew, jnew;
                            for(t = 0 ; t < 4 ; t++)
                            {
                                inew = i + di[t];
                                jnew = j + dj[t];
                                if(okePasi(inew,jnew))
                                {
                                    if(sol[i,j]+1==sol[inew,jnew])
                                        switch(t)
                                        {
                                            case 0: matb[i, j].Image = scufita.Properties.Resources.walkUp;
                                                break;
                                            case 1: matb[i, j].Image = scufita.Properties.Resources.walkRight;
                                                break;
                                            case 2: matb[i, j].Image = scufita.Properties.Resources.walkDown;
                                                break;
                                            case 3: matb[i, j].Image = scufita.Properties.Resources.walkLeft;
                                                break;
                                        }
                                }
                            }
                        }
                    }
            AfisareLabel();
        }

        private void optim()
        {
            nrsol++; // solutie noua
            if (nrf < solf) // daca are nr de flori cel putin egal
                return;
            if (nrf == solf && pasiMin < b[n, m]) // daca e egal, al doile citeriu pt optim
                return;
            solf = nrf;
            pasiMin = b[n, m];

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    sol[i, j] = b[i, j];
        }

        private bool oke(int x, int y) // valid
        {
            if (x > n || x < 1 || y > m || y < 1)
                return false;
            if (a[x, y] < 0)
                return false;
            if (b[x, y] != 0)
                return false;
            return true;
        }

        private void BT(int i, int j)
        {
            int t, inew, jnew;
            for (t = 0; t < 4; t++)
            {
                inew = i + di[t];
                jnew = j + dj[t];
                if (oke(inew, jnew) == true)
                {
                    if (a[inew, jnew] == 1) // daca este floare, se aduna
                        nrf++;
                    b[inew, jnew] = b[i, j] + 1;

                    if (inew == n && jnew == m)
                        optim();
                    else
                        BT(inew, jnew);

                    b[inew, jnew] = 0;
                    if (a[inew, jnew] == 1) // se scade floarea adunata
                        nrf--;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            /*
             * afisare solutia calculata deja 
             * pentru a pune val in mat de transfer fara a fi nevoie sa declanseze Vezi drumul
             */
            afisare();
        }

        private bool okeLup(int x, int y) // se verifica daca lupul poate ajunge la pozitiile invecinate
        {
            if (x < 1 || y < 1 || x > n || y > m) // daca este in matrice
                return false;
            if (a[x, y] == -2) // daca nu se loveste de pomi
                return false;
            return true;
        }

        private void CoordLup(int x, int y) // se completeaza matb cu zona lupului
        {
            int i, inew, jnew;
            for (i = 0; i < 8; i++)
            {
                inew = x + di[i];
                jnew = y + dj[i];
                if (okeLup(inew, jnew))
                {
                    a[inew, jnew] = -1;
                    matb[inew, jnew].Image = scufita.Properties.Resources.footprint__3_;
                }
            }
            matb[xw, yw].BackColor = Color.White;
            matb[xw, yw].Image = scufita.Properties.Resources.wolf2__4_;
        }

        private void button1_Click(object sender, EventArgs e) // creare si afisare matb
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    this.Controls.Remove(mat[i, j]); // se sterge mat, se elibereaza spatiul pentru matb
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                {
                    matb[i, j] = new Button();
                    matb[i, j].Width = 50;
                    matb[i, j].Height = 50;
                    matb[i, j].Top = 60 + i * 50;
                    matb[i, j].Left = 200 + j * 50;
                    matb[i, j].BackColor = Color.SeaGreen; // creare matb
                    switch (mat[i, j].Text) // modifica matb si matricea a
                    {
                        case "":
                            break;
                        case "1":
                            a[i, j] = 1;
                            matb[i, j].BackColor = Color.White;
                            matb[i, j].Image = scufita.Properties.Resources._1flori__3_; // caz floare
                            break;
                        case "2":
                            a[i, j] = -2;
                            matb[i, j].Image = scufita.Properties.Resources._1pom__3_; // caz pom
                            break;
                    }
                    this.Controls.Add(matb[i, j]); // afisare matb
                }
            xw = int.Parse(xTextBox.Text);  // preluare coord lup
            yw = int.Parse(yTextBox.Text);
            a[xw, yw] = -3;
            CoordLup(xw, yw);  //plaseaza valorile din jurul lupului
            matb[1, 1].Image = scufita.Properties.Resources._1lrrh__4_; // imagine scufita
            matb[n, m].Image = scufita.Properties.Resources.house__2_; // imagine casa bunica
            matb[1, 1].BackColor = Color.White;

            b[1, 1] = 1;
            nrf = 0;
            BT(1, 1);

        }

        private void MatTextBox() // creare si afisare mat
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                {
                    mat[i, j] = new TextBox();
                    mat[i, j].Width = 30;
                    mat[i, j].Height = 50;
                    mat[i, j].Top = 100 + i * 30;
                    mat[i, j].Left = 250 + j * 30;
                    mat[i, j].BackColor = Color.DarkSeaGreen;
                    this.Controls.Add(mat[i, j]);
                }
        }

        private void GenerareButton_Click(object sender, EventArgs e) // declansare introducere valori in mat
        {
            VectDir(); // generare vectori de directie?
            if (nTextBox.Text == "" || mTextBox.Text == "" || xTextBox.Text == "" || yTextBox.Text == "")
            {
                MessageBox.Show("Dati toate valorile necesare");
                return;
            }
            n = int.Parse(nTextBox.Text);
            m = int.Parse(mTextBox.Text);
            MatTextBox();
        }

        private void VectDir() // formare vectori directie?
        {
            di[0] = -1;
            di[1] = 0;
            di[2] = 1;
            di[3] = 0;
            di[4] = -1;
            di[5] = 1;
            di[6] = 1;
            di[7] = -1;

            dj[0] = 0;
            dj[1] = 1;
            dj[2] = 0;
            dj[3] = -1;
            dj[4] = 1;
            dj[5] = 1;
            dj[6] = -1;
            dj[7] = -1;
        }

        private void ResetButton_Click(object sender, EventArgs e) // reset
        {
            nTextBox.Text = ""; // se golesc textbox-urile pentru coordonate
            mTextBox.Text = "";
            xTextBox.Text = "";
            yTextBox.Text = "";

            labelSolutii.Text = ""; // se ascunde si goleste eticheta cu solutii
            labelSolutii.Visible = false;

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++) // se ascunde matricea
                {
                    this.Controls.Remove(matb[i, j]);
                    a[i, j] = 0;
                    b[i, j] = 0;
                    sol[i, j] = 0;
                }

            nrf = 0; // se reseteaza valorile pentru optim
            solf = 0;
            nrsol = 0;
            pasiMin = 100;
            
        }

        private void button3_Click(object sender, EventArgs e) // exit
        {
            Application.Exit();
        }

    }
}
