#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion
namespace Yahtzee
{
    public partial class Form1 : Form
    {
        //fields
        public Image[] diceImages;
        public int[] dice;
        public int[] diceResults;
        public bool[] HoldState = new bool[5];
        public int rollCheck = 0;
        public bool blockUser = false;
        public Random rand;
        public int prevScore = 0;
        public int checkBonus = 0;
        bool onlyOnceBonus = false;
        int[] holdPressed = { 0, 0, 0, 0, 0 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }

        //roll button that goes into the dice class to do the meathod of rolling the 5 dice. than afterwards displays image at each index
        private void btnRoll(object sender, EventArgs e)
        {
            if (rollCheck < 3)
            {
                var Roll = new Dice("Roll", diceResults, dice, diceImages, rollCheck, HoldState, blockUser);
                rollCheck++;
                rollTextBox.Text = "ROLL  " + rollCheck;
                dice1.Image = diceImages[dice[0]];
                dice2.Image = diceImages[dice[1]];
                dice3.Image = diceImages[dice[2]];
                dice4.Image = diceImages[dice[3]];
                dice5.Image = diceImages[dice[4]];
            }
        }               
        //holdDice1 button
        private void holdDice1(object sender, EventArgs e)
        {
            FuntionHoldDice(0,dice1);
        }
        //holdDice2 button
        private void holdDice2(object sender, EventArgs e)
        {
            FuntionHoldDice(1, dice2);
        }
        //holdDice3 button
        private void holdDice3(object sender, EventArgs e)
        {
            FuntionHoldDice(2, dice3);
        }
        //holdDice4 button
        private void holdDice4(object sender, EventArgs e)
        {
            FuntionHoldDice(3, dice4);
        }
        //holdDice5 button
        private void holdDice5(object sender, EventArgs e)
        {
            FuntionHoldDice(4, dice5);
        }
        //function to go into Dice class to do the Hold Method
        public void FuntionHoldDice(int index, PictureBox dice)
        {
            int type = index;
            holdPressed[index]++;
            if (holdPressed[index] == 1)
                dice.BorderStyle = BorderStyle.Fixed3D;//notify user that whatever dice they want to hold shows up aka border around dice
            else
            {
                dice.BorderStyle = BorderStyle.FixedSingle; //switch from a boarder to nothing
                holdPressed[index] = 0;
            }
            var Hold = new Dice(type, HoldState);
        }
        //play button
        private void btnPlay(object sender, EventArgs e)
        {
            rollCheck = 0;
            rollTextBox.Text = "ROLL  " + rollCheck;
            blockUser = false;
            for(int i=0; i < dice.Length; i++)
            {
                HoldState[i] = false;
                holdPressed[i] = 0;
            }          
            dice1.Image = Properties.Resources.dice_7;
            dice1.BorderStyle = BorderStyle.FixedSingle;
            dice2.Image = Properties.Resources.dice_7;
            dice2.BorderStyle = BorderStyle.FixedSingle;
            dice3.Image = Properties.Resources.dice_7;
            dice3.BorderStyle = BorderStyle.FixedSingle;
            dice4.Image = Properties.Resources.dice_7;
            dice4.BorderStyle = BorderStyle.FixedSingle;
            dice5.Image = Properties.Resources.dice_7;
            dice5.BorderStyle = BorderStyle.FixedSingle;

            scoreTextBox.Text = Convert.ToString(prevScore);
            bonusTextBox.Text = Convert.ToString(checkBonus);
            if (checkBonus >= 63 && onlyOnceBonus == false)
            {
                scoreTextBox.Text = Convert.ToString(prevScore + 35);
                onlyOnceBonus = true;
            }
        }  
        //numOnes button
        private void numOnes(object sender, EventArgs e)
        {
            doMinor(1, onesBtn);
        }
        //numTwos button
        private void numTwos(object sender, EventArgs e)
        {
            doMinor(2, twosBtn);
        }
        //numThree button
        private void numThrees(object sender, EventArgs e)
        {
            doMinor(3, threesBtn);
        }
        //numFour button
        private void numFours(object sender, EventArgs e)
        {
            doMinor(4, foursBtn);
        }
        //numFive button
        private void numFives(object sender, EventArgs e)
        {
            doMinor(5, fivesBtn);
        }
        //numSix button
        private void numSixes(object sender, EventArgs e)
        {
            doMinor(6, sixesBtn);
        }
        //3Kind button
        private void threeOfKind(object sender, EventArgs e)
        {              
            doMajor(threeKindBtn, "threeOfKind");
        }   
        //4Kind button
        private void fourOfKind(object sender, EventArgs e)
        {
            doMajor(fourKindBtn, "fourOfKind");
        }
        //fullHouse button
        private void fullHouse(object sender, EventArgs e)
        {
            doMajor(fullHouseBtn, "fullHouse");
        }
        //smallStraight button
        private void smallStraight(object sender, EventArgs e)
        {
            doMajor(smallStraightBtn, "smallStraight");
        }
        //highStraight button
        private void largeStraight(object sender, EventArgs e)
        {
            doMajor(highStraightBtn, "highStraight");
        }
        //yahtzee button
        private void yahtzee(object sender, EventArgs e)
        {
            doMajor(yahtzeeBtn, "yahtzee");
        }
        //chance button
        private void chance(object sender, EventArgs e)
        {
            doMajor(chanceBtn, "chance");
        }
        //funtion to go into Scoresheet classe to do the work. This is for the Minor buttons (adding "1s" "2s" "3s" "4s" "5s" "6s")
        public void doMinor(int num, Button button)
        {
            if (button.Text == "" && blockUser == false)
            {
                var Score = new ScoreSheet(rollCheck, num, dice, blockUser);
                int total = Score.Total;
                button.Text = Convert.ToString(total);
                prevScore = Convert.ToInt16(button.Text) + prevScore;
                checkBonus = Convert.ToInt16(button.Text) + checkBonus;
                ResetFlags();
            }
        }
        //funtion to go into Scoresheet class to do the work. This is for the Major buttons ("3Kind, 4Kind, fullH, smallS, highS, yahtzee, chance")
        public void doMajor(Button button, string type)
        {
            if (button.Text == "" && blockUser == false)
            {
                var Score = new ScoreSheet(dice, diceResults, type);
                int total = Score.Total;
                button.Text = Convert.ToString(total);
                prevScore = Convert.ToInt16(button.Text) + prevScore;
                ResetFlags();
            }
        }
        //function to reset flags so user cant keep clicking the scoresheet without clicking play button
        public void ResetFlags()
        {
            rollCheck = 0;
            blockUser = true;
        }
        //function to load the game, set fields to 0/false, set diceImages to blank and diceResults to 0
        public void NewGame()
        {
            diceImages = new Image[7];
            diceImages[0] = Properties.Resources.dice_7;
            diceImages[1] = Properties.Resources.dice_1;
            diceImages[2] = Properties.Resources.dice_2;
            diceImages[3] = Properties.Resources.dice_3;
            diceImages[4] = Properties.Resources.dice_4;
            diceImages[5] = Properties.Resources.dice_5;
            diceImages[6] = Properties.Resources.dice_6;

            dice = new int[5] { 0, 0, 0, 0, 0 };
            diceResults = new int[6] { 0, 0, 0, 0, 0, 0 };
            rand = new Random();
            for (int i = 0; i < dice.Length; i++)
                HoldState[i] = false;
            rollCheck = 0;
            blockUser = false;
            prevScore = 0;
            checkBonus = 0;
            onlyOnceBonus = false;
        }
        //funtion to set each textbox.text to 0 if user clicked the new game button.
        private void newGame(object sender, EventArgs e)
        {
            NewGame();
            scoreTextBox.Text = bonusTextBox.Text = "0"; onesBtn.Text = twosBtn.Text = threesBtn.Text = foursBtn.Text = fivesBtn.Text 
                = sixesBtn.Text = threeKindBtn.Text = fourKindBtn.Text = fullHouseBtn.Text = smallStraightBtn.Text
                = highStraightBtn.Text = yahtzeeBtn.Text = chanceBtn.Text = "";
        }        
    }
}
