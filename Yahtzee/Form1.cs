﻿#region Using Statements
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
        #region Declaration
        public Image[] diceImages;
        public int[] dice;
        public int[] diceResults;
        public bool[] HoldState = new bool[5];
        public int rollCheck = 0;
        public bool block = false;
        public Random rand;
        public int prevScore = 0;
        public int checkBonus = 0;
        int[] holdPressed = { 0, 0, 0, 0, 0 };
        #endregion

        #region Initialization
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }
        #endregion
        
        private void btnRoll(object sender, EventArgs e)
        {
            if (rollCheck < 3)
            {
                var Roll = new Dice("Roll", diceResults, dice, diceImages, rollCheck, HoldState, block);
                rollCheck++;
                rollTextBox.Text = "ROLL  " + rollCheck;
                dice1.Image = diceImages[dice[0]];
                dice2.Image = diceImages[dice[1]];
                dice3.Image = diceImages[dice[2]];
                dice4.Image = diceImages[dice[3]];
                dice5.Image = diceImages[dice[4]];
            }
        }        
        public int[] _getDiceResults;
        public int[] GetDiceResults
        {
            get { return _getDiceResults; }
            set { _getDiceResults = value; }
        }
        public void FuntionHoldDice(int index, int type)
        {
            holdPressed[index]++;
            if (holdPressed[index] == 1)
            {
                if (type == 0) dice1.BorderStyle = BorderStyle.Fixed3D;
                else if (type == 1) dice2.BorderStyle = BorderStyle.Fixed3D;
                else if (type == 2) dice3.BorderStyle = BorderStyle.Fixed3D;
                else if (type == 3) dice4.BorderStyle = BorderStyle.Fixed3D;
                else if (type == 4) dice5.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                if (type == 0) dice1.BorderStyle = BorderStyle.FixedSingle;
                else if (type == 1) dice2.BorderStyle = BorderStyle.FixedSingle;
                else if (type == 2) dice3.BorderStyle = BorderStyle.FixedSingle;
                else if (type == 3) dice4.BorderStyle = BorderStyle.FixedSingle;
                else if (type == 4) dice5.BorderStyle = BorderStyle.FixedSingle;
                holdPressed[index] = 0;
            }
            var Hold = new Dice(type, HoldState);
        }
        private void holdDice1(object sender, EventArgs e)
        {
            FuntionHoldDice(0,0);
        }

        private void holdDice2(object sender, EventArgs e)
        {
            FuntionHoldDice(1, 1);
        }

        private void holdDice3(object sender, EventArgs e)
        {
            FuntionHoldDice(2, 2);
        }

        private void holdDice4(object sender, EventArgs e)
        {
            FuntionHoldDice(3, 3);
        }

        private void holdDice5(object sender, EventArgs e)
        {
            FuntionHoldDice(4, 4);
        }

        private void btnPlay(object sender, EventArgs e)
        {
            //if (block == false) //make sure when user clicked scoresheet (block==true) than click play to reset
                //return;
            rollCheck = 0;
            rollTextBox.Text = "ROLL  " + rollCheck;
            block = false;
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
            if (checkBonus >= 63)
                scoreTextBox.Text = Convert.ToString(prevScore + 35);
        }

        private int OneToSixAdd(int num)
        {
            int howMany = 0;
            if (rollCheck != 0 && block == false)
            {               
                for (int i = 0; i < dice.Length; i++)
                {
                    if (dice[i] == num)
                    {
                        howMany++;
                    }
                }               
            }
            rollCheck = 0;
            block = true;
            return howMany * num;
        }
        
        private void numOnes(object sender, EventArgs e)
        {
            var Score = new ScoreSheet(rollCheck,1, dice, block);
            int total1 = Score.Total;
            onesBtn.Text = Convert.ToString(total1);
            prevScore = Convert.ToInt16(onesBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(onesBtn.Text) + checkBonus;
        }

        private void numTwos(object sender, EventArgs e)
        {
            var Score = new ScoreSheet(rollCheck, 2, dice, block);
            int total2 = Score.Total;
            twosBtn.Text = Convert.ToString(total2);
            prevScore = Convert.ToInt16(twosBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(twosBtn.Text) + checkBonus;
        }

        private void numThrees(object sender, EventArgs e)
        {
            var Score = new ScoreSheet(rollCheck, 3, dice, block);
            int total3 = Score.Total;
            threesBtn.Text = Convert.ToString(total3);
            prevScore = Convert.ToInt16(threesBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(threesBtn.Text) + checkBonus;
        }

        private void numFours(object sender, EventArgs e)
        {
            var Score = new ScoreSheet(rollCheck, 4, dice, block);
            int total4 = Score.Total;
            foursBtn.Text = Convert.ToString(total4);
            prevScore = Convert.ToInt16(foursBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(foursBtn.Text) + checkBonus;
        }

        private void numFives(object sender, EventArgs e)
        {
            var Score = new ScoreSheet(rollCheck, 5, dice, block);
            int total5 = Score.Total;
            fivesBtn.Text = Convert.ToString(total5);
            prevScore = Convert.ToInt16(fivesBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(fivesBtn.Text) + checkBonus;
        }

        private void numSixes(object sender, EventArgs e)
        {
            var Score = new ScoreSheet(rollCheck, 6, dice, block);
            int total6 = Score.Total;
            sixesBtn.Text = Convert.ToString(total6);
            prevScore = Convert.ToInt16(sixesBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(sixesBtn.Text) + checkBonus;
        }

        private int addDice(int[] numbers)
        {
            int score = (1 * numbers[0]) + (2 * numbers[1]) + (3 * numbers[2]) +
                            (4 * numbers[3]) + (5 * numbers[4]) + (6 * numbers[5]);
            return score;
        }
        private void threeOfKind(object sender, EventArgs e)
        {            
            if (threeKindBtn.Text == "" && rollCheck != 0 && block == false)
            {              
                for (int i = 0; i < diceResults.Length; i++)
                {
                    if (diceResults[i] == 3 || diceResults[i] == 4 || diceResults[i] == 5)
                    {
                        threeKindBtn.Text = Convert.ToString(addDice(diceResults));
                        break;
                    }         
                    else
                        threeKindBtn.Text = "0";
                }
                prevScore = Convert.ToInt16(threeKindBtn.Text) + prevScore;
            }
            rollCheck = 0;
            block = true;
        }

        private void fourOfKind(object sender, EventArgs e)
        {
            if (fourKindBtn.Text == "" && rollCheck != 0 && block == false)
            {

                for (int i = 0; i < diceResults.Length; i++)
                {
                    if (diceResults[i] == 4 || diceResults[i] == 5)
                    {
                        fourKindBtn.Text = Convert.ToString(addDice(diceResults));
                        break;
                    }
                    else
                        fourKindBtn.Text = "0";
                }
                prevScore = Convert.ToInt16(fourKindBtn.Text) + prevScore;
            }
            rollCheck = 0;
            block = true;
        }

        private void fullHouse(object sender, EventArgs e)
        {
            if (fullHouseBtn.Text == "" && rollCheck != 0 && block == false)
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    if (fullHouseBtn.Text == "25")
                        break;
                    if (diceResults[i] == 3 || diceResults[i] == 2)
                    {
                        for (int j = i+1; j <= dice.Length; j++)
                        {
                            if ((diceResults[i] == 3 && diceResults[j] == 2) || (diceResults[i] == 2 && diceResults[j] == 3))
                            {
                                fullHouseBtn.Text = "25";
                                break;
                            }
                                
                        }
                    }
                    else
                        fullHouseBtn.Text = "0";
                }
                prevScore = Convert.ToInt16(fullHouseBtn.Text) + prevScore;
            }
            rollCheck = 0;
            block = true;
        }

        private void smallStraight(object sender, EventArgs e)
        {
            if (smallStraightBtn.Text == "" && rollCheck != 0 && block == false)
            {
                if (diceResults[0] >= 1 && diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1)
                    smallStraightBtn.Text = "30";
                else if (diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1)
                    smallStraightBtn.Text = "30";
                else if (diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1 && diceResults[5] >= 1)
                    smallStraightBtn.Text = "30";
                else
                    smallStraightBtn.Text = "0";
                prevScore = Convert.ToInt16(smallStraightBtn.Text) + prevScore;
            }
            rollCheck =0;
            block = true;
        }

        private void largeStraight(object sender, EventArgs e)
        {
            if (highStraightBtn.Text == "" && rollCheck != 0 && block == false)
            {
                if (diceResults[0] >= 1 && diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1)
                    highStraightBtn.Text = "40";
                else if (diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1 && diceResults[5] >= 1)
                    highStraightBtn.Text = "40";
                else
                    highStraightBtn.Text = "0";
                prevScore = Convert.ToInt16(highStraightBtn.Text) + prevScore;
            }            
            rollCheck = 0;
            block = true;
        }

        private void yahtzee(object sender, EventArgs e)
        {
            if(yahtzeeBtn.Text == "" && rollCheck != 0 && block == false)
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    if (diceResults[i] == 5)
                    {
                        yahtzeeBtn.Text = "50";
                        break;
                    }
                    else
                        yahtzeeBtn.Text = "0";
                }
                prevScore = Convert.ToInt16(yahtzeeBtn.Text) + prevScore;
            }
            rollCheck = 0;
            block = true;

        }

        private void chance(object sender, EventArgs e)
        {
            if (chanceBtn.Text == "" && rollCheck != 0 && block == false)
            {
                chanceBtn.Text = Convert.ToString(addDice(diceResults));
                prevScore = Convert.ToInt16(chanceBtn.Text) + prevScore;
            }                          
            rollCheck = 0;
            block = true;
        }
        
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
            block = false;
            prevScore = 0;
            checkBonus = 0;
    }
        private void newGame(object sender, EventArgs e)
        {
            NewGame();
            scoreTextBox.Text = bonusTextBox.Text = "0"; onesBtn.Text = twosBtn.Text = threesBtn.Text = foursBtn.Text = fivesBtn.Text 
                = sixesBtn.Text = threeKindBtn.Text = fourKindBtn.Text = fullHouseBtn.Text = smallStraightBtn.Text
                = highStraightBtn.Text = yahtzeeBtn.Text = chanceBtn.Text = "";
        }        
    }
}
