using System;
using System.Drawing;

namespace CompetitionSimulator.UI.ViewModel
{
    public class CompetitionRuleViewModel
    {
        public int Position { get; private set; }
        public String Consequence { get; private set; }

        public Color TableRowColor { get; private set; }

        public Color TableTextColor { get; private set; }
    }
}