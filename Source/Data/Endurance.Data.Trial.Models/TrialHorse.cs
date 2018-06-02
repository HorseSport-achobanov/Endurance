namespace Endurance.Data.Trial.Models
{
    using System.Collections.Generic;

    using global::Data.Common;

    public class TrialHorse : BaseHorse
    {
        public ICollection<TrialCompetitor> Competitors { get; set; }
    }
}
