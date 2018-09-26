using System;
using System.Collections.Generic;
using System.Linq;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Competitions
{
    public class CompetitionConfig
    {
        public List<CompetitionRule> Rules { get; }
        public List<Team> Teams { get; }

        public int AmountOfChallengesPerMatch { get; }
        
        public CompetitionConfig(List<Team> teams, List<CompetitionRule> rules, int amountOfChallengesPerMatch) 
        {

            if(rules.Max(r => r.Position > teams.Count))
                throw new ArgumentException("CompetitionConfiguration invalid: more rules than teams.");
            Rules = rules;
            Teams = teams;
            AmountOfChallengesPerMatch = amountOfChallengesPerMatch;
        }
    }
}