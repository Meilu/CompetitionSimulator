using System;
using System.Collections.Generic;
using System.Text;
using CompetitionSimulator.Core.Model.Matches;

namespace CompetitionSimulator.Core.Model.Competitions
{
    public class Fixture
    {
        public int Id { get; }
        public List<Match> Matches { get; }

        internal Fixture(int id, List<Match> matches)
        {
            Id = id;
            Matches = matches;
        }

        public String Summary
        {
            get
            {
                var summaryBuilder = new StringBuilder();

                summaryBuilder.AppendLine($"Summary for matchday {Id + 1}:");

                foreach (var match in Matches)
                {
                    summaryBuilder.AppendLine(String.Format("{0," + ((20 + match.Description.Length) / 2).ToString() + "}", match.Description));
                    summaryBuilder.AppendLine(String.Format("{0," + ((20 + match.MatchResult.Length) / 2).ToString() + "}", match.MatchResult));
                    summaryBuilder.AppendLine();
                }

                return summaryBuilder.ToString();
            }
        }
    }
}