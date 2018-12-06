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
    public partial class ShowRules : Form
    {
        bool isRulesPanelOpen = false;
        public ShowRules()
        {
            InitializeComponent();
        }
        private void NextRulesBtn(object sender, EventArgs e)
        {
            RulesPage2.Height = 0;
        }

        
    }
}
