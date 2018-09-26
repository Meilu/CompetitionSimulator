using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CompetitionSimulator.Core.Model.Teams
{
    [DebuggerDisplay("{Name}")]
    public class Team
    {
        public static List<Team> BuildTeamList(Dictionary<String, int> input, int? amountToRandomPick = null)
        {
            var result = new List<Team>();
  
            if (amountToRandomPick == null)
            {
                foreach (var keyValuePair in input)
                {
                    result.Add(new Team(keyValuePair.Key, new TeamStrength(keyValuePair.Value)));
                }
            }
            else
            {
                if(amountToRandomPick > input.Count)
                    throw new ArgumentException("Amount to pick exceeds available teams.");

                List<int> picked = new List<int>();

                var id = -1;
                for (int i = 0; i < amountToRandomPick; i++)
                {
                    while (true)
                    {
                        id = Math.RandomGenerator.Next(input.Count);
                        if (!picked.Contains(id))
                            break;
                    }

                    picked.Add(id);
                    
                    result.Add(new Team(input.ElementAt(id).Key, new TeamStrength(input.ElementAt(id).Value)));
                }
            }

            return result;
        }

        public Team(string name, TeamStrength teamStrength)
        {
            Name = name;
            TeamStrength = teamStrength;
        }
        public string Name { get; set; }
        public TeamStrength TeamStrength { get; set; }

        public override bool Equals(object obj)
        {
            var team = obj as Team;
            return team != null &&
                   Name == team.Name &&
                   EqualityComparer<TeamStrength>.Default.Equals(TeamStrength, team.TeamStrength);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, TeamStrength);
        }

        public static bool operator ==(Team team1, Team team2)
        {
            return EqualityComparer<Team>.Default.Equals(team1, team2);
        }

        public static bool operator !=(Team team1, Team team2)
        {
            return !(team1 == team2);
        }
    }
}
