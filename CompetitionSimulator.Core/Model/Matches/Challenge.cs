using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Matches
{
    internal class Challenge
    {
        public Team Challenger { get; }
        public bool IsGoal { get; }
        internal Challenge(Team attackingTeam, Team defendingTeam)
        {
            Challenger = attackingTeam;

            IsGoal = ResolveChallenge(attackingTeam, defendingTeam) == attackingTeam;
        }

        private Team ResolveChallenge(Team attackingTeam, Team defendingTeam)
        {
            for (int i = 0; i < 5; i++)
            {
                var winner = PickWinner(attackingTeam, defendingTeam);

                if (winner == attackingTeam)
                {
                    continue;
                }

                if (winner == defendingTeam)
                {
                    return defendingTeam;
                }
            }

            return attackingTeam;
        }

        private Team PickWinner(Team teamA, Team teamB)
        {
            var cumulative = teamA.TeamStrength.Value + teamB.TeamStrength.Value;

            var random = Math.RandomGenerator.Next(1, cumulative);

            if (random > teamA.TeamStrength.Value)
                return teamB;
            else return teamA;
        }
    }
}