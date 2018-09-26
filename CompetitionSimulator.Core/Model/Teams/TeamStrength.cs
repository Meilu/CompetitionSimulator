using System;

namespace CompetitionSimulator.Core.Model.Teams
{
    public class TeamStrength
    {
        internal TeamStrength(int value)
        {
            if(value < 30 || value > 99)
                throw new ArgumentException("Strength exceeds boundaries.");
            Value = value;
        }

        public int Value { get; }
    }
}