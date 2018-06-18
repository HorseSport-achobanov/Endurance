namespace Endurance.Data.Trial.Queries.Trial
{
    using System.Linq;
    using Contracts.Trial;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Models;

    public class QueryTrials : IQueryTrials
    {
        private readonly TrialDbContext dbContext;

        public QueryTrials(TrialDbContext dbContext)
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
