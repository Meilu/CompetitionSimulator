namespace CompetitionSimulator.UI.ViewModel
{
    public class MatchViewModel
    {
        public TeamViewModel HomeTeam { get; private set; }
        public TeamViewModel AwayTeam { get; private set; }

        public TeamViewModel Victor { get; private set; }

        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        
        public bool IsDraw { get; private set; }
        public string Description { get; private set; }
        public string MatchResult { get; private set; }
    }
}