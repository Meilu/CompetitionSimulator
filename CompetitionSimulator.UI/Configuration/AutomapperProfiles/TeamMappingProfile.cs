using AutoMapper;
using CompetitionSimulator.Core.Model.Teams;
using CompetitionSimulator.UI.ViewModel;

namespace CompetitionSimulator.UI.Configuration.AutomapperProfiles
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<Team, TeamViewModel>()
                .ForMember(d => d.TeamStrength, o => o.MapFrom(s => s.TeamStrength.Value));
        }
    }
}