using System.Collections.Generic;
using System.Linq;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Matches
{
    public class MatchStatistics
    {
        internal MatchStatistics(Team homeTeam, Team awayTeam, int amountOfChallenges)
        {
            Challenges = new List<Challenge>();

            for (int i = 0; i < amountOfChallenges; i++)
            {
                Challenges.Add(new Challenge(homeTeam, awayTeam));
            }

            for (int i = 0; i < amountOfChallenges; i++)
            {
                Challenges.Add(new Challenge(awayTeam, homeTeam));
            }

            Goals = Challenges.Where(c => c.IsGoal).Select(c => new Goal(c.Challenger)).ToList();

            HomeGoals = Goals.Count(g => g.ScoringTeam == homeTeam);

            AwayGoals = Goals.Count(g => g.ScoringTeam == awayTeam);
        }

        internal List<Challenge> Challenges { get; }
        public List<Goal> Goals { get; }

        public int HomeGoals { get; } 
        public int AwayGoals { get; }

    }
}