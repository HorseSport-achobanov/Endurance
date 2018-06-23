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

        public string Finish(TrialRoundPerformance performance, string finishedAtValue)
        {
            performance.FinishedAtTime = DateTime.Parse(finishedAtValue);
            performance.VetGateEntryDeadlineTime = performance.FinishedAtTime.Value.AddMinutes(performance.VetGateEntryInMinutes);

            this.performancesData.Update(performance);

            return performance.VetGateEntryDeadlineTime.Value.ToString("HH:mm");;

//            var nextPerformance =
//                this.performancesData.GetNextByIndexAndCompetitorId(perfomance.Index, perfomance.CompetitorId);
//
//            nextPerformance.StartedAtTime =
//                perfomance.FinishedAtTime.Value.AddMinutes(perfomance.VetGateEntryInMinutes);
        }

        public (bool, string) VetGateAttempt(TrialRoundPerformance performance, VetGateStatus vetGateStatus)
        {
            if (performance.FirstVetGateEntryStatus == VetGateStatus.NotEntered)
            {
                performance.FirstVetGateEntryStatus = vetGateStatus;
               
                if (vetGateStatus == VetGateStatus.Failed)
                {
                    this.performancesData.Update(performance);
                    return (false, string.Empty);
                }
            }
            else
            {
                performance.SecondVetGateEntryStatus = vetGateStatus;
                
                if (vetGateStatus == VetGateStatus.Failed)
                {
                    DisqualifyCompetitor(performance.Id);
                    return (true, string.Empty);
                }
            }

            var nextPerformanceStartAtTime = SetNextPerformanceStartTime(
                performance.Index, 
                performance.CompetitorId, 
                performance.MaxRestTimeInMinutes);

            return (false, nextPerformanceStartAtTime.ToString("HH:mm"));
        }


        private void DisqualifyCompetitor(int id)
        {
            var performance = this.performancesData.GetByIdWithCompetitor(id);
            performance.Competitor.Disqualified = true;
            
            this.performancesData.Update(performance);
        }

        private DateTime SetNextPerformanceStartTime(int index, int competitorId, double restMinutes)
        {
            var nextPerformance =
                this.performancesData.GetNextByIndexAndCompetitorId(index, competitorId);
            nextPerformance.StartedAtTime = DateTime.Now.AddMinutes(restMinutes);

            this.performancesData.Update(nextPerformance);

            return nextPerformance.StartedAtTime.Value;
        }
    }
}

