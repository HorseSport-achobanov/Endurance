namespace Endurance.Services.Trial.Contracts.Trial
{
    using System.Linq;
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

    public interface ITrialsDataService : IDataService<Trial>
    {
        Trial GetTrialToManage(int id);
    }
}
