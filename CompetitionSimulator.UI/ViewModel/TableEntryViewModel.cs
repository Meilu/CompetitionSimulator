using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompetitionSimulator.UI.ViewModel
{
    public class TableEntryViewModel
    {
        [Display(Name ="Team")]
        public String Team { get; private set; }

        [Display(Name = "Gespeeld")]
        public int Played { get; private set; }

        [Display(Name = "Winst")]
        public int Won { get; private set; }

        [Display(Name = "Gelijk")]
        public int Drawn { get; private set; }

        [Display(Name = "Verlies")]
        public int Lost { get; private set; }

        [Display(Name = "GV")]
        public int GoalsFor { get; private set; }

        [Display(Name = "GT")]
        public int GoalsAgainst { get; private set; }

        [Display(Name = "GD")]
        public int GoalDifference { get; private set; }

        [Display(Name = "Punten")]
        public int Points { get; private set; }

        [Display(Name = "")]
        public int Reward { get; private set; }
    }
}