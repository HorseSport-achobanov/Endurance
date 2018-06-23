namespace Endurance.Data.Trial.Models
{
    using System.Collections.Generic;
    using global::Data.Common;
    using global::Data.Common.Models;

    public class TrialCompetitor : BaseCompetitor
    {
        public TrialRider Rider { get; set; }

        public TrialHorse Horse { get; set; }

        public IList<TrialRoundPerformance> Performances { get; set; }
    }
}
