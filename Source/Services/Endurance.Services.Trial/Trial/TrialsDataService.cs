namespace Endurance.Services.Trial.Trial
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Trial;
    using Data.Trial.Contracts;
    using Endurance.Data.Trial.Models;
    using Microsoft.EntityFrameworkCore;

    public class TrialsDataService : ITrialsDataService
    {
        private readonly ITrialsRepository query;

        public TrialsDataService(ITrialsRepository query)
        {
            this.query = query;
        }

        public Trial GetById(int id) =>
            this.query.GetQueryableById(id)
                .Include(t => t.Competitors).ThenInclude(c => c.Rider).ThenInclude(r => r.Club)
                .Include(t => t.Competitors).ThenInclude(c => c.Horse)
                .Include(t => t.Competitors).ThenInclude(c => c.Performances)
                .FirstOrDefault();

        public IQueryable<Trial> GetQueryableAll() => this.query.GetQueryableAll();

        public Trial Create(Trial trial)
        {
            var entity = query.Create(trial);
            
            return entity.Entity;
        } 
    }
}
