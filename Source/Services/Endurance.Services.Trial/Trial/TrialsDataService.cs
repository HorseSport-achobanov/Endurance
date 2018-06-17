namespace Endurance.Services.Trial.Trial
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Trial;
    using Data.Trial.Contracts.Trial;
    using Endurance.Data.Trial.Models;

    public class TrialsDataService : ITrialsDataService
    {
        private readonly IQueryTrials query;

        public TrialsDataService(IQueryTrials query)
        {
            this.query = query;
        }

        public Trial GetById(int id) => this.query.GetById(id);

        public IQueryable<Trial> GetQueryableAll() => this.query.GetQueryableAll();

        public Trial Create(Trial trial)
        {
            var entity = query.Create(trial);
            
            return entity.Entity;
        } 
    }
}
