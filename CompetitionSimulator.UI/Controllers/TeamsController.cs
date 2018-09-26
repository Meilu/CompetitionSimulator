using System.Collections.Generic;
using AutoMapper;
using CompetitionSimulator.Core.Model;
using CompetitionSimulator.Core.Model.Teams;
using CompetitionSimulator.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionSimulator.UI.Controllers
{
    public class TeamsController : Controller
    {
        private IMapper _mapper;

        public TeamsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var teams = _mapper.Map<List<TeamViewModel>>(Team.BuildTeamList(EredevisieConfig.EredivisieTeams));

            return View(teams);
        }
    }
}