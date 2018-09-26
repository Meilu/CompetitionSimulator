using System;
using System.Drawing;

namespace CompetitionSimulator.Core.Model.Competitions
{
    public class CompetitionRule
    {
        public CompetitionRule(int position, string consequence,Color? tableRowColor = null, Color? tableTextColor = null)
        {
            TableRowColor = tableRowColor ?? Color.White;
            TableTextColor = tableTextColor ?? Color.Black;
            
            Position = position;
            Consequence = consequence;
        }

        public int Position { get; }
        public String Consequence { get; }

        public Color TableRowColor { get; }

        public Color TableTextColor { get; }

    }
}