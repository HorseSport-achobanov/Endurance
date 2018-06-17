namespace Endurance.Services.Trial.Trial
{
    using Contracts.Trial;
    using Endurance.Data.Trial.Models;

    public class TrialsBusinessService : ITrialsBusinessService
    {
        private readonly ITrialsDataService trialsData;

        public TrialsBusinessService(ITrialsDataService trialsData)
        {
            this.trialsData = trialsData;
        }
        
    }
}
