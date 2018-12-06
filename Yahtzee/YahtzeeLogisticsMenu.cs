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
    class YahtzeeLogisticsMenu
    {
        Image[] _diceImages = new Image[7];
        int[] _dice;
        int[] _diceResults;
        int _rollCheck = 0;
        bool _blockUser = false;
        int _prevScore = 0;
        int _bonusScore = 0;
        bool _onlyOnceBonus = false;
        bool _isMenuPanelOpen = false;
        bool[] _holdState = new bool[5];

        public YahtzeeLogisticsMenu(string type)
        {
            if(type=="Rules")
            {
                ShowRules dialogBox = new ShowRules();
                dialogBox.Show();
             
            }
        }
        public YahtzeeLogisticsMenu(bool isMenuPanelOpen, Panel panelDropDownList, Timer timer1)
        {
            if (isMenuPanelOpen)
            {
                panelDropDownList.Height = 0;
                timer1.Stop();
                _isMenuPanelOpen = isMenuPanelOpen = false;
            }
            else if (!isMenuPanelOpen)
            {
                panelDropDownList.Height = 110;
                timer1.Stop();
                _isMenuPanelOpen = isMenuPanelOpen = true;              
            }
        }
        public void setVariables(int[] dice, int[] diceResults, bool[] HoldState, int rollCheck, bool blockUser, int prevScore,
                int bonusScore, bool onlyOnceBonus)
        {

            _dice = dice;
            _diceResults = diceResults;
            _rollCheck = rollCheck;
            _blockUser = blockUser;
            _prevScore = prevScore;
            _bonusScore = bonusScore;
            _onlyOnceBonus = onlyOnceBonus;
            for (int i = 0; i < dice.Length; i++)
                _holdState[i] = HoldState[i];
        }
        public int RollCheck
        {
            get { return _rollCheck;  }
            set { _rollCheck = value;  }
        }
        public int[] Dice
        {
            get { return _dice; }
            set { _dice = value; }
        }
        public int[] DiceResults
        {
            get { return _diceResults; }
            set { _diceResults = value; }
        }
        public bool BlockUser
        {
            get { return _blockUser; }
            set { _blockUser = value; }
        }
        public int PrevScore
        {
            get { return _prevScore; }
            set { _prevScore = value; }
        }
        public int BonusScore
        {
            get { return _bonusScore; }
            set { _bonusScore = value; }
        }
        public bool OnlyOnceBonus
        {
            get { return _onlyOnceBonus; }
            set { _onlyOnceBonus = value; }
        }
        public bool[] HoldState
        {
            get { return _holdState; }
            set { _holdState = value; }
        }
        public bool IsMenuPanelOpen
        {
            get { return _isMenuPanelOpen; }
            set { _isMenuPanelOpen = value; }
        }
    }
}
