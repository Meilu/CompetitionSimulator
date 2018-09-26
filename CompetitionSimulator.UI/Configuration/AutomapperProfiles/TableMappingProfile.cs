using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompetitionSimulator.Core.Model.Competitions;
using CompetitionSimulator.UI.ViewModel;

namespace CompetitionSimulator.UI.Configuration.AutomapperProfiles
{
    public class TableMappingProfile : Profile
    {
        public TableMappingProfile()
        {
            CreateMap<Table, TableViewModel>()
                .ForMember(t => t.TableEntries, o => o.MapFrom(s => s.Statistics));

            CreateMap<TableStatistics, TableEntryViewModel>()
                .ForMember(d => d.Team, o => o.MapFrom(s => s.Team.Name));
        }
    }
}
