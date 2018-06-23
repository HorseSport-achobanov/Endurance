namespace Endurance.Web.Trial.ViewModels.Trial
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data.Trial.Models;
    using Resources.Endurance.Enums;

    public class TrialRoundPerformanceViewModel : IMapFrom<TrialRoundPerformance>
    {
        public int Id { get; set; }

        public DateTime? StartedAtTime { get; set; }

        public DateTime? FinishedAtTime { get; set; }

        public DateTime? EnteredAtVetGateTime { get; set; }

        [UIHint("VetGateStatus")]
        public VetGateStatus FirstVetGateEntryStatus { get; set; }

        [UIHint("VetGateStatus")]
        public VetGateStatus SecondVetGateEntryStatus { get; set; }

        public DateTime? VetGateEntryDeadlineTime { get; set; }

        public float AvarageSpeed { get; set; }
    }
}
