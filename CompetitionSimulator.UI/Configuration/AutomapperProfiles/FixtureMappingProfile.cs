using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompetitionSimulator.Core.Model.Competitions;
using CompetitionSimulator.UI.ViewModel;

namespace CompetitionSimulator.UI.Configuration.AutomapperProfiles
{
    public class FixtureMappingProfile : Profile
    {
        public FixtureMappingProfile()
        {
            CreateMap<FixtureSchedule, FixtureScheduleViewModel>()
                .ForMember(d => d.Fixtures, o => o.MapFrom(s => s.Fixtures));

            CreateMap<Fixture, FixtureViewModel>()
                .ForMember(d => d.Matches, o => o.MapFrom(s => s.Matches));
        }
    }
}
