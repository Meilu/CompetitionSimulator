using System;
using System.Collections.Generic;

namespace CompetitionSimulator.UI.ViewModel
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public int TeamStrength { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as TeamViewModel;
            return model != null &&
                   Name == model.Name &&
                   TeamStrength == model.TeamStrength;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, TeamStrength);
        }

        public static bool operator ==(TeamViewModel model1, TeamViewModel model2)
        {
            return EqualityComparer<TeamViewModel>.Default.Equals(model1, model2);
        }

        public static bool operator !=(TeamViewModel model1, TeamViewModel model2)
        {
            return !(model1 == model2);
        }
    }
}