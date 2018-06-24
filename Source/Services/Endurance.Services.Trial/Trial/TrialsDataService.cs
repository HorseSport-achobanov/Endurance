namespace Endurance.Services.Trial.Trial
{
    using System.Linq;
    using Contracts.Trial;
    using Endurance.Data.Trial.Models;
    using global::Data.Common.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class TrialsDataService : ITrialsDataService
    {
        private readonly IRepository<Trial> trialsData;

        public TrialsDataService(IRepository<Trial> trialsData)
        {
            this.trialsData = trialsData;
        }

        public Trial GetById(int id) =>
            this.trialsData.GetQueryableAll()
                .Where(t => t.Id == id)
                .Include(t => t.Rounds)
                .Include(t => t.Competitors).ThenInclude(c => c.Rider).ThenInclude(r => r.Club)
                .Include(t => t.Competitors).ThenInclude(c => c.Horse)
                .Include(t => t.Competitors).ThenInclude(c => c.Performances)
                .FirstOrDefault();

        public IQueryable<Trial> GetQueryableAll() => this.trialsData.GetQueryableAll();

        public Trial Create(Trial trial) => trialsData.Add(trial);
    }
}
