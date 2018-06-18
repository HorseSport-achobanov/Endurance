namespace Endurance.Data.Trial.Contracts.Trial
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Models;

    public interface IQueryTrials
    {
        IQueryable<Trial> GetQueryableById(int id);

        IQueryable<Trial> GetQueryableAll();

        EntityEntry<Trial> Create(Trial trial);
    }
}
