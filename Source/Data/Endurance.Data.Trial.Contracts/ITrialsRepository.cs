namespace Endurance.Data.Trial.Contracts
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Models;

    public interface ITrialsRepository
    {
        IQueryable<Trial> GetQueryableById(int id);

        IQueryable<Trial> GetQueryableAll();

        EntityEntry<Trial> Create(Trial trial);
    }
}
