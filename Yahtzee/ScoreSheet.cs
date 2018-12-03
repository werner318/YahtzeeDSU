using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    class ScoreSheet : Form1
    {
        int total = 0;
        public ScoreSheet(int rollCheck, int num, int[] dice, bool block)
        {
            total = OneToSixAdd(rollCheck, num, dice, block);
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
        public int OneToSixAdd(int rollCheck, int num, int[] dice, bool block)
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
        public ScoreSheet(int[] dice, int[] diceResults, string type)
        {
            if (type == "threeOfKind")
            {
                for (int i = 0; i < diceResults.Length; i++)
                {
                    if (diceResults[i] == 3 || diceResults[i] == 4 || diceResults[i] == 5)
                    {
                        total = addDice(diceResults);
                        break;
                    }
                    else
                        total = 0;
                }
            }
            else if (type == "fourOfKind")
            {
                for (int i = 0; i < diceResults.Length; i++)
                {
                    if (diceResults[i] == 4 || diceResults[i] == 5)
                    {
                        total = addDice(diceResults);
                        break;
                    }
                    else
                        total = 0;
                }
            }
            else if (type == "fullHouse")
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    if (total == 25)
                        break;
                    if (diceResults[i] == 3 || diceResults[i] == 2)
                    {
                        for (int j = i + 1; j <= dice.Length; j++)
                        {
                            if ((diceResults[i] == 3 && diceResults[j] == 2) || (diceResults[i] == 2 && diceResults[j] == 3))
                            {
                                total = 25;
                                break;
                            }

                        }
                    }
                    else
                        total = 0;
                }
            }
            else if (type == "smallStraight")
            {

                if (diceResults[0] >= 1 && diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1)
                    total = 30;
                else if (diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1)
                    total = 30;
                else if (diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1 && diceResults[5] >= 1)
                    total = 30;
                else
                    total = 0;
                
            }
            else if (type == "highStraight")
            {
                if (diceResults[0] >= 1 && diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1)
                    total = 40;
                else if (diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1 && diceResults[5] >= 1)
                    total = 40;
                else
                    total = 0;
            }
            else if (type == "yahtzee")
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    if (diceResults[i] == 5)
                    {
                        total = 50;
                        break;
                    }
                    else
                        total = 0;
                }
            }
            else if (type == "chance")
            {
                total = addDice(diceResults);
            }
        }
        public int addDice(int[] numbers)
        {
            int score = (1 * numbers[0]) + (2 * numbers[1]) + (3 * numbers[2]) +
                            (4 * numbers[3]) + (5 * numbers[4]) + (6 * numbers[5]);
            return score;
        }
    }
}
    