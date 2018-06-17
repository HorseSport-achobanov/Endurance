namespace Endurance.Web.Trial.ViewModels.Trial
{
    using System.Collections.Generic;
    using Common.Mapping;
    using Data.Trial.Models;
    using global::Data.Common;

    public class TrialCompetitorViewModel : IMapFrom<TrialCompetitor>
    {
        public int Number { get; set; }

        public BaseRider Rider { get; set; }

        public BaseHorse Horse { get; set; }

        public IList<TrialRoundPerformance> Performances { get; set; }

        public IList<float> TotalAvarageSpeedForEachRound { get; set; }
    }
}
