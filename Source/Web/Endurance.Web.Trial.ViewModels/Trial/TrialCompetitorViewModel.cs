namespace Endurance.Web.Trial.ViewModels.Trial
{
    using System.Collections.Generic;
    using Common.Mapping;
    using Data.Trial.Models;
    using global::Data.Common;

    public class TrialCompetitorViewModel : IMapFrom<TrialCompetitor>
    {
        public TrialCompetitorViewModel()
        {
            CurrentAvarageSpeedAtRounds = new List<float>();
        }

        public int Number { get; set; }

        public TrialRider Rider { get; set; }

        public TrialHorse Horse { get; set; }

        public IList<TrialRoundPerformanceViewModel> Performances { get; set; }

        public IList<float> CurrentAvarageSpeedAtRounds { get; set; }
    }
}
