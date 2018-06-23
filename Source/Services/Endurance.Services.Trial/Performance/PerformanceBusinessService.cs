namespace Endurance.Services.Trial.Performance
{
    using System;
    using System.Transactions;
    using Contracts.Performance;
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

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
    }
}

