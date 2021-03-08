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

namespace LearnThePrimesWinForm
{
    public partial class Form1 : Form
    {
        List<int> primes = new List<int>(GeneratePrimesNaive(100));
        int primeToGuess = 0;
        int remainingGuesses = 3;
        public static string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"\SaveFile.txt";
        string stringHighScore;

        /// <summary>
        /// Generates the primes that are going to be 
        /// used to check if the answer was correct
        /// </summary>
        public static List<int> GeneratePrimesNaive(int n)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            highScoreLabel.Text = ("Highscore: " + ReadTxt());

            //Highlights the zero in the input box so the user doesn't have to
            guessNumericUpDown.Select(0, guessNumericUpDown.Value.ToString().Length);
            SetRemainingLives();
        }

        /// <summary>
        /// Resets the entire form to make it ready for another game
        /// (reset colors, enable buttons, reset variables, fix label and listBox content)
        /// and then calls StartGame to do the normal first time startup
        /// </summary>
        private void ResetGame()
        {
            BackColor = SystemColors.Control;
            guessNumericUpDown.BackColor = SystemColors.Control;
            enterBtn.Enabled = true;

            primeToGuess = 0;
            remainingGuesses = 3;
            guessNumericUpDown.Value = 0;

            listBox1.Items.Clear();
            primeNrLbl.Text = ("Prime nr: " + primeToGuess);

            StartGame();
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            //If the answer is correct:
            //make the input box green, add the correct number to the listBox, get the next prime
            if (guessNumericUpDown.Value == primes[primeToGuess])
            {
                guessNumericUpDown.BackColor = Color.Green;
                listBox1.Items.Insert(0, primes[primeToGuess]);
                primeToGuess++;

                primeNrLbl.Text = ("Prime nr: " + primeToGuess);
            }
            else
            {
                guessNumericUpDown.BackColor = Color.Red;
                remainingGuesses--;
                SetRemainingLives();
                if (remainingGuesses == 0)
                {
                    BackColor = Color.Red;
                    enterBtn.Enabled = false;
                    SaveHighScore(primeToGuess);
                    //MessageBox.Show("You failed three times. Better luck next time!");
                    var startOver = MessageBox.Show("You failed three times. Better luck next time!", "Defeat", MessageBoxButtons.YesNo);

                    if (startOver == DialogResult.Yes)
                    {
                        ResetGame();
                    }
                    else
                    {
                        Close();
                    }
                }
            }

            //Resets the focus and selects the previous answer so that the user doesn't have to click on the input box
            guessNumericUpDown.Focus();
            guessNumericUpDown.Select(0, guessNumericUpDown.Value.ToString().Length);
        }

        /// <summary>
        /// Changes the values for the progress bars that indicate the remaining guesses
        /// </summary>
        private void SetRemainingLives()
        {
            if (remainingGuesses == 3)
            {
                remainingGuessesBar1.Value = 100;
                remainingGuessesBar2.Value = 100;
                remainingGuessesBar3.Value = 100;
            }
            else if (remainingGuesses == 2)
            {
                remainingGuessesBar3.Value = 0;
            }
            else if (remainingGuesses == 1)
            {
                remainingGuessesBar2.Value = 0;
            }
            else
            {
                remainingGuessesBar1.Value = 0;
            }
        }

        private void SaveHighScore(int currentScore)
        {
            //FileStream fParameter = new FileStream(dirParameter, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //StreamReader m_ReaderParameter = new StreamReader(fParameter);
            //var saveFile = File.OpenRead(dirParameter);
            //saveFile.Read
            //string[] arrSaveFile = File.ReadAllLines(dirParameter);

            try
            {
                stringHighScore = ReadTxt();
            }
            catch (Exception)
            {
                throw;
            }

            if (Int32.TryParse(stringHighScore, out int highScore))
            {
                if (highScore < currentScore)
                {
                    WriteTxt(currentScore);
                }
            }
        }

        static void WriteTxt(int scoreToSave)
        {
            StreamWriter sw = new StreamWriter(dirParameter);
            sw.WriteLine(scoreToSave);
            sw.Close();
        }

        static string ReadTxt()
        {
            if (File.Exists(dirParameter))
            {
                StreamReader sr = new StreamReader(dirParameter);
                string stringHighScore = sr.ReadLine();
                sr.Close();
                return stringHighScore;
            }
            return null;
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In this game you can test you knowledge of the prime numbers." +
                "\nYou write your guess into the box on the right and either hit the 'Enter' button on the form or the one on your keyboard."+
                "\nYou have three lives and when they run out, the game is over.\nGood Luck!", "Help");
        }

        private void primeWikiLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            primeWikiLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Prime_number");
        }
    }
}
