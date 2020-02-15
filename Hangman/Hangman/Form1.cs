using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Hangman.Properties;

namespace Hangman
{
    public partial class Hangman : Form
    {
        Random rnd = new Random(); //random object 
        int incorrect = 0; //number of incorrect tries
        int correct = 0; //number of correct inputs
        String word = ""; //word to be guessed 
        Boolean impossible = false;

        public Hangman()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Generate words, add choose random word
            var words = Properties.Resources.words.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var words = Properties.Resources.words.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            //setup game
            pictureBox1.Visible = true;
            button2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            listBox1.Visible = true;
            listBox2.Visible = true;
            textBox1.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            button5.Visible = false;

            word = words.ElementAt(rnd.Next(0, words.Length - 1));
            correct++;

            //add word length to label 
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    label1.Text = label1.Text.Insert(i, " ");
                }

                //add star to indicate letter 
                else
                {
                    label1.Text = label1.Text.Insert(i, "*");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check if is a letter that was not used 
            if (listBox1.Items.Contains(textBox1.Text))
            {
                //add to used column
                listBox2.Items.Add(textBox1.Text);
                listBox1.Items.Remove(textBox1.Text);
            }

            //If not print error message 
            else
            {
                MessageBox.Show("Invaid Input");
                incorrect--; //to not remove points for invalid input
            }

            //check if the letter is part of the selected word
            if (word.Contains(textBox1.Text) && textBox1.Text.Length <= 1)
            {
                //Show the letters on the label 
                for (int i = 0; i < word.Length; i++)
                {
                    //Show letters in word 
                    if (Char.ToUpper(word[i]) == Char.ToUpper(textBox1.Text.ToCharArray()[0]) && impossible == false)
                    {
                        correct++; //add points
                        label1.Text = label1.Text.Remove(i, 1);
                        label1.Text = label1.Text.Insert(i, textBox1.Text);

                        //Check if player has won 
                        if (correct == word.Length)
                        {
                            MessageBox.Show("You Won!");
                            Application.Restart();
                        }

                    }

                    else if (impossible == true)
                    {
                        correct++;
                
                        //Check if player has won 
                        if (correct == word.Length)
                        {
                            MessageBox.Show("You Won!");
                            Application.Restart();
                        }
                    }
                }
            }

            //if input is not in word 
            else
            {
                incorrect++;
            }
            

            //change image (not the best way to do it, but it works for small number of images)
            if(incorrect == 1)
            {
                pictureBox1.Image = Resources.Hangman_2;
            }

            else if(incorrect == 2)
            {
                pictureBox1.Image = Resources.Hangman_3;
            }

            else if (incorrect == 3)
            {
                pictureBox1.Image = Resources.Hangman_4;
            }

            else if (incorrect == 4)
            {
                pictureBox1.Image = Resources.Hangman_5;
            }

            else if (incorrect == 5)
            {
                pictureBox1.Image = Resources.Hangman_6;
            }

            else if (incorrect == 6)
            {
                pictureBox1.Image = Resources.Hangman_7;
                MessageBox.Show("You Lost!");
                Application.Restart();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //setup game
            pictureBox1.Visible = true;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            listBox1.Visible = true;
            listBox2.Visible = true;
            textBox1.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
        }

        //Two Player Game
        private void button4_Click(object sender, EventArgs e)
        {
            word = textBox1.Text;
            button4.Visible = false;
            button2.Visible = true;

            //add word length to label 
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    label1.Text = label1.Text.Insert(i, " ");
                }

                //add star to indicate letter 
                else
                {
                    label1.Text = label1.Text.Insert(i, "*");
                }
            }
        }

        //You can't see the word at all...good luck!
        private void button5_Click(object sender, EventArgs e)
        {
            var words = Properties.Resources.words.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            //setup game
            pictureBox1.Visible = true;
            button2.Visible = true;
            textBox1.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            word = words.ElementAt(rnd.Next(0, words.Length - 1));
            correct++;

            //add word length to label 
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    label1.Text = label1.Text.Insert(i, " ");
                }

                //add star to indicate letter 
                else
                {
                    label1.Text = label1.Text.Insert(i, "*");
                }
            }
        }
    }
 }
