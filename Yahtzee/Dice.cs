using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public class Dice : Form1
    {
        public Dice(string type, int[] diceResults, int[] dice, Image[] diceImages, int rollCheck, bool[] HoldState, bool blockUser)
        {
            if (rollCheck < 3)
            {
                if (blockUser == false)
                {
                    RollDice(diceResults, dice, diceImages, HoldState);
                    rollCheck++;
                }
                else
                {
                    blockUser = true;
                }
            }
        }
        public void RollDice(int[] diceResults, int[] dice, Image[] diceImages, bool[] HoldState)
        {
            Random rand = new Random();
            ResetResults(diceResults);
            for (int i = 0; i < dice.Length; i++)
            {
                if (HoldState[i] == false)
                    dice[i] = rand.Next(1, 6 + 1);

                switch (dice[i])
                {
                    case 1:
                        diceResults[0]++;
                        break;
                    case 2:
                        diceResults[1]++;
                        break;
                    case 3:
                        diceResults[2]++;
                        break;
                    case 4:
                        diceResults[3]++;
                        break;
                    case 5:
                        diceResults[4]++;
                        break;
                    case 6:
                        diceResults[5]++;
                        break;
                }

            }
        }
        public void ResetResults(int[] diceResults)
        {
            for (int i = 0; i < diceResults.Length; i++)
            {
                diceResults[i] = 0;
            }
        }

        public Dice(int diceIndex, bool[] HoldState)
        {
            if (HoldState[diceIndex] == false)
            {
                HoldState[diceIndex] = true;
            }
            else
            {
                HoldState[diceIndex] = false;
            }
        }
        
    }
}
