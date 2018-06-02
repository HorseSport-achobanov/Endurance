namespace Endurance.Data.Trial.Models
{
    using System.Collections.Generic;

    using global::Data.Common;

    public class TrialHorse : BaseHorse
    {
        public IList<TrialCompetitor> Competitors { get; set; }
    }
}
