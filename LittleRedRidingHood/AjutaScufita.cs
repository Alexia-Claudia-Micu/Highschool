using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace scufita
{
    public partial class AjutaScufita : Form
    {
        int n, m, nrf, solf = 0, xw, yw, nrpas = 0, sem,v,nrinercari=5,nrHelp=3;
        string raspuns = "";
        string Solfis;

        int[,] a = new int[20, 20];
        int[,] sol = new int[20, 20];
        int[,] ajut = new int[20, 20];
        int[] di = new int[9];

        int[] dj = new int[9];

        Button[,] matb = new Button[20, 20];

        private void buttonFinal_Click(object sender, EventArgs e) // varianta cu butoane
        {
            buttonVerifica.Visible = true;
            v = 1;
        }

        private void buttonParcurs_Click(object sender, EventArgs e) // varianta cu butoane
        {
            CitireSol();
            v = 2;
        }

        private void radioButtonParcurs_CheckedChanged(object sender, EventArgs e)
        {
            CitireSol();
            v = 2;
            buttonRenunta.Visible = true;
        }

        private void radioButtonFinal_CheckedChanged(object sender, EventArgs e)
        {
            buttonRenunta.Visible = false;
            buttonVerifica.Visible = true;
            v = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // daca este imposibil de ajutat scufita
            label2.Visible = true;
            label2.Text = "Nu ai reusit sa ajuti scufita.";
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            if (Solfis == raspuns) // daca a parcurs drumul corect
            {
                matb[xw, yw].Image = scufita.Properties.Resources.wolf3__3_;
                matb[xw, yw].BackColor = Color.White;
                label2.Text = "Acesta este cel mai bun drum.";
            }
            else // daca a ajuns la bunica dar ineficient
            {
                if(solf<nrf) // cu varinata 1, se permite pasirea de mai multe ori prin acelasi loc
                {
                    matb[xw, yw].Image = scufita.Properties.Resources.wolf3__3_;
                    matb[xw, yw].BackColor = Color.White;
                    label2.Text = "Scufita a cules mai multe flori cu ajutorul tau.";
                    return;
                }
                if (ajut[n - 1, m - 1] != 0)
                {
                    matb[xw, yw].Image = scufita.Properties.Resources.wolf3__3_;
                    matb[xw, yw].BackColor = Color.White;
                    label2.Text = "Scufita a pierdut timp.";
                }
                else // daca nu ajunge la bunica
                    label2.Text = "Nu ai reusit sa ajuti scufita.";
            }
        }

        private void buttonAjutor_Click(object sender, EventArgs e)
        {
            buttonAjutor.Visible = false; // se reascund
            pictureBoxLightBulb.Visible = false;
            LookForValue1(0, 0); // se reincepe parcursul drumului pt a se gasi urmatoarea pozitie
            // se poate face mai eficient cu doua variabile in plus care retin potitia precedenta
            timer1.Stop(); // prima varianta de reset
            nrHelp--; // daca este acceptat ajutorul
        }

        int xc, yc, r; // se retin coordonate, inlocuire parametru clickCycle

        private void ClickCycle ( object sender, EventArgs e ) // nu merge
        {
            // conectat la problema de la valueFound
            if (r%2==1)
                matb[xc, yc].Image = null;
            else
                matb[xc, yc].Image = scufita.Properties.Resources.cursor2;
        }

        private void ValueFound ( int x, int y)
        {
            xc = x;yc = y;r = 1;
            matb[x, y].Image = scufita.Properties.Resources.cursor2;
            /*timer2.Enabled = true; // incercare de a face cursorul sa apara intrererupt
            timer2.Start();r++;
            timer2.Tick += ClickCycle;
            timer2.Start();r++;
            timer2.Tick += ClickCycle;
            timer2.Start();r++;
            timer2.Tick += ClickCycle;*/
        }

        private void LookForValue1( int i, int j )
        {
            int t, inew, jnew;
            for (t = 0; t < 4; t++)
            {
                inew = i + di[t];
                jnew = j + dj[t];
                if (okeSearch(inew, jnew)) 
                    if (sol[i,j] + 1 == sol[inew,jnew])
                    {
                        if (sol[inew,jnew] != nrpas+1)
                            LookForValue1(inew, jnew);
                        else
                            ValueFound(inew,jnew);
                    }
            }
        }

        private bool okeSearch ( int x, int y )
        {
            if (x < 0 || y < 0 || x >= n || y >= m)
                return false;
            //if (matb[x, y].Text == "")
                //return false;
            return true;
        }

        private void CheckAroundGeneralizat ( int i, int j )
        {
            if (i == 0 && j == 0)
                return;
            int t, inew, jnew;
            for (t = 0; t < 4; t++)
            {
                inew = i + di[t];
                jnew = j + dj[t];
                if (okeSearch(inew, jnew))
                    if (sol[i, j] - 1 == sol[inew, jnew])
                    {
                        if (a[i, j] < 0)
                        {
                            nrpas--;
                            matb[i, j].Text = "";
                            if (a[i, j] == -3 || a[i, j] == -1)
                                MessageBox.Show("Scufita nu e in siguranta acolo.");
                            else
                                MessageBox.Show("Scufita nu poate ajunge acolo.");
                            break;
                        }
                        else
                        {
                            if (matb[inew, jnew].Image != scufita.Properties.Resources.flower)
                                switch (t)
                                {
                                    case 0:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkDown;
                                        break;
                                    case 1:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkLeft;
                                        break;
                                    case 2:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkUp;
                                        break;
                                    case 3:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkRight;
                                        break;
                                }
                            if (a[inew, jnew] == 1)
                            {
                                nrf++;
                                matb[inew, jnew].Image = scufita.Properties.Resources.flower;
                                break;
                            }
                            break;
                        }
                    }
            }
        }

        private void checkAround ( int i, int j )
        {
            ajut[i, j] = ++nrpas; 
            if (nrpas == 1)
                return;

            int t, inew, jnew;
            for (t = 0; t < 4; t++)
            {
                inew = i + di[t];
                jnew = j + dj[t];
                if (okeSearch(inew, jnew))
                    if (ajut[i,j] - 1 == ajut[inew,jnew])
                    {
                        sem = 1;
                        if (a[i, j] < 0)
                        {
                            nrpas--;
                            matb[i, j].Text = "";
                            if (a[i, j] == -3 || a[i, j] == -1)
                                MessageBox.Show("Scufita nu e in siguranta acolo.");
                            else
                                MessageBox.Show("Scufita nu poate ajunge acolo.");
                            break;
                        }
                        else
                        {
                            if(matb[inew,jnew].Image!= scufita.Properties.Resources.flower)
                                switch (t)
                                {
                                    case 0:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkDown;
                                        break;
                                    case 1:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkLeft;
                                        break;
                                    case 2:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkUp;
                                        break;
                                    case 3:
                                        matb[inew, jnew].Image = scufita.Properties.Resources.walkRight;
                                        break;
                                }
                            if (a[i, j] == 1) // daca e floare
                            {
                                nrf++;
                                a[i, j] = 0;
                                matb[i, j].Image = scufita.Properties.Resources.flower;
                                break;
                            }
                            break;
                        }
                    }
            }
            if (i == n - 1 && j == m - 1 && sem==1)
            {
                matb[i, j].Image = scufita.Properties.Resources.gh1__3_;
                label1.Visible = true;
                raspuns = "Scufita a ajuns in siguranta la bunica in " + nrpas + " pasi, cu " + nrf + " flori.";
                label1.Text = raspuns;
                timer1.Stop();
                //scufita ajunge la bunica
            }
        }

        private void TimeOut (object sender, EventArgs e) // c# corner + microsoft docs
        {
            // cerere de ajutor
            if (nrHelp == 0)
                return;
            //MessageBox.Show("Poti cere ajutor.(" + nrHelp + ")");
            buttonAjutor.Text = nrHelp+"/3";
            buttonAjutor.Visible = true;
            pictureBoxLightBulb.Visible = true;
        }

        public void MatrixButtonClick (object sender, EventArgs e) // stack overflow
        {
            //ajut[][]= ++nrpas;
            Button b = sender as Button; 
            //b.Text = (++nrpas).ToString();

            buttonAjutor.Visible = false; // a fost oferit ajutor, daca nu folosit, se reascunde butonul
            pictureBoxLightBulb.Visible = false;

            string s = null; // preluare coordonate din numele butonului
            string[] coord = null;
            s = b.Name;
            int i, j; 
            coord = s.Split('_');
            i = int.Parse(coord[1]);
            j = int.Parse(coord[2]);

            if (v == 1) // daca se verifica la final
            {
                sem = 0; // verifica daca s-a gasit solutie, deci daca este legat de restul drumului
                int x;
                x = ajut[i, j];
                checkAround(i, j); // cauta elementul precedent
                if (sem == 0 && (i != 0 || j != 0)) // daca pasul este detasat se anunta si intoarce un pas
                {
                    MessageBox.Show("Scufita nu poate sa ajunga acolo.");
                    ajut[i, j] = x;
                    nrpas--;
                }
            }
            else
            if (v == 2) // corectare pe parcurs
            {
                // timp de 5 secunde de la apasarea unui buton, altfel se presupune nevoie de ajutor
                // proces de resetare a timer-ului
                timer1.Stop(); // se opreste timer-ul inceput
                timer1.Start(); // se incepe un timer nou
                timer1.Tick += TimeOut; // custom EventHandler pentru cand timer-ul se opreste
                if (sol[i, j] != nrpas + 1)
                {
                    if (nrinercari > 2)
                        MessageBox.Show("Directie gresita. Mai ai " + (--nrinercari) + " incercari."); // plural
                    else
                        if (nrinercari == 2)
                            MessageBox.Show("Directie gresita. Mai ai " + (--nrinercari) + " incercare."); // singular
                    else // daca ramane fara timp
                    {
                        label1.Visible = true;
                        label1.Text = "Nu ai reusit sa o ajuti pe scufita.";
                        MessageBox.Show("Ai ramas fara incercari.");
                        timer1.Stop(); // prima incercare de resetare
                    }
                }
                else
                {
                    nrpas++;
                    if (i == n - 1 && j == m - 1)
                    {
                        label1.Visible = true;
                        label1.Text = Solfis;
                        label2.Visible = true;
                        label2.Text = "Acesta este cel mai bun drum."; // daca se ajunge la final, nu mai trebuie verificare
                        matb[xw, yw].BackColor = Color.White;
                        matb[xw, yw].Image = scufita.Properties.Resources.wolf3__3_;
                        matb[i, j].Image = scufita.Properties.Resources.gh1__3_;
                        timer1.Stop(); // prima incercare de resetare
                    }
                    CheckAroundGeneralizat(i, j); // daca nu e la final, se cauta daca este pas bun si se completeaza cu imagine
                }
            }
            else // daca nu a fost selectata metoda ( varianta cu butoane )
            {
                MessageBox.Show("Alege o metoda.");
                timer1.Stop();
            }

            //LookForValue1(0,0);
        }

        private void CitireSol()
        {
            StreamReader f = new StreamReader("RaspunsSol.txt");
            string[] s = null;
            string linie = null;
            int i, j;

            //se citeste cate o linie pana la intalnirea sfarsitului de fisier
            i = 0;
            while ((linie = f.ReadLine()) != null) // matricea solutie pentru varianta 2
            {
                s = linie.Split(' ');//desparte linia in stringuri-echivalentul lui strtok              
                for (j = 0; j < m; j++)
                    sol[i, j] = Convert.ToInt32(s[j]);
                i++;
            }

            f.Close();

        }

        private void citire () // se ia matricea din fisierul de transfer
        {
            StreamReader f = new StreamReader("Transfer.txt");
            string[] s = null;
            string linie = null;
            int i, j;

            n = int.Parse(f.ReadLine());
            m = int.Parse(f.ReadLine());
            xw = int.Parse(f.ReadLine())-1;
            yw = int.Parse(f.ReadLine())-1;     
            solf = int.Parse(f.ReadLine());   

            //se citeste cate o linie pana la intalnirea sfarsitului de fisier
            i = 0;
            while ((linie = f.ReadLine()) != null)
            {
                s = linie.Split(' ');//desparte linia in stringuri-echivalentul lui strtok              
                for (j = 0; j < m; j++)
                    a[i, j] = int.Parse(s[j]);
                i++;
            } 

            f.Close();

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

        private void AfisMatb() // creare si afisare matb
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    matb[i, j] = new Button();
                    matb[i, j].Width = 50;
                    matb[i, j].Height = 50;
                    matb[i, j].Top = 20 + i * 50;
                    matb[i, j].Left = 350 + j * 50;
                    matb[i, j].BackColor = Color.SeaGreen; // creare matb
                    matb[i, j].ForeColor = Color.SeaGreen; // varianta 1
                    matb[i, j].Font = new Font("Segoe UI", 1F, FontStyle.Regular, GraphicsUnit.Point); // varianta 1
                    // inainte de a prelua indicii unui buton din nume, s-a dat o valoareText fiecarui buton cu ajutorul careia s-a parcurs drumul
                    switch (a[i, j]) // modifica matb si matricea a
                    {
                        case -1:
                            matb[i, j].Image = scufita.Properties.Resources.footprint__3_; // caz pas de lup
                            break;
                        case -3:
                            matb[i, j].Image = scufita.Properties.Resources.wolf2__4_; // caz lup
                            break;
                        case 0:
                            break;
                        case 1:
                            matb[i, j].BackColor = Color.White;
                            matb[i, j].Image = scufita.Properties.Resources._1flori__3_; // caz floare
                            break;
                        case -2:
                            matb[i, j].Image = scufita.Properties.Resources._1pom__3_; // caz pom
                            break;
                    }
                    this.Controls.Add(matb[i, j]); // afisare matb
                    matb[i, j].Name = "matb_" + i + "_" + j;
                    matb[i, j].Click += MatrixButtonClick;
                }
            matb[0, 0].Image = scufita.Properties.Resources._1lrrh__4_; // imagine scufita
            matb[n - 1, m - 1].Image = scufita.Properties.Resources.house__2_; // imagine casa bunica
            matb[0, 0].BackColor = Color.White;
        }

        private void CitireSolTxt () // solfis
        {
            StreamReader f = new StreamReader("RaspunsDirect.txt");
            Solfis = f.ReadLine();
            f.Close();
        }

        private void startMain ()
        {
            citire();
            VectDir();
            AfisMatb();
            CitireSolTxt();
        }

        public AjutaScufita()
        {
            InitializeComponent();
            startMain();
        }
    }
}
