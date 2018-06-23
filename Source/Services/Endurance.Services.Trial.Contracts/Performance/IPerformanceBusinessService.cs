namespace Endurance.Services.Trial.Contracts.Performance
{
    using System;
    using Data.Trial.Models;

    public interface IPerformanceBusinessService
    {
        DateTime Finish(TrialRoundPerformance performance, string finishedAtTime);
    }
}
