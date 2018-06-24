namespace Endurance.Services.Trial.Contracts.Performance
{
    using System;
    using Data.Trial.Models;
    using Resources.Endurance.Enums;

    public interface IPerformanceBusinessService
    {
        (string vetGateEntryDeadline, double avarageSpeed) Finish(
            TrialRoundPerformance performance, 
            string finishedAtTime);

        (bool disqualified, bool passed, string) VetGateAttempt(
            TrialRoundPerformance performance, 
            VetGateStatus vetGateStatus);
    }
}
