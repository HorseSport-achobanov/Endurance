namespace Endurance.Services.Trial.Contracts.Trial
{
    using System.Linq;
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

    public interface ITrialsDataService : IService
    {
        Trial GetById(int id);

        IQueryable<Trial> GetQueryableAll();

        Trial Create(Trial trial);
    }
}
