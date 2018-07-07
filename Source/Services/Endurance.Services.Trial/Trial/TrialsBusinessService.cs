namespace Endurance.Services.Trial.Trial
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Trial;
    using Endurance.Data.Trial.Models;
    using global::Services.Common.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class TrialsBusinessService : ITrialsBusinessService
    {
        private readonly IDataService<Trial> trialsData;

        public TrialsBusinessService(IDataService<Trial> trialsData)
        {
            this.trialsData = trialsData;
        }

        public bool Activate(int id)
        {
            var trial = this.trialsData
                .GetAllQueryable()
                .Where(t => t.Id == id)
                .Include(t => t.Rounds)
                .Include(t => t.Competitors)
                .FirstOrDefault();

            if (trial == null || trial.IsActive)
            {
                return false;
            }

            trial.IsActive = true;
            foreach (var competitor in trial.Competitors)
            {
                competitor.Performances = InitializePerormances(competitor.Id, trial.Rounds);
            }

            this.trialsData.Update(trial);

            return true;
        }

        private IList<TrialRoundPerformance> InitializePerormances(int competitorId, IList<TrialRound> rounds)
        {
            var performances = new List<TrialRoundPerformance>();

            foreach (var round in rounds)
            {
                performances.Add(new TrialRoundPerformance(competitorId, round));
            }

            return performances;
        }
    }
}
