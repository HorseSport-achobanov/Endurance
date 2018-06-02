namespace Endurance.Data.Trial.Models
{
    using System;
    using System.Collections.Generic;

    using global::Data.Common;
    using global::Data.Common.Contracts;

    public class TrialCompetitor : IIdentifiable<int>, IAuditInfo
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public Rider Rider { get; set; }

        public Horse Horse { get; set; }

        public ICollection<TrialRoundPerformance> Performances { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
