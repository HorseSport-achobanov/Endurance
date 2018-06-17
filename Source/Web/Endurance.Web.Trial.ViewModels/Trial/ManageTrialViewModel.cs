namespace Endurance.Web.Trial.ViewModels.Trial
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Common.Mapping;
    using Data.Trial.Models;
    using Services.Common.Contracts;

    public class ManageTrialViewModel : IMapFrom<Trial>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int NumberOfRounds { get; set; }

        public IList<TrialCompetitorViewModel> Competitors { get; set; }

        public DateTime StartTime { get; set; }

//        public void CreateMappings(IMapperConfigurationExpression configuration)
//        {
//            configuration.CreateMap<Trial, ManageTrialViewModel>()
//                .ForMember(m => Competitors,
//                    opt => opt.MapFrom(e => 
//                        mapper.MapCollection<TrialCompetitor, TrialCompetitorViewModel>(e.Competitors)));
//        }
    }
}
