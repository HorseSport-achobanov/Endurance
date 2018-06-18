namespace Endurance.Data.Trial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using global::Data.Common.Contracts;

    public class Trial : IIdentifiable<int>, IAuditInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int NumberOfRounds { get; set; }

        public IList<TrialRound> Rounds { get; set; }

        public IList<TrialCompetitor> Competitors { get; set; }

        public DateTime StartTime { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
