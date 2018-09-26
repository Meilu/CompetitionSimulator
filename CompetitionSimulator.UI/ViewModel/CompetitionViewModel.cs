using System.Collections.Generic;

namespace CompetitionSimulator.UI.ViewModel
{
    public class CompetitionViewModel
    {
        public FixtureScheduleViewModel FixtureSchedule { get; private set; }

        public TableViewModel Table { get; private set; }

        public List<CompetitionRuleViewModel> Rules { get; private set; }
    }
}