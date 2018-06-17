namespace Endurance.Services.Trial.Contracts.Trial
{
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

    public interface ITrialsDataService : IService
    {
        Trial GetById(int id);
    }
}
