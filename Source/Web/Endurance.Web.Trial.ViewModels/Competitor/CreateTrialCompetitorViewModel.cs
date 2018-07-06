namespace Endurance.Web.Trial.ViewModels.Competitor
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using Data.Trial.Models;
    using global::Web.Common.ViewModels;

    public class CreateTrialCompetitorViewModel : IMapFrom<TrialCompetitor>, IMapTo<TrialCompetitor>
    {
        [Required]
        public int Number { get; set; }

        [Required]
        [UIHint("SelectList")]
        public int RiderId { get; set; }

        public IList<SelectOption> RiderOptions { get; set; }

        [Required]
        [UIHint("SelectList")]
        public int HorseId { get; set; }

        public IList<SelectOption> HorseOptions { get; set; }

        [Required]
        [UIHint("SelectList")]
        public int TrialId { get; set; }

        public IList<SelectOption> TrialOptions { get; set; }
    }
}
