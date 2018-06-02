namespace Endurance.Data.Trial.Models
{
    using System.Collections.Generic;

    using global::Data.Common;

    public class TrialCompetitor : BaseCompetitor
    {
        public override BaseRider Rider { get; set; }

        public override BaseHorse Horse { get; set; }

        public IList<TrialRoundPerformance> Performances { get; set; }
    }
}
