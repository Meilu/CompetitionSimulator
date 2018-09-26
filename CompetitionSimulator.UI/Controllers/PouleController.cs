using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompetitionSimulator.Core.Model;
using CompetitionSimulator.Core.Model.Competitions;
using CompetitionSimulator.Core.Model.Teams;
using CompetitionSimulator.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionSimulator.UI.Controllers
{
    public class PouleController : Controller
    {
        private readonly IMapper _mapper;

        public PouleController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var pouleTeams = Team.BuildTeamList(EredevisieConfig.EredivisieTeams, 5);

            var pouleRules = new List<CompetitionRule>()
            {
                new CompetitionRule(1, "Winner - Knockout fase (Seeded)", Color.Chartreuse, Color.Black ),
                new CompetitionRule(2, "Runnerup - Knockout fase (Non-Seeded)",  Color.CornflowerBlue, Color.Black ),
            };

            var fantasyCompetitionConfig = new CompetitionConfig(
                pouleTeams,
                pouleRules,
                30);

            var pouleCompetition = new Competition(fantasyCompetitionConfig);

            var competitionViewModel = _mapper.Map<CompetitionViewModel>(pouleCompetition);

            return View(competitionViewModel);
        }
    }
}