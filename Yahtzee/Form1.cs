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
        #region fields declaration           
        public Image[] diceImages = new Image[7];
        public int[] dice = new int[5] { 0, 0, 0, 0, 0 };
        public int[] diceResults = new int[6] { 0, 0, 0, 0, 0, 0 };
        public bool[] HoldState = new bool[5];
        public int rollCheck = 0;
        public bool blockUser = false;
        public Random rand = new Random();
        public int prevScore = 0;
        public int bonusScore = 0;
        bool onlyOnceBonus = false;
        int gamesPlayed, bestScore, bestMinor, bestMajor, recordOfYahtzee = 0;
        double averageScore = 0;
        bool leaderBoardsCanbeOpen = false;
        int[] holdPressed = { 0, 0, 0, 0, 0 };
        private int[] tmpBestScore = { 0, 0, 0, 0, 0 };
        private int[] tmpBestMinor = { 0, 0, 0, 0, 0 };
        private int[] tmpBestMajor = { 0, 0, 0, 0, 0 };
        int biggestScore = 0, biggestMinor = 0, biggestMajor = 0;
        bool isMenuPanelOpen = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            diceImages[0] = Properties.Resources.dice_7;
            diceImages[1] = Properties.Resources.dice_1;
            diceImages[2] = Properties.Resources.dice_2;
            diceImages[3] = Properties.Resources.dice_3;
            diceImages[4] = Properties.Resources.dice_4;
            diceImages[5] = Properties.Resources.dice_5;
            diceImages[6] = Properties.Resources.dice_6;
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
            if(rollCheck>=1) //prevent user to hold the blank images
                FuntionHoldDice(0,dice1);
        }
        //holdDice2 button
        private void holdDice2(object sender, EventArgs e)
        {
            if (rollCheck >= 1)
                FuntionHoldDice(1, dice2);
        }
        //holdDice3 button
        private void holdDice3(object sender, EventArgs e)
        {
            if (rollCheck >= 1)
                FuntionHoldDice(2, dice3);
        }
        //holdDice4 button
        private void holdDice4(object sender, EventArgs e)
        {
            if (rollCheck >= 1)
                FuntionHoldDice(3, dice4);
        }
        //holdDice5 button
        private void holdDice5(object sender, EventArgs e)
        {
            if (rollCheck >= 1)
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
            if (!blockUser) //block user should be set to true, if its false user hasnt clicked scoresheet
                return;
            rollCheck = 0;
            rollTextBox.Text = "ROLL  " + rollCheck;
            blockUser = false;
            for(int i=0; i < dice.Length; i++)
            {
                HoldState[i] = false;
                holdPressed[i] = 0;
            }
            SetBlankImages(dice1); 
            SetBlankImages(dice2);
            SetBlankImages(dice3);
            SetBlankImages(dice4);
            SetBlankImages(dice5);

            scoreTextBox.Text = Convert.ToString(prevScore);
            bonusTextBox.Text = Convert.ToString(bonusScore);
            if (bonusScore >= 63 && onlyOnceBonus == false)
            {
                scoreTextBox.Text = Convert.ToString(prevScore + 35);
                onlyOnceBonus = true;
            }
        } 
        //function to setBlankImages
        public void SetBlankImages(PictureBox dice)
        {
            dice.Image = Properties.Resources.dice_7;
            dice.BorderStyle = BorderStyle.FixedSingle;
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
                int yahtzeeCounter = Score.YahtzeeCounter;
                if (yahtzeeBtn.Text=="50") //if you get another yahtzee, you get 50+ your total
                {
                    if(yahtzeeCounter>=1)
                    {
                        recordOfYahtzee++; 
                        button.Text = Convert.ToString(total + 50);
                    }
                    else
                        button.Text = Convert.ToString(total);
                }
                else
                    button.Text = Convert.ToString(total);
                prevScore = Convert.ToInt16(button.Text) + prevScore;
                bonusScore = Convert.ToInt16(button.Text) + bonusScore;
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
            var newGame = new YahtzeeLogisticsMenu("newGame");
            newGame.setVariables(dice, diceResults, HoldState, rollCheck, blockUser, prevScore,
               bonusScore, onlyOnceBonus);
            rand = new Random();
            rollCheck = newGame.RollCheck;
            dice = newGame.Dice;
            diceResults = newGame.DiceResults;
            HoldState = newGame.HoldState;
            blockUser = newGame.BlockUser;
            prevScore = newGame.PrevScore;
            bonusScore = newGame.BonusScore;
            onlyOnceBonus = newGame.OnlyOnceBonus;
        }
        //funtion to set each textbox.text to 0 if user clicked the new game button.
        private void newGame(object sender, EventArgs e)
        {
            gamesPlayed++; bestScore = Convert.ToInt32(scoreTextBox.Text); bestMinor = Convert.ToInt32(bonusTextBox.Text);
            if (bestMinor >= 63)
                bestMajor = bestScore - bestMinor - 35;
            else
                bestMajor = bestScore - bestMinor;
            leaderBoardsCanbeOpen = true;
            if (yahtzeeBtn.Text == "50") recordOfYahtzee++;
            NewGame();
            scoreTextBox.Text = bonusTextBox.Text = "0"; onesBtn.Text = twosBtn.Text = threesBtn.Text = foursBtn.Text = fivesBtn.Text 
                = sixesBtn.Text = threeKindBtn.Text = fourKindBtn.Text = fullHouseBtn.Text = smallStraightBtn.Text
                = highStraightBtn.Text = yahtzeeBtn.Text = chanceBtn.Text = ""; bonusScore = prevScore = rollCheck = 0;
            rollTextBox.Text = "ROLL  " + rollCheck;
            SetBlankImages(dice1); //if newgame button is clicked, set blank images/reset hold background
            SetBlankImages(dice2);
            SetBlankImages(dice3);
            SetBlankImages(dice4);
            SetBlankImages(dice5);
        }
        //for dropdown list
        private void timer1_Tick(object sender, EventArgs e)
        {
            var list = new YahtzeeLogisticsMenu(isMenuPanelOpen, panelDropDownList, timer1);
            isMenuPanelOpen = list.IsMenuPanelOpen;
        }
        //for dropdown list
        private void LogisticsList_Click(object sender, EventArgs e)
        {           
            timer1.Start();            
        }
        //rulesbutton class that displays description
        private void RulesBtn_Click(object sender, EventArgs e)
        {
            var Rules = new YahtzeeLogisticsMenu("Rules");
        }
        //leaderboards class that dsiplays the info
        private void LeaderboardsBtn_Click(object sender, EventArgs e)
        {
            if(leaderBoardsCanbeOpen)
            {
                biggestScore = bestScore = bestTypeFunction(bestScore, tmpBestScore, biggestScore);
                if (biggestScore == -1)
                    return;
                biggestMinor = bestMinor = bestTypeFunction(bestMinor, tmpBestMinor, biggestMinor);
                biggestMajor = bestMajor = bestTypeFunction(bestMajor, tmpBestMajor, biggestMajor);
                for (int i=0; i<gamesPlayed; i++)
                {
                    averageScore = tmpBestScore[i] + averageScore;
                }
                averageScore = averageScore / gamesPlayed;
                var Leaderboards = new YahtzeeLogisticsMenu(gamesPlayed, bestScore, bestMinor, bestMajor, averageScore, recordOfYahtzee);
                averageScore = 0;
            }                
        }
        private int bestTypeFunction( int bestType, int[] tmpBestScore, int biggest)
        {            
            if (gamesPlayed <= 5)
            {
                tmpBestScore[gamesPlayed - 1] = bestType;
                for (int i = 0; i < gamesPlayed; i++)
                {
                    if (biggest < tmpBestScore[i])
                    {
                        biggest = tmpBestScore[i];
                        return tmpBestScore[i];                       
                    }
                }
            }
            else
            {
                MessageBox.Show("This version only holds 5 attempts");
                return -1; //error
            }
            return biggest;            
        }
    }
}
