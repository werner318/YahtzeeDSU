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
        int _total = 0;
        int _yahtzeeCounter = 0; //for bonus
        public ScoreSheet(int rollCheck, int num, int[] dice, bool block)
        {
            _total = OneToSixAdd(rollCheck, num, dice, block);
        }
        public ScoreSheet(ScoreSheet s)
        {
            _total = s.Total;
        }
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        private int OneToSixAdd(int rollCheck, int num, int[] dice, bool block)
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
            if (howMany == 5)
                _yahtzeeCounter++;
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
                        _total = addDice(diceResults);
                        break;
                    }
                    else
                        _total = 0;
                }
            }
            else if (type == "fourOfKind")
            {
                for (int i = 0; i < diceResults.Length; i++)
                {
                    if (diceResults[i] == 4 || diceResults[i] == 5)
                    {
                        _total = addDice(diceResults);
                        break;
                    }
                    else
                        _total = 0;
                }
            }
            else if (type == "fullHouse")
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    if (_total == 25)
                        break;
                    if (diceResults[i] == 3 || diceResults[i] == 2)
                    {
                        for (int j = i + 1; j <= dice.Length; j++)
                        {
                            if ((diceResults[i] == 3 && diceResults[j] == 2) || (diceResults[i] == 2 && diceResults[j] == 3))
                            {
                                _total = 25;
                                break;
                            }

                        }
                    }
                    else
                        _total = 0;
                }
            }
            else if (type == "smallStraight")
            {

                if (diceResults[0] >= 1 && diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1)
                    _total = 30;
                else if (diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1)
                    _total = 30;
                else if (diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1 && diceResults[5] >= 1)
                    _total = 30;
                else
                    _total = 0;
                
            }
            else if (type == "highStraight")
            {
                if (diceResults[0] >= 1 && diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1)
                    _total = 40;
                else if (diceResults[1] >= 1 && diceResults[2] >= 1 && diceResults[3] >= 1 && diceResults[4] >= 1 && diceResults[5] >= 1)
                    _total = 40;
                else
                    _total = 0;
            }
            else if (type == "yahtzee")
            {
                for (int i = 0; i < diceResults.Length; i++)
                {
                    if (diceResults[i] == 5)
                    {
                        _total = 50;
                        break;
                    }
                    else
                        _total = 0;
                }
            }
            else if (type == "chance")
            {
                _total = addDice(diceResults);
            }
        }
        private int addDice(int[] numbers)
        {
            int score = (1 * numbers[0]) + (2 * numbers[1]) + (3 * numbers[2]) +
                            (4 * numbers[3]) + (5 * numbers[4]) + (6 * numbers[5]);
            return score;
        }
        public int YahtzeeCounter
        {
            get { return _yahtzeeCounter; }
            set { _yahtzeeCounter = value; }
        }
    }
}
    