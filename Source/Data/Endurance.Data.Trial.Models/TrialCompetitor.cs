namespace Endurance.Data.Trial.Models
{
    using System.Collections.Generic;
    using global::Data.Common.Models;

    public class TrialCompetitor : BaseCompetitor
    {
        public int RiderId { get; set; }

        public TrialRider Rider { get; set; }

        public int HorseId { get; set; }

        public TrialHorse Horse { get; set; }

        public int TrialId { get; set; }

        public Trial Trial { get; set; }

        public IList<TrialRoundPerformance> Performances { get; set; }
    }
}
