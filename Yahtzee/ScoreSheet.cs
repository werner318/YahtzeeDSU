using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class ScoreSheet : Form1
    {
        int total = 0;
        public ScoreSheet(int rollCheck, int category, int[] dice, bool block)
        {
            if(category==1) total = OneToSixAdd(rollCheck,1,dice, block);
            else if (category == 2) total = OneToSixAdd(rollCheck, 2, dice, block);
            else if (category == 3) total = OneToSixAdd(rollCheck, 3, dice, block);
            else if (category == 4) total = OneToSixAdd(rollCheck, 4, dice, block);
            else if (category == 5) total = OneToSixAdd(rollCheck, 5, dice, block);
            else if (category == 6) total = OneToSixAdd(rollCheck, 6, dice, block);
        }
        public ScoreSheet(ScoreSheet s)
        {
            total = s.total;
        }
        //public int _total;
        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        public int OneToSixAdd(int rollCheck,int num, int[] dice, bool block)
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
        }/*
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
            //var Score = new ScoreSheet(rollCheck,1, dice, block);
            //var total = new ScoreSheet(Score);
            int total = OneToSixAdd(1);
            onesBtn.Text = Convert.ToString(total);
            prevScore = Convert.ToInt16(onesBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(onesBtn.Text) + checkBonus;
        }

        private void numTwos(object sender, EventArgs e)
        {
            int total = OneToSixAdd(2);
            twosBtn.Text = Convert.ToString(total);
            prevScore = Convert.ToInt16(twosBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(twosBtn.Text) + checkBonus;
        }

        private void numThrees(object sender, EventArgs e)
        {
            int total = OneToSixAdd(3);
            threesBtn.Text = Convert.ToString(total);
            prevScore = Convert.ToInt16(threesBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(threesBtn.Text) + checkBonus;
        }

        private void numFours(object sender, EventArgs e)
        {
            int total = OneToSixAdd(4);
            foursBtn.Text = Convert.ToString(total);
            prevScore = Convert.ToInt16(foursBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(foursBtn.Text) + checkBonus;
        }

        private void numFives(object sender, EventArgs e)
        {
            int total = OneToSixAdd(5);
            fivesBtn.Text = Convert.ToString(total);
            prevScore = Convert.ToInt16(fivesBtn.Text) + prevScore;
            checkBonus = Convert.ToInt16(fivesBtn.Text) + checkBonus;
        }

        private void numSixes(object sender, EventArgs e)
        {
            int total = OneToSixAdd(6);
            sixesBtn.Text = Convert.ToString(total);
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
        }*/
    }
}
