namespace Endurance.Data.Trial.Models
{
    using System;

    using Resources.Endurance.Enums;

    public class TrialRoundPerformance : TrialRound
    {
        public DateTime? StartedAtTime { get; set; }

        public DateTime? FinishedAtTime { get; set; }

        public DateTime? VetGateEntryDeadlineTime { get; set; }

        public VetGateStatus FirstVetGateEntryStatus { get; set; }

        public VetGateStatus SecondVetGateEntryStatus { get; set; }

        public DateTime? VetGateEntryTime { get; set; }

        public float AvarageSpeed { get; set; }

        public int CompetitorId { get; set; }

        public TrialCompetitor Competitor { get; set; }
    }
}
