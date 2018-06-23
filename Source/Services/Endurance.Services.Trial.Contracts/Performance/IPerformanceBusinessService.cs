﻿namespace Endurance.Services.Trial.Contracts.Performance
{
    using System;
    using Data.Trial.Models;
    using Resources.Endurance.Enums;

    public interface IPerformanceBusinessService
    {
        string Finish(TrialRoundPerformance performance, string finishedAtTime);

        (bool, string) VetGateAttempt(TrialRoundPerformance performance, VetGateStatus vetGateStatus);
    }
}
