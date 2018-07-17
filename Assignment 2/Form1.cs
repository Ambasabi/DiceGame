using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Assignment_2{
  
    public partial class Form1 : Form
    {
        /// <summary>
        /// The variable that stores a randomly generated number
        /// </summary>
       int iRandomNumber;
        /// <summary>
        /// The variable that stores a random dice number to roll
        /// </summary>
       int iDiceRandom;
        /// <summary>
        /// Stores the amount of times the user clicks the button
        /// </summary>
       int count;
        /// <summary>
        /// Stores the amount of times the user guessed correctly
        /// </summary>
       int right;
        /// <summary>
        /// Stores the amount of times the user guessed incorrectly
        /// </summary>
       int wrong;
        /// <summary>
        /// Stores the amount of time one is randomly generated
        /// </summary>
       int oneRolled;
        /// <summary>
        /// Stores the amount of times two is randomly generated
        /// </summary>
       int twoRolled;
        /// <summary>
        /// stores the amount of times three is randomly generated
        /// </summary>
       int threeRolled;
        /// <summary>
        /// Stores the amount of times four is randomly generated
        /// </summary>
       int fourRolled;
        /// <summary>
        /// Stores the amount of times five is randomly generated
        /// </summary>
       int fiveRolled;
        /// <summary>
        /// Stores the amount of times 6 is reandomly generated
        /// </summary>
       int sixRolled;
        /// <summary>
        /// Stores the amount of times the user guesses 1
        /// </summary>
       int oneGuessed;
        /// <summary>
        /// Stores the amount of times the user guesses 2
        /// </summary>
       int twoGuessed;
        /// <summary>
        /// Stores the amount of times the user guesses 3
        /// </summary>
       int threeGuessed;
        /// <summary>
        /// Stores the amount of times the user guesses 4
        /// </summary>
       int fourGuessed;
        /// <summary>
        /// Sotres the amount of times the user guesses 5
        /// </summary>
       int fiveGuessed;
        /// <summary>
        /// Stores the amount of times the user guesses 6
        /// </summary>
       int sixGuessed;
        /// <summary>
        /// Stores the percentage of overall rolls that were one
        /// </summary>
       double percentOne;
        /// <summary>
        /// stores the percentage of overall rolls that were two
        /// </summary>
       double percentTwo;
        /// <summary>
        /// stores the percentage of overall rolls that were three
        /// </summary>
       double percentThree;
        /// <summary>
        /// stores the percentage of overall rolls that were four
        /// </summary>
       double percentFour;
        /// <summary>
        /// Stores the percentage of overall rolls that were five
        /// </summary>
       double percentFive;
        /// <summary>
        /// stores the percentage of overall rolls that were six
        /// </summary>
       double percentSix;
      
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creating the play button which generates a random number to guess and keeps track of how many 
        /// times it has been clicked. Also calculates the percentage that a particular number was rolled
        /// and stores it in a variable to display. Also displays a simulated dice roll in the event that 
        /// the user guesses the number correctly. Has print statements that say whether the user was correct or incorrect, 
        /// and if they were not correct, displays the number they should have guessed in a statement. Keeps track of
        /// the number of times a user guessed a specific input. Has a TryParse to make sure the user enteres data that is only an integer
        /// between 1 and 6.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlay_Click(object sender, System.EventArgs e)
        {
            
            //Generates the random number and increments count to show how many times we clicked the button
            Random rndNumber = new Random();

           iRandomNumber = rndNumber.Next(1, 7);
           count++;

            //Increments a variable based on whether 1 was rolled, 2 was rolled, etc.
           if (iRandomNumber == 1)
           {
               oneRolled++;                  

           }
           else if (iRandomNumber == 2)
           {
               twoRolled++;
             
           }
           else if (iRandomNumber == 3)
           {
               threeRolled++;
             
           }
           else if (iRandomNumber == 4)
           {
               fourRolled++;
          
           }
           else if (iRandomNumber == 5)
           {
               fiveRolled++;
           
           }
           else
           {
               sixRolled++;
          
           }
           //Calculates the percentage that each number was randomly generated and stores it in a variable for later use
           percentOne = ((double)oneRolled / (double)count) * 100;
           percentTwo = ((double)twoRolled / (double)count) * 100;
           percentThree = ((double)threeRolled / (double)count) * 100;
           percentFour = ((double)fourRolled / (double)count) * 100;
           percentFive = ((double)fiveRolled / (double)count) * 100;
           percentSix = ((double)(sixRolled) / (double)count) * 100;

           int userGuess = 0;

           //obtain the user's guess and make sure they enter only numbers between 1 and 6 using a tryparse

           Int32.TryParse(txtUserGuess.Text, out userGuess);

           if (userGuess < 1)
           {
               lblRightWrong.Text = "Please enter a number between 1 and 6.";
           }
           else if (userGuess > 6)
           {
               lblRightWrong.Text = "Please enter a number between 1 and 6.";
           }
           else
           {
               //My attempt at clearing the image from the screen and re-showing it assuming the program has been cleared.
               pbImage.Show();
               //Stretches the image size
               pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

               //Pulls all 6 .gif die files from the bin and displays them in the program.
               for (int i = 0; i < 3; i++)
               {
                   //Generates a random number that will call a random dice image to roll for the user
                   Random rndNumberDice = new Random();

                   //Makes sure that the dice number is between 1 and 6
                   iDiceRandom = rndNumberDice.Next(1, 7);

                   //generate new random number 1-6 and instead of i.tostring use random integer
                   pbImage.Image = Image.FromFile("die" + iDiceRandom.ToString() + ".gif");
                   pbImage.Refresh();
                   Thread.Sleep(300);
               }

               //Keep track of how many times they guessed a number
               if (userGuess == 1)
               {
                   oneGuessed++;
               }
               else if (userGuess == 2)
               {
                   twoGuessed++;
               }
               else if (userGuess == 3)
               {
                   threeGuessed++;
               }
               else if (userGuess == 4)
               {
                   fourGuessed++;
               }
               else if (userGuess == 5)
               {
                   fiveGuessed++;
               }
               else
               {
                   sixGuessed++;
               }

               //Checks to see if the users guess was right
               if (userGuess == iRandomNumber)
               {
                   //displays a message to the user and increments the "right" variable
                   lblRightWrong.Text = "You guessed correctly! Good job!";
                   right++;

                   
               }
               //Tells the user if they got the wrong answer, and shows them the right answer in the sentence.
               else
               {
                   lblRightWrong.Text = "I am sorry, but the number was " + iRandomNumber + ". Please try again.";
                   wrong++;
               }
               //displays the count of all variables (i.e. how many times 1 was guessed, how many times 1 was rolled, etc.) after the program checks for whether the user guessed properly or not 
               DisplayCount();
              

           }
        }
        /// <summary>
        /// This method displays the amount of times Play was clicked, whether 
        /// 1-6 was rolled, the percentage it was rolled, the amount of times the number was
        /// guessed.
        /// </summary>
        private void DisplayCount()
        {
            
            lblCount.Text = Convert.ToString(count);
            lblRightCount.Text = Convert.ToString(right);
            lblWrongCount.Text = Convert.ToString(wrong);
            lblOneRolled.Text = Convert.ToString(oneRolled);
            lblTwoRolled.Text = Convert.ToString(twoRolled);
            lblThreeRolled.Text = Convert.ToString(threeRolled);
            lblFourRolled.Text = Convert.ToString(fourRolled);
            lblFiveRolled.Text = Convert.ToString(fiveRolled);
            lblSixRolled.Text = Convert.ToString(sixRolled);
            lblOnePercent.Text = Convert.ToString(percentOne);
            lblTwoPercent.Text = Convert.ToString(percentTwo);
            lblThreePercent.Text = Convert.ToString(percentThree);
            lblFourPercent.Text = Convert.ToString(percentFour);
            lblFivePercent.Text = Convert.ToString(percentFive);
            lblSixPercent.Text = Convert.ToString(percentSix);
            lblOneGuessed.Text = Convert.ToString(oneGuessed);
            lblTwoGuessed.Text = Convert.ToString(twoGuessed);
            lblThreeGuessed.Text = Convert.ToString(threeGuessed);
            lblFourGuessed.Text = Convert.ToString(fourGuessed);
            lblFiveGuessed.Text = Convert.ToString(fiveGuessed);
            lblSixGuessed.Text = Convert.ToString(sixGuessed);
            
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
             lblCount.Text = "";
             lblRightCount.Text = "";
             lblWrongCount.Text = "";
             lblOneRolled.Text = "";
             lblTwoRolled.Text = "";
             lblThreeRolled.Text = "";
             lblFourRolled.Text = "";
             lblFiveRolled.Text = "";
             lblSixRolled.Text = "";
             lblOnePercent.Text = "";
             lblTwoPercent.Text = "";
             lblThreePercent.Text = "";
             lblFourPercent.Text = "";
             lblFivePercent.Text = "";
             lblSixPercent.Text = "";
             lblOneGuessed.Text = "";
             lblTwoGuessed.Text = "";
             lblThreeGuessed.Text = "";
             lblFourGuessed.Text = "";
             lblFiveGuessed.Text = "";
             lblSixGuessed.Text = "";
             lblRightWrong.Text = "";
             txtUserGuess.Text = "";
            //My attempt at clearing the image, then reshowing it above when it is clear
             pbImage.Hide();

            
        }

       }
}
