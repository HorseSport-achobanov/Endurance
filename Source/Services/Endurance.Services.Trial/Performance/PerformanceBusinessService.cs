namespace Endurance.Services.Trial.Performance
{
    using System;
    using System.Transactions;
    using Contracts.Performance;
    using Data.Trial.Models;
    using global::Services.Common.Contracts;
    using Resources.Endurance.Enums;

    public class PerformanceBusinessService : IPerformanceBusinessService
    {
        private readonly IPerformanceDataService performancesData;

        public PerformanceBusinessService(IPerformanceDataService performancesData)
        {
            this.performancesData = performancesData;
        }

        public (string vetGateEntryDeadline, double avarageSpeed) Finish(
            TrialRoundPerformance performance, 
            string finishedAtValue)
        {
            performance.FinishedAtTime = DateTime.Parse(finishedAtValue);

            var avarageSpeed = CalculateAvarageSpeed(performance);
            var vetGateEntryDeadline = performance.FinishedAtTime.Value.AddMinutes(performance.VetGateEntryInMinutes);

            performance.AvarageSpeed = avarageSpeed;
            performance.VetGateEntryDeadlineTime = vetGateEntryDeadline;

            this.performancesData.Update(performance);

            return (vetGateEntryDeadline.ToString("HH:mm"), Math.Round(avarageSpeed, 2));
        }

        public (bool disqualified, bool passed, string) VetGateAttempt(
            TrialRoundPerformance performance, 
            VetGateStatus vetGateStatus)
        {
            performance.VetGateEntryTime = DateTime.Now;
            if (performance.VetGateEntryTime > performance.VetGateEntryDeadlineTime)
            {
                this.performancesData.Update(performance);
                return (disqualified: true, passed: false, "Exceeded VetGate entry time");
            }

            if (performance.FirstVetGateEntryStatus == VetGateStatus.NotEntered)
            {
                performance.FirstVetGateEntryStatus = vetGateStatus;
               
                if (vetGateStatus == VetGateStatus.Failed)
                {
                    this.performancesData.Update(performance);
                    return (disqualified: false, passed: true, string.Empty);
                }
            }
            else
            {
                performance.SecondVetGateEntryStatus = vetGateStatus;
                
                if (vetGateStatus == VetGateStatus.Failed)
                {
                    this.performancesData.Update(performance);
                    return (disqualified: true, passed: false, string.Empty);
                }
            }

            var nextPerformanceStartAtTime = SetNextPerformanceStartTime(
                performance.Index, 
                performance.CompetitorId, 
                performance.MaxRestTimeInMinutes);

            return (disqualified: false, passed: true, nextPerformanceStartAtTime?.ToString("HH:mm"));
        }

        private double CalculateAvarageSpeed(TrialRoundPerformance performance)
        {
            var startTime = performance.StartedAtTime.GetValueOrDefault();
            var finishTime = performance.FinishedAtTime.GetValueOrDefault();
            var lenght = performance.LengthInKilometers;

            var timeSpan = finishTime - startTime;
            var hours = timeSpan.TotalHours;

            return lenght / hours;
        }

        private DateTime? SetNextPerformanceStartTime(int index, int competitorId, double restMinutes)
        {
            var nextPerformance =
                this.performancesData.GetNextByIndexAndCompetitorId(index, competitorId);
            if (nextPerformance == null)
            {
                return null;
            }

            nextPerformance.StartedAtTime = DateTime.Now.AddMinutes(restMinutes);

            this.performancesData.Update(nextPerformance);

            return nextPerformance.StartedAtTime.Value;
        }
    }
}

