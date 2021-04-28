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
        static List<int> primes = new List<int>();
        IEnumerator<int> getPrimes;

        int primeToGuessIndex = 0;
        int remainingGuesses = 3;
        public static string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"\SaveFile.txt";
        string stringHighScore;

        /// <summary>
        /// Gets the prime numbers one by one as the user progresses
        /// </summary>
        public static IEnumerable<int> GeneratePrimes()
        {
            primes.Add(2);
            yield return 2; //Hardcoding the only even prime lets us only check the odd numbers in the below loop

            int nextPrime = 3;

            while (true)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; primes[i] <= sqrt; i++) //Atleast one factor must be less than the square root of the number, which means that we don't have to check further
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
                    yield return nextPrime;
                }
                nextPrime += 2;
            }
        }

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            highScoreLabel.Text = ("Highscore: " + ReadTxt());

            //Starts/Resets GeneratePrimes
            getPrimes = GeneratePrimes().GetEnumerator();
            getPrimes.MoveNext(); 

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

            primeToGuessIndex = 0;
            remainingGuesses = 3;
            guessNumericUpDown.Value = 0;

            listBox1.Items.Clear();
            primeNrLbl.Text = ("Prime nr: " + primeToGuessIndex);

            StartGame();
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            //If the answer is correct:
            //make the input box green, add the correct number to the listBox, get the next prime
            if (guessNumericUpDown.Value == getPrimes.Current)
            {
                guessNumericUpDown.BackColor = Color.Green;
                listBox1.Items.Insert(0, getPrimes.Current);

                getPrimes.MoveNext();
                primeToGuessIndex++;

                primeNrLbl.Text = ("Prime nr: " + primeToGuessIndex);
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
                    SaveHighScore(primeToGuessIndex);

                    var startOver = MessageBox.Show("You failed three times. Do you want to try again?", "Defeat", MessageBoxButtons.YesNo);
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
        /// All the extra lines are unnessisary but they are so cheap and makes it more foolproof if you for example want to intoduce the abillity to increase health
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
                remainingGuessesBar1.Value = 100;
                remainingGuessesBar2.Value = 100;
                remainingGuessesBar3.Value = 0;
            }
            else if (remainingGuesses == 1)
            {
                remainingGuessesBar1.Value = 100;
                remainingGuessesBar2.Value = 0;
                remainingGuessesBar3.Value = 0;
            }
            else
            {
                remainingGuessesBar1.Value = 0;
                remainingGuessesBar2.Value = 0;
                remainingGuessesBar3.Value = 0;
            }
        }

        private void SaveHighScore(int currentScore)
        {
            try
            {
                stringHighScore = ReadTxt();
            }
            catch (Exception)
            {
                throw;
            }

            //If it can parse the number it compares to the highscore, otherwise it writes the current score
            //This also means that if the file is empty or doesn't exist it will still write to it/create a new one
            if (Int32.TryParse(stringHighScore, out int highScore))
            {
                if (highScore < currentScore)
                {
                    WriteTxt(currentScore);
                }
                return;
            }
            WriteTxt(currentScore);
        }

        static void WriteTxt(int scoreToSave)
        {
            using (StreamWriter sw = new StreamWriter(dirParameter))
            {
                sw.WriteLine(scoreToSave);
            }
        }

        static string ReadTxt()
        {
            if (File.Exists(dirParameter))
            {
                using (StreamReader sr = new StreamReader(dirParameter))
                {
                    string stringHighScore = sr.ReadLine();
                    return stringHighScore;
                }
            }
            return "0"; //If we can't find a file we assume the highscore of 0
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In this game you can test you knowledge of the prime numbers." +
                "\nYou write your guess into the box on the right and either hit the 'Enter' button on the form or the one on your keyboard." +
                "\nYou have three lives and when they run out, the game is over." +
                "\nGood Luck!", "Help");
        }

        private void primeWikiLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            primeWikiLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Prime_number");
        }
    }
}
