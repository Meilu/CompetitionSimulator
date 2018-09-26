using AutoMapper;
using CompetitionSimulator.Core.Model.Matches;
using CompetitionSimulator.UI.ViewModel;

namespace CompetitionSimulator.UI.Configuration.AutomapperProfiles
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<Match, MatchViewModel>()
                .ForMember(d => d.AwayGoals, o => o.MapFrom(s => s.Statistics.AwayGoals))
                .ForMember(d => d.HomeGoals, o => o.MapFrom(s => s.Statistics.HomeGoals));
        }
    }
}