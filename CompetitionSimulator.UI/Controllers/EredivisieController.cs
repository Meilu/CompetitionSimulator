using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompetitionSimulator.Core.Model;
using CompetitionSimulator.Core.Model.Competitions;
using CompetitionSimulator.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionSimulator.UI.Controllers
{
    public class EredivisieController : Controller
    {
        private readonly IMapper _mapper;

        public EredivisieController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Competition comp = new Competition(new EredevisieConfig());            

            var competitionViewModel = _mapper.Map<CompetitionViewModel>(comp);

            return View(competitionViewModel);
        }
    }
}