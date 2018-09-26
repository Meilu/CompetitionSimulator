using System.Diagnostics;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Matches
{
    [DebuggerDisplay("{Description}")]
    public class Match
    {
        internal Match(Team homeTeam, Team awayTeam, int amountOfChallenges)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;

            Statistics = new MatchStatistics(homeTeam, awayTeam, amountOfChallenges);
        }

        public Team HomeTeam { get; }
        public Team AwayTeam { get; }        

        public MatchStatistics Statistics { get; }

        public Team Victor
        {
            get
            {
                if (IsDraw) return null;
                else return Statistics.HomeGoals > Statistics.AwayGoals ? HomeTeam : AwayTeam;
            }
        }

        public bool IsDraw => Statistics.HomeGoals == Statistics.AwayGoals;

        public string Description => $"{(Victor == HomeTeam ? $"<b>{HomeTeam.Name}</b>" : HomeTeam.Name)} vs {(Victor == AwayTeam ? $"<b>{AwayTeam.Name}</b>" : AwayTeam.Name)}";
        public string MatchResult => $"{Statistics.HomeGoals}-{Statistics.AwayGoals}";
    }
}