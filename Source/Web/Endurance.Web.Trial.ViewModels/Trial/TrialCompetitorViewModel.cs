namespace Endurance.Web.Trial.ViewModels.Trial
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Common.Mapping;
    using Data.Trial.Models;
    using global::Data.Common;
    using Resources.Endurance.Enums;

    public class TrialCompetitorViewModel : IMapFrom<TrialCompetitor>, IHasCustomMappings
    {
        public TrialCompetitorViewModel()
        {
            CurrentAvarageSpeedAtRounds = new List<float>();
        }

        public int Number { get; set; }

        public bool Disqualified { get; set; }

        public TrialRider Rider { get; set; }

        public TrialHorse Horse { get; set; }

        public IList<TrialRoundPerformanceViewModel> Performances { get; set; }

        public IList<float> CurrentAvarageSpeedAtRounds { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<TrialCompetitor, TrialCompetitorViewModel>()
                .ForMember(
                    m => m.Disqualified,
                    opt => opt.MapFrom(e => e.Performances.Any(p => 
                        p.SecondVetGateEntryStatus == VetGateStatus.Failed
                        || p.VetGateEntryTime.HasValue 
                            && p.FinishedAtTime.HasValue
                            && p.VetGateEntryTime.Value > p.FinishedAtTime.Value.AddMinutes(p.VetGateEntryInMinutes))));
        }
    }
}
