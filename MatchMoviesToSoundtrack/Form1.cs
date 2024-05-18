using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        int ct = 0, tries = 30;

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "Fcover","Ficon","Pcover","Picon","Dcover","Dicon","GTcover","GTicon",
            "HGcover","HGicon","LRcover","LRicon","SWcover","SWicon","Tcover","Ticon"
        };

        PictureBox firstClicked = new PictureBox();
        PictureBox secondClicked = new PictureBox();
        PictureBox pbnull = new PictureBox();

        private void restart ()
        {
            icons.Clear();
            icons = new List<string>()
            {
                "Fcover","Ficon","Pcover","Picon","Dcover","Dicon","GTcover","GTicon",
                "HGcover","HGicon","LRcover","LRicon","SWcover","SWicon","Tcover","Ticon"
            };

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                PictureBox iconLabel = control as PictureBox;
                iconLabel.Image = null;
            }
            firstClicked.Image = null;
            secondClicked.Image = null;
            pbnull.Image = null;
            AssignIconsToSquares();
            tries = 30;
            labelTries.Text = "You have 30 tries";
            ct = 0;
        }

        private void buttonTryAgain_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void label_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            if (timer1.Enabled == true)
                return;

            if (pb != null)
            {
                if (pb.Image!=null)
                    return;

                if (firstClicked.Image == null)
                {
                    firstClicked = pb;
                    FindPictures(pb.Name, firstClicked);
                    firstClicked.Name = pb.Name;
                    return;
                }

                secondClicked = pb;
                secondClicked.Name = pb.Name;
                FindPictures(pb.Name, secondClicked);

                tries--; CheckTries();

                string n1, n2;
                n1 = firstClicked.Name;
                n2 = secondClicked.Name;

                if (n1[0]==n2[0])
                {
                    ct++;
                    firstClicked = pbnull;
                    secondClicked = pbnull;
                    if (ct == 8)
                        MessageBox.Show("You matched all the icons!", "Congratulations");
                    return;
                }

                timer1.Start();
            }

            //if (pb.Image == null)
            //FindPictures(pb.Name, pb);

            /*Label clickedLabel = sender as Label;

            if (timer1.Enabled == true)
                return;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                tries--; CheckTries();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    ct++;

                    if (ct == 10)
                        MessageBox.Show("You matched all the icons!", "Congratulations");
                    return;
                }

                timer1.Start();
            }*/

        }

        private void FindPictures(string s, PictureBox iconLabel)
        {
            switch (s)
            {
                case "Fcover": iconLabel.Image = MatchingGame.Properties.Resources.Fcover; break;
                case "Ficon": iconLabel.Image = MatchingGame.Properties.Resources.Ficon; break;
                case "Pcover": iconLabel.Image = MatchingGame.Properties.Resources.Pcover; break;
                case "Picon": iconLabel.Image = MatchingGame.Properties.Resources.Picon; break;
                case "Dcover": iconLabel.Image = MatchingGame.Properties.Resources.Dcover; break;
                case "Dicon": iconLabel.Image = MatchingGame.Properties.Resources.Dicon; break;
                case "GTcover": iconLabel.Image = MatchingGame.Properties.Resources.GTcover; break;
                case "GTicon": iconLabel.Image = MatchingGame.Properties.Resources.GTicon; break;
                case "HGcover": iconLabel.Image = MatchingGame.Properties.Resources.HGcover; break;
                case "HGicon": iconLabel.Image = MatchingGame.Properties.Resources.HGicon; break;
                case "LRcover": iconLabel.Image = MatchingGame.Properties.Resources.LRcover; break;
                case "LRicon": iconLabel.Image = MatchingGame.Properties.Resources.LRicon; break;
                case "SWcover": iconLabel.Image = MatchingGame.Properties.Resources.SWcover; break;
                case "SWicon": iconLabel.Image = MatchingGame.Properties.Resources.SWicon; break;
                case "Tcover": iconLabel.Image = MatchingGame.Properties.Resources.Tcover; break;
                case "Ticon": iconLabel.Image = MatchingGame.Properties.Resources.Ticon; break;
            }
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                PictureBox iconLabel = control as PictureBox;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Name = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            firstClicked.Image = null;
            secondClicked.Image = null;
            pbnull.Image = null;
            AssignIconsToSquares();

        }

        private void CheckTries()
        {
            if (tries > 1)
                labelTries.Text = "You have " + tries + " tries left";
            else
                if (tries == 1)
                labelTries.Text = "You have one try left";
            else
            {
                labelTries.Text = "You have no more tries";
                MessageBox.Show("You failed to solve the puzzle.", "Try again");
                restart();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.Image = null;
            secondClicked.Image = null;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
