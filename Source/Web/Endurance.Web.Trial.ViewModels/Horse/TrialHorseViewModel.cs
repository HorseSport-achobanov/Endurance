namespace Endurance.Web.Trial.ViewModels.Horse
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data.Trial.Models;
    using global::Web.Common.ViewModels;

    public class TrialHorseViewModel : IMapFrom<TrialHorse>, IMapTo<TrialHorse>
    {
        public string Name { get; set; }

        public string Breed { get; set; }

        [UIHint("SelectList")]
        public int ClubId { get; set; }

        public IList<SelectOption> ClubOptions { get; set; }
    }
}
