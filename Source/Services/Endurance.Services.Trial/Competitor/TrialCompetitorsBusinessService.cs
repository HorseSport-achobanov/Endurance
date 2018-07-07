namespace Endurance.Services.Trial.Competitor
{
    using Contracts.Competitor;
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

    public class TrialCompetitorsBusinessService : ITrialCompetitorBusinessService
    {
        private readonly IDataService<TrialCompetitor> competitiorsData;
        private readonly IDataService<TrialHorse> horsesData;
        private readonly IDataService<TrialRider> ridersData;
        private readonly IDataService<Trial> trialsData;

        private readonly string NullEntityMessageFormat = "{0} does not exist";

        public TrialCompetitorsBusinessService(
            IDataService<TrialCompetitor> competitiorsData,
            IDataService<TrialHorse> horsesData,
            IDataService<TrialRider> ridersData,
            IDataService<Trial> trialsData)
        {
            this.competitiorsData = competitiorsData;
            this.horsesData = horsesData;
            this.ridersData = ridersData;
            this.trialsData = trialsData;
        }


        public (bool success, string field, string message) Create(TrialCompetitor competitor)
        {
            var rider = this.ridersData.GetById(competitor.RiderId);
            var horse = this.horsesData.GetById(competitor.HorseId);
            var trial = this.trialsData.GetById(competitor.TrialId);

            if (rider == null)
            {
                return (
                    success: false, 
                    field: nameof(TrialCompetitor.RiderId), 
                    message: string.Format(NullEntityMessageFormat, "Rider"));
            }

            if (horse == null)
            {
                return (
                    success: false,
                    field: nameof(TrialCompetitor.HorseId),
                    message: string.Format(NullEntityMessageFormat, "Horse"));
            }

            if (trial == null)
            {
                return (
                    success: false,
                    field: nameof(TrialCompetitor.TrialId),
                    message: string.Format(NullEntityMessageFormat, "Trial"));
            }

            if (trial.IsActive)
            {
                return (
                    success: false,
                    field: nameof(TrialCompetitor.TrialId),
                    message: "Cannot create competitors for active trials.");
            }

            this.competitiorsData.Add(competitor);
            
            return (success: true, string.Empty, string.Empty);
        }
    }
}
