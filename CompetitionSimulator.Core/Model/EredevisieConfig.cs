using System.Collections.Generic;
using System.Drawing;
using CompetitionSimulator.Core.Model.Competitions;
using CompetitionSimulator.Core.Model.Teams;

namespace CompetitionSimulator.Core.Model
{
    public class EredevisieConfig : CompetitionConfig
    {
        public static Dictionary<string, int> EredivisieTeams = new Dictionary<string, int>()
        {
            {"Ajax", 92},
            {"PSV", 90},
            {"Feyenoord", 87},
            {"AZ", 85},
            {"FC Utrecht", 75},
            {"Heracles Almelo", 70},
            {"Vitesse", 72},
            {"Excelsior", 69},
            {"VVV Venlo", 67},
            {"ADO Den Haag", 65},
            {"FC Groningen", 65},
            {"SC Heerenveen", 65},
            {"PEC Zwolle", 63},
            {"Willem II", 60},
            {"De Graafschap", 60},
            {"NAC Breda", 59},
            {"FC Emmen", 55},
            {"Fortuna Sittard", 50}
        };

        public static List<CompetitionRule> EredivisieRules = new List<CompetitionRule>()
        {
            new CompetitionRule(1, "Winner - CL Preliminary (3)", Color.Chartreuse, Color.Black ),
            new CompetitionRule(2, "Runnerup - CL Preliminary (2)", Color.CornflowerBlue, Color.Black ),
            new CompetitionRule(3, "Play-off EL Preliminary (2)", Color.MediumPurple, Color.Black),
            new CompetitionRule(4, "Play-off EL Preliminary (2)", Color.MediumPurple, Color.Black),
            new CompetitionRule(5, "Play-off EL Preliminary (2)", Color.MediumPurple, Color.Black),
            new CompetitionRule(6, "Play-off EL Preliminary (2)", Color.MediumPurple, Color.Black),
            new CompetitionRule(7, "Play-off EL Preliminary (2)", Color.MediumPurple, Color.Black),
            new CompetitionRule(16, "Play-off Relegation", Color.OrangeRed, Color.Azure),
            new CompetitionRule(17, "Play-off Relegation", Color.OrangeRed, Color.Azure),
            new CompetitionRule(18, "Direct Relegation", Color.DarkRed, Color.Azure),
        };

        public EredevisieConfig() : base(Team.BuildTeamList(EredivisieTeams), EredivisieRules, 30)
        {
        }
    }
}
