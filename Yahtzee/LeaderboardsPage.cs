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
    public partial class LeaderboardsPage : Form
    {
        //leaderboard constructor
        public LeaderboardsPage(int gamesPlayed, int bestScore, int bestMinor, int bestMajor, double averageScore, int recordOfYahtze)
        {
            InitializeComponent();
            DisplayText(gamesPlayedLbl,gamesPlayed);
            DisplayText(bestScoreLbl, bestScore);
            DisplayText(bestMinorScoreLbl, bestMinor);
            DisplayText(bestMajorScoreLbl, bestMajor);
            DisplayText(averageScoreLbl, averageScore);
            DisplayText(recordOfYahtzeeLbl, recordOfYahtze);
        }
        private void LeaderboardsPage_Load(object sender, EventArgs e)
        {

        }
        //display each text
        private void DisplayText(Label label, int type)
        {
            label.Text = Convert.ToString(type);
        }
        //method overloading
        private void DisplayText(Label label, double type)
        {
            label.Text = Convert.ToString(Math.Round(type,2));
        }
    }
}
