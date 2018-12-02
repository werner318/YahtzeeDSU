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
        #region Declaration
        Image[] diceImages;
        int[] dice;
        int[] diceResults;
        bool[] HoldState = new bool[5];
        int rollCheck = 0;
        bool block = false;
        Random rand;
 
        #endregion

        #region Initialization
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
        }
        #endregion

        private void btnRull(object sender, EventArgs e)
        {
            if(rollCheck < 3)
            {
                if (block == false)
                {
                    RollDice();
                    rollCheck++;
                }
                else
                {
                    block = true;
                }
            }          
        }

        private void RollDice()
        {
            ResetResults();
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
            dice1.Image = diceImages[dice[0]];
            dice2.Image = diceImages[dice[1]];
            dice3.Image = diceImages[dice[2]];
            dice4.Image = diceImages[dice[3]];
            dice5.Image = diceImages[dice[4]];
        }
        
        
        private void holdDice1(object sender, EventArgs e)
        {
            if (HoldState[0] == false)
            {
                HoldState[0] = true;
                dice1.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                HoldState[0] = false;
                dice1.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void holdDice2(object sender, EventArgs e)
        {
            if(HoldState[1]==false)
            {
                HoldState[1] = true;
                dice2.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                HoldState[1] = false;
                dice2.BorderStyle = BorderStyle.FixedSingle;
            }
            
        }

        private void holdDice3(object sender, EventArgs e)
        {
            if (HoldState[2] == false)
            {
                HoldState[2] = true;
                dice3.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                HoldState[2] = false;
                dice3.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void holdDice4(object sender, EventArgs e)
        {
            if (HoldState[3] == false)
            {
                HoldState[3] = true;
                dice4.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                HoldState[3] = false;
                dice4.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void holdDice5(object sender, EventArgs e)
        {
            if (HoldState[4] == false)
            {
                HoldState[4] = true;
                dice5.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                HoldState[4] = false;
                dice5.BorderStyle = BorderStyle.FixedSingle;
            }
        }
        private void ResetResults()
        {
            for (int i=0; i < diceResults.Length; i++)
            {
                diceResults[i] = 0;
            }
        }
        private void btnPlay(object sender, EventArgs e)
        {
            rollCheck = 0;
            block = false;
            for(int i=0; i < dice.Length; i++)            
                HoldState[i] = false;
            
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
        }
        
        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numOnes(object sender, EventArgs e)
        {
            //if (diceResults)
        }

        private void numTwos(object sender, EventArgs e)
        {

        }

        private void numFours(object sender, EventArgs e)
        {

        }

        private void numFives(object sender, EventArgs e)
        {

        }

        private void numSixes(object sender, EventArgs e)
        {

        }

        private int addDice(int[] numbers)
        {
            int score = (1 * numbers[0]) + (2 * numbers[1]) + (3 * numbers[2]) +
                            (4 * numbers[3]) + (5 * numbers[4]) + (6 * numbers[5]);
            threeKindBtn.Text = Convert.ToString(score);
            return 0;
        }
        private void threeOfKind(object sender, EventArgs e)
        {            
            if (threeKindBtn.Text == "" && rollCheck != 0 && block == false)
            {              
                for (int i = 0; i < dice.Length; i++)
                {
                    if (diceResults[i] == 3 || diceResults[i] == 4 || diceResults[i] == 5)
                    {
                        addDice(diceResults);
                        break;
                    }         
                    else
                        threeKindBtn.Text = "0";
                }
            }
            rollCheck = 0;
            block = true;
        }

        private void fourOfKind(object sender, EventArgs e)
        {
            if (fourKindBtn.Text == "" && rollCheck != 0 && block == false)
            {

                for (int i = 0; i < dice.Length; i++)
                {
                    if (diceResults[i] == 4 || diceResults[i] == 5)
                    {
                        addDice(diceResults);
                        break;
                    }
                    else
                        fourKindBtn.Text = "0";
                }
            }
            rollCheck = 0;
            block = true;
        }

        private void fullHouse(object sender, EventArgs e)
        {
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
            }
            rollCheck=0;
            block = true;
        }

        private void largeStraight(object sender, EventArgs e)
        {
            rollCheck = 0;
        }

        private void yahtzee(object sender, EventArgs e)
        {
            if(yahtzeeBtn.Text == "" && rollCheck != 0 && block == false)
            {
                for (int i = 0; i < diceResults.Length; i++)
                {
                    if (diceResults[i] == 5)
                    {
                        yahtzeeBtn.Text = "50";
                        break;
                    }
                    else
                        yahtzeeBtn.Text = "0";
                }
            }
            rollCheck = 0;
            block = true;

        }

        private void chance(object sender, EventArgs e)
        {
            block = true;
        }
        
        private void score(object sender, EventArgs e)
        {

        }

        private void newGame(object sender, EventArgs e)
        {

        }

        private void sectionBonus(object sender, EventArgs e)
        {

        }

        
    }
}
