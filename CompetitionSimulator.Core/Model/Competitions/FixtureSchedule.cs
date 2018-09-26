using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CompetitionSimulator.Core.Model.Matches;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Competitions
{
    public class FixtureSchedule
    {
        public List<Fixture> Fixtures { get; }

        internal FixtureSchedule(List<Team> teams, List<Match> matches)
        {
            var fixtureCount = matches.Count / (teams.Count / 2);
            var matchesPerFixture = matches.Count / fixtureCount;

            Fixtures = new List<Fixture>();

            teams.Shuffle();

            var scheduledMatches = matches.Select(m => new PickedMatchForSchedule(m)).ToList();

            for (int i = 0; i < fixtureCount; i++)
            {
                var pickedTeams = new List<Team>();
                var matchesInMatchDay = new List<Match>();
                var availableMatches = scheduledMatches.Where(m => !m.Picked).ToList();

                ScheduleMatches(teams, pickedTeams, availableMatches, matchesInMatchDay, scheduledMatches);

                Fixtures.Add(new Fixture(i, matchesInMatchDay));
            }

            var ignored = scheduledMatches.Where(m => !m.Picked).ToList();

            while (ignored.Count != 0)
            {
                var pickedTeams = new List<Team>();
                var matchesInMatchDay = new List<Match>();
                var availableMatches = scheduledMatches.Where(m => !m.Picked).ToList();

                ScheduleMatches(teams, pickedTeams, availableMatches, matchesInMatchDay, scheduledMatches);

                Fixtures.Add(new Fixture(Fixtures.Count + 1, matchesInMatchDay));

                ignored = scheduledMatches.Where(m => !m.Picked).ToList();
            }

            Fixtures.Shuffle();
        }

        private static void ScheduleMatches(List<Team> teams, List<Team> pickedTeams, List<PickedMatchForSchedule> availableMatches, List<Match> matchesInMatchDay,
            List<PickedMatchForSchedule> scheduledMatches)
        {
            foreach (var team in teams)
            {
                if (pickedTeams.Contains(team))
                    continue;

                var matchToSchedule =
                    availableMatches.FirstOrDefault(m =>
                        (m.Match.HomeTeam == team && !pickedTeams.Contains(m.Match.AwayTeam))
                        ||
                        (m.Match.AwayTeam == team && !pickedTeams.Contains(m.Match.HomeTeam))
                    );

                if (matchToSchedule == null)
                    continue;

                matchesInMatchDay.Add(matchToSchedule.Match);

                pickedTeams.AddRange(new[] {matchToSchedule.Match.HomeTeam, matchToSchedule.Match.AwayTeam});

                scheduledMatches.Single(m => m.Match == matchToSchedule.Match).Picked = true;
            }
        }

        [DebuggerDisplay("{Match.Description}")]
        private class PickedMatchForSchedule
        {
            public PickedMatchForSchedule(Match match)
            {
                Match = match;
                Picked = false;
            }

            public Match Match { get; }

            public bool Picked { get; set; }
        }
    }
}