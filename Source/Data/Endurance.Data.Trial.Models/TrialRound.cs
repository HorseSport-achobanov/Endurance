namespace Endurance.Data.Trial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using global::Data.Common.Contracts;

    [Table("Rounds")]
    public class TrialRound : IIdentifiable<int>, IAuditInfo
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public DateTime? StartedAtTime { get; set; }

        public double LengthInKilometers { get; set; }
        
        public double VetGateEntryInMinutes { get; set; }

        public double MaxRestTimeInMinutes { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
