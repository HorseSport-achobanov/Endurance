namespace Endurance.Data.Trial.Models
{
    using System.Collections.Generic;

    using global::Data.Common;

    public class TrialRider : BaseRider
    {
        public IList<TrialCompetitor> Competitors { get; set; }
    }
}
