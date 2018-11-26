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

            rand = new Random();
        }
        #endregion
        private void btnPlay(object sender, EventArgs e)
        {
            RollDice();
        }

        private void RollDice()
        {
            for (int i = 0; i < dice.Length; i++)
                dice[i] = rand.Next(1, 6 + 1);
            btnDice1.Image = diceImages[]
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

        private void threeOfKind(object sender, EventArgs e)
        {

        }

        private void fourOfKind(object sender, EventArgs e)
        {

        }

        private void fullHouse(object sender, EventArgs e)
        {

        }

        private void smallStraight(object sender, EventArgs e)
        {

        }

        private void largeStraight(object sender, EventArgs e)
        {

        }

        private void yahtzee(object sender, EventArgs e)
        {

        }

        private void chance(object sender, EventArgs e)
        {

        }

        private void btnRull(object sender, EventArgs e)
        {

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
