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
    public partial class RulesPage : Form
    {
        private bool _isPage2Open = false;
        private bool _userBlock = false;
        private bool _isPage3Open = false;
        public RulesPage()
        {
            InitializeComponent();
        }
        private void RulesPage_Load(object sender, EventArgs e)
        {

        }       
        //method to go to next page
        private void GoToNextPage(object sender, EventArgs e)
        {
            if (_isPage2Open == false)
            {
                timer1.Start();
                _userBlock = true;
                Page1Dot.BackColor = Color.Gray;
                Page2Dot.BackColor = Color.White;
            }
            else if (_isPage3Open == false)
            {
                timer2.Start();
                _userBlock = true;
                Page2Dot.BackColor = Color.Gray;
                Page3Dot.BackColor = Color.White;
            }
        }
        //method to go to previous page
        private void GoToPreviousPage(object sender, EventArgs e)
        {
            if (_userBlock == true && _isPage3Open == true)
            {
                timer2.Start();
                _userBlock = false;
                Page2Dot.BackColor = Color.White;
                Page3Dot.BackColor = Color.Gray;
            } else if(_userBlock == true && _isPage2Open == true)
            {
                timer1.Start();
                _userBlock = false;
                Page2Dot.BackColor = Color.Gray;
                Page1Dot.BackColor = Color.White;
            }
        }
        //timer for next pages
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isPage2Open)
            {
                page2.Height = 0;
                timer1.Stop();
                _isPage2Open = false;
            }
            else if (!_isPage2Open)
            {
                page2.Height = 550;
                timer1.Stop();
                _isPage2Open = true;
            }
        }
        //timer for next pages
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_isPage3Open)
            {
                page3.Height = 0;
                timer2.Stop();
                _isPage3Open = false;
                _isPage2Open = true;
                _userBlock = true;
            }
            else if (!_isPage3Open)
            {
                page3.Height = 550;
                timer2.Stop();
                _isPage3Open = true;
            }
        }
    }
}
