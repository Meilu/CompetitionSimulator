using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompetitionSimulator.Core.Model.Matches;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model.Competitions
{
    public class Table
    {
        private readonly List<CompetitionRule> _rules;

        public List<TableStatistics> Statistics { get; private set; }
        internal Table(CompetitionConfig config, List<Match> matches)
        {
            _rules = config.Rules;
            var statistics = new List<TableStatistics>();

            foreach (var team in config.Teams)
            {
                var matchesForTeam = matches.Where(m => m.HomeTeam == team || m.AwayTeam == team).ToList();
                statistics.Add(new TableStatistics(team, matchesForTeam));
            }

            SortStatistics(statistics, matches);

            if (Statistics.Count != statistics.Count)
                System.Diagnostics.Debugger.Break();
        
        }

        private void SortStatistics(List<TableStatistics> statistics, List<Match> matches)
        {
            Statistics = new List<TableStatistics>();

            foreach (var tableStatistic in statistics)
            {
                if (Statistics.Count == 0)
                {
                    Statistics.Add(tableStatistic);
                    continue;
                }

                for (var i = 0; i < Statistics.Count; i++)
                {
                    if (tableStatistic.Points > Statistics[i].Points)
                    {
                        Statistics.Insert(i, tableStatistic);
                        break;
                    }

                    if (tableStatistic.Points == Statistics[i].Points)
                    {
                        if (tableStatistic.GoalDifference > Statistics[i].GoalDifference)
                        {
                            Statistics.Insert(i, tableStatistic);
                            break;
                        }

                        if (tableStatistic.GoalDifference == Statistics[i].GoalDifference)
                        {
                            if (tableStatistic.GoalsFor > Statistics[i].GoalsFor)
                            {
                                Statistics.Insert(i, tableStatistic);
                                break;
                            }
                            if (tableStatistic.GoalsAgainst < Statistics[i].GoalsAgainst)
                            {
                                Statistics.Insert(i, tableStatistic);
                                break;
                            }

                            // Onderling resultaat
                            var homeMatch = matches.Single(m =>
                                m.HomeTeam == tableStatistic.Team && m.AwayTeam == Statistics[i].Team);

                            var awayMatch = matches.Single(m =>
                                m.HomeTeam == tableStatistic.Team && m.AwayTeam == Statistics[i].Team);

                            // Gelijkspel
                            if (homeMatch.IsDraw && awayMatch.IsDraw)
                            {
                                var homeGoals = homeMatch.Statistics.HomeGoals + awayMatch.Statistics.AwayGoals;
                                var awayGoals = homeMatch.Statistics.AwayGoals + awayMatch.Statistics.HomeGoals;

                                if(homeGoals == awayGoals)
                                {
                                    // Kies op naam
                                    List<Team> teams = new List<Team>() { tableStatistic.Team, Statistics[i].Team };
                                    var winningTeam = teams.OrderBy(t => t.Name).First();

                                    if (tableStatistic.Team == winningTeam)
                                    {
                                        Statistics.Insert(i, tableStatistic);
                                        break;
                                    }
                                    else
                                    {
                                        Statistics.Insert(i + 1, tableStatistic);
                                        break;
                                    }
                                }

                                if(homeGoals > awayGoals)
                                {
                                    Statistics.Insert(i, tableStatistic);
                                    break;
                                }
                                else
                                {
                                    Statistics.Insert(i + 1, tableStatistic);
                                    break;
                                }

                            }

                            var homePoints = 0;
                            var awayPoints = 0;

                            if (homeMatch.Victor == tableStatistic.Team) homePoints += 3; else awayPoints += 3;
                            if (awayMatch.Victor == tableStatistic.Team) homePoints += 3; else awayPoints += 3;

                            if (homeMatch.IsDraw) homePoints ++; awayPoints ++;
                            if (awayMatch.IsDraw) homePoints ++; awayPoints ++;

                            if (homePoints > awayPoints)
                            {
                                Statistics.Insert(i, tableStatistic);
                                break;
                            }
                            else
                            {
                                Statistics.Insert(i + 1, tableStatistic);
                                break;
                            }
                        }

                        Statistics.Insert(i + 1, tableStatistic);
                        break;
                    }

                    if (i == Statistics.Count - 1)
                    {
                        Statistics.Add(tableStatistic);
                        break;
                    }
                }
            }
        }

        public String GetTableSummary()
        {
            var summaryBuilder = new StringBuilder();

            summaryBuilder.AppendLine($"{"Pos",5}|{"Team",20}|{"Played",7}|{"Won",4}|{"Lost",5}|{"Drawn",6}|{"GF",3}|{"GA",3}|{"GD",3}|{"Points",7}|{"",25}");

            for(int i = 0; i < Statistics.Count; i++)
            {
                var stat = Statistics[i];
                var reward = _rules.SingleOrDefault(r => r.Position == i + 1)?.Consequence;

                summaryBuilder.AppendLine($"{i+1,5}|{stat.Team.Name,20}|{stat.Played,7}|{stat.Won,4}|{stat.Lost,5}|{stat.Drawn,6}|{stat.GoalsFor,3}|{stat.GoalsAgainst,3}|{stat.GoalDifference,3}|{stat.Points,7}|{reward,-25}");
            }

            return summaryBuilder.ToString();

        }


    }
}