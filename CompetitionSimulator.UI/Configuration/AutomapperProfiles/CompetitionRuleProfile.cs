using AutoMapper;
using CompetitionSimulator.Core.Model.Competitions;
using CompetitionSimulator.UI.ViewModel;

namespace CompetitionSimulator.UI.Configuration.AutomapperProfiles
{
    public class CompetitionRuleProfile : Profile
    {
        public CompetitionRuleProfile()
        {
            CreateMap<CompetitionRule, CompetitionRuleViewModel>();
        }
    }
}