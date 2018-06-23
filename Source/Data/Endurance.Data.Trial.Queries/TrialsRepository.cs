namespace Endurance.Data.Trial.Repositories.Trial
{
    using System.Linq;
    using Contracts;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Models;

    public class TrialsRepository : ITrialsRepository
    {
        private readonly TrialDbContext dbContext;

        public TrialsRepository(TrialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Trial> GetQueryableById(int id) => 
            this.dbContext.Trials
                .Where(t => t.Id == id);

        public IQueryable<Trial> GetQueryableAll() => 
            this.dbContext.Trials;

        public EntityEntry<Trial> Create(Trial trial)
        {
            var entity = this.dbContext.Trials.Add(trial);
            this.dbContext.SaveChanges();

            return entity;
        }
    }
}
