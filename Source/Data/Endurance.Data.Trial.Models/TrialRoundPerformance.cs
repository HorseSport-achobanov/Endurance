namespace Endurance.Data.Trial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using global::Data.Common.Contracts;
    using Resources.Endurance.Enums;

    public class TrialRoundPerformance : TrialRound, IAuditInfo
    {
        public DateTime StartedAtTime { get; set; }

        public DateTime FinishedAtTime { get; set; }

        public DateTime EnteredAtVetGateTime { get; set; }

        public VetGateStatus VetGateStatus { get; set; }

        public TimeSpan RestTimeSpan { get; set; } 

        public float AvarageSpeed { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
