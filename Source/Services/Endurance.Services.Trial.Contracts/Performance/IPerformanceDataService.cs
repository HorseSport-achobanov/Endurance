namespace Endurance.Services.Trial.Contracts.Performance
{
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

    public interface IPerformanceDataService : IDataService<TrialRoundPerformance>
    {
        TrialRoundPerformance GetNextByIndexAndCompetitorId(int index, int competitorId);
        
        TrialRoundPerformance GetByIdWithCompetitor(int performanceId);
    }
}
