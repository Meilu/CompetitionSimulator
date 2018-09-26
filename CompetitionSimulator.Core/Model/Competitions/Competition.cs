using System;
using System.Collections.Generic;
using System.Linq;
using CompetitionSimulator.Core.Model.Matches;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Competitions
{
    public class Competition
    {
        public FixtureSchedule FixtureSchedule { get; }

        public Table Table { get; }

        public List<CompetitionRule> Rules { get; }

        public Competition(CompetitionConfig config)
        {
            if (config.Teams.Count < 4)
                throw new ArgumentException("Competition requires at least 4 teams");

            var matches = new List<Match>();

            foreach (var current in config.Teams)
            {
                foreach (var team in config.Teams)
                {
                    if (current != team)
                        matches.Add(new Match(current, team, config.AmountOfChallengesPerMatch));
                }
            }

            FixtureSchedule = new FixtureSchedule(config.Teams, matches);

            Table = new Table(config, matches);

            Rules = config.Rules;
        }
    }
}

