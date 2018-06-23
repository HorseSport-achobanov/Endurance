namespace Endurance.Services.Trial.Performance
{
    using Contracts.Performance;
    using Data.Trial.Models;

    public class PerformanceDataService : IPerformanceDataService
    {
        public PerformanceDataService()
        {
            
        }

        public TrialRoundPerformance GetById(int id) => new TrialRoundPerformance();
            
    }
}
