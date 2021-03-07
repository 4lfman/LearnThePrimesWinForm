using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnThePrimesWinForm
{
    public partial class Form1 : Form
    {
        List<int> primes = new List<int>(GeneratePrimesNaive(100));
        int n = 0;
        int remainingGuesses = 3;

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
            guessNumericUpDown.Select(0, guessNumericUpDown.Value.ToString().Length);
            remainingGuessesBar1.Value = 100;
            remainingGuessesBar2.Value = 100;
            remainingGuessesBar3.Value = 100;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            //If the answer is correct:
            //make the input box green, add the correct number to the listBox, get the next prime
            if (guessNumericUpDown.Value == primes[n])
            {
                guessNumericUpDown.BackColor = Color.Green;
                listBox1.Items.Insert(0, primes[n]);
                n++;

                primeNrLbl.Text = "Prime nr: " + (n);
            }
            else
            {
                guessNumericUpDown.BackColor = Color.Red;
                remainingGuesses--;
                SetRemainingLives();
                //remainingGuessesBar1.Value -= 33;
                if(remainingGuesses == 0)
                {
                    BackColor = Color.Red;
                    enterBtn.Enabled = false;
                    MessageBox.Show("You failed three times. Better luck next time!");
                    Close();
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
            else if(remainingGuesses == 1)
            {
                remainingGuessesBar2.Value = 0;
            }
            else
            {
                remainingGuessesBar1.Value = 0;
            }
        }
    }
}
