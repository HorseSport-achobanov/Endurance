namespace Endurance.Web.Trial.ViewModels.Trial
{
    using System;
    using System.Collections.Generic;

    using Common.Mapping;
    using Data.Trial.Models;

    public class CreateTrialViewModel : IMapFrom<Trial>, IMapTo<Trial>
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public IList<TrialRound> Rounds { get; set; }
    }
}
