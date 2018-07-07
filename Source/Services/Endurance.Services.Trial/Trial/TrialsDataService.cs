namespace Endurance.Services.Trial.Trial
{
    using System.Linq;
    using Contracts.Trial;
    using Endurance.Data.Trial.Models;
    using global::Data.Common.Contracts;
    using global::Services.Common;
    using Microsoft.EntityFrameworkCore;

    public class TrialsDataService : DataService<Trial>, ITrialsDataService
    {
        private IRepository<Trial> Trials => this.Data;

        public TrialsDataService(IRepository<Trial> trials) : base(trials)
        {
        }

        public Trial GetTrialToManage(int Id) =>
            this.Trials
                .GetAllQueryable()
                .Where(t => t.Id == Id)
                .Include(t => t.Rounds)
                .Include(t => t.Competitors).ThenInclude(c => c.Performances)
                .Include(t => t.Competitors).ThenInclude(c => c.Rider)
                .Include(t => t.Competitors).ThenInclude(c => c.Horse)
                .FirstOrDefault();
    }
}
