namespace Endurance.Data.Trial.Queries.Trial
{
    using Contracts.Trial;
    using Models;

    public class QueryTrials : IQueryTrials
    {
        private readonly TrialDbContext dbContext;

        public QueryTrials(TrialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Trial GetById(int id) => this.dbContext.Trials.Find(id);
    }
}
