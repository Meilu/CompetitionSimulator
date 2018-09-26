using AutoMapper;
using CompetitionSimulator.Core.Model.Competitions;
using CompetitionSimulator.UI.ViewModel;

namespace CompetitionSimulator.UI.Configuration.AutomapperProfiles
{
    public class CompetitionMappingProfile : Profile
    {
        public CompetitionMappingProfile()
        {
            CreateMap<Competition, CompetitionViewModel>();
        }
    }
}