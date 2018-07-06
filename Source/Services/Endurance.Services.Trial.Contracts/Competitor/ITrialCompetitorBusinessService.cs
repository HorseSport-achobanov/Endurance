namespace Endurance.Services.Trial.Contracts.Competitor
{
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

    public interface ITrialCompetitorBusinessService : IService
    {
        (bool success, string field, string message) Create(TrialCompetitor competitor);
    }
}
