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
        private bool isPage2Open = false;
        private bool userBlock = false;
        private bool isPage3Open = false;
        public RulesPage()
        {
            InitializeComponent();
        }

        private void RulesPage_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isPage2Open)
            {
                page2.Height = 0;
                timer1.Stop();
                isPage2Open = false;
            }
            else if (!isPage2Open)
            {
                page2.Height = 550;
                timer1.Stop();
                isPage2Open = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(isPage3Open)
            {
                page3.Height = 0;
                timer2.Stop();
                isPage3Open = false;
                isPage2Open = true;
                userBlock = true;
            }
            else if (!isPage3Open)
            {
                page3.Height = 550;
                timer2.Stop();
                isPage3Open = true;
            }
        }

        private void GoToNextPage(object sender, EventArgs e)
        {
            if (isPage2Open == false)
            {
                timer1.Start();
                userBlock = true;
                Page1Dot.BackColor = Color.Gray;
                Page2Dot.BackColor = Color.White;
            }
            else if (isPage3Open == false)
            {
                timer2.Start();
                userBlock = true;
                Page2Dot.BackColor = Color.Gray;
                Page3Dot.BackColor = Color.White;
            }
        }

        private void GoToPreviousPage(object sender, EventArgs e)
        {
            if (userBlock == true && isPage3Open == true)
            {
                timer2.Start();
                userBlock = false;
                Page2Dot.BackColor = Color.White;
                Page3Dot.BackColor = Color.Gray;

            } else if(userBlock == true && isPage2Open == true)
            {
                timer1.Start();
                userBlock = false;
                Page2Dot.BackColor = Color.Gray;
                Page1Dot.BackColor = Color.White;
            }
        }
    }
}
