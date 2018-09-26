using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Matches
{
    public class Goal
    {
        internal Goal(Team scoringTeam)
        {
            ScoringTeam = scoringTeam;
        }

        public Team ScoringTeam { get; }
    }
}