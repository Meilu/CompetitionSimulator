using System;
using System.Collections.Generic;
using System.Linq;
using CompetitionSimulator.Core.Model.Matches;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Competitions
{
    public class TableStatistics
    {
        internal TableStatistics(Team team, List<Match> matches)
        {
            if (matches.Any(m => m.HomeTeam != team && m.AwayTeam != team))
                throw new ArgumentException("Invalid tablestatistics input: team was not part of match");

            Team = team;

            Played = matches.Count();

            Won = matches.Count(m => m.Victor == team && !m.IsDraw);

            Lost = matches.Count(m => m.Victor != team && !m.IsDraw);

            Drawn = matches.Count(m => m.IsDraw);

            foreach (var m in matches.Where(m => m.HomeTeam == team))
            {
                GoalsFor += m.Statistics.HomeGoals;
                GoalsAgainst += m.Statistics.AwayGoals;
            }

            foreach (var m in matches.Where(m => m.AwayTeam == team))
            {
                GoalsFor += m.Statistics.AwayGoals;
                GoalsAgainst += m.Statistics.HomeGoals;
            }
        }

        public Team Team { get; }
        public int Played { get; }

        public int Won { get; }

        public int Drawn { get; }

        public int Lost { get; }

        public int GoalsFor { get; }

        public int GoalsAgainst { get; }

        public int GoalDifference => GoalsFor - GoalsAgainst;

        public int Points => (Won * 3) + (Drawn * 1);
    }
}