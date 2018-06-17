namespace Endurance.Data.Trial.Contracts.Trial
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Models;

    public interface IQueryTrials
    {
        Trial GetById(int id);

        IQueryable<Trial> GetQueryableAll();

        EntityEntry<Trial> Create(Trial trial);
    }
}
