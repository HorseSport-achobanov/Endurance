﻿namespace Endurance.Data.Trial.Models
{
    using System;

    using Resources.Endurance.Enums;

    public class TrialRoundPerformance : TrialRound
    {
        public TrialRoundPerformance()
        { 
        }
        
        public TrialRoundPerformance(int competitorId, TrialRound round)
        {
            CompetitorId = competitorId;
            Index = round.Index;
            StartedAtTime = round.StartedAtTime;
            LengthInKilometers = round.LengthInKilometers;
            MaxRestTimeInMinutes = round.MaxRestTimeInMinutes;
            VetGateEntryInMinutes = round.VetGateEntryInMinutes;
        }

        public DateTime? FinishedAtTime { get; set; }

        public DateTime? VetGateEntryDeadlineTime { get; set; }

        public VetGateStatus FirstVetGateEntryStatus { get; set; }

        public VetGateStatus SecondVetGateEntryStatus { get; set; }

        public DateTime? VetGateEntryTime { get; set; }

        public double? AvarageSpeed { get; set; }

        public int CompetitorId { get; set; }

        public TrialCompetitor Competitor { get; set; }
    }
}
