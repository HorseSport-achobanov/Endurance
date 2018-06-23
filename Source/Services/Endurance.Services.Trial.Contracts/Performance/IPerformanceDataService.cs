namespace Endurance.Services.Trial.Contracts.Performance
{
    using Data.Trial.Models;

    public interface IPerformanceDataService
    {
        TrialRoundPerformance GetById(int id);
    }
}
