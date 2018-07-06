namespace Endurance.Web.Trial.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Club;
    using Common.Mapping;
    using Data.Trial.Models;
    using global::Web.Common.ViewModels;

    public class TrialRiderViewModel : IMapFrom<TrialRider>, IMapTo<TrialRider>
    {
        public TrialRiderViewModel()
        {
            this.ClubOptions = new List<SelectOption>();    
        }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set;  }
        
        [Required]
        [UIHint("SelectList")]
        public int ClubId { get; set; }

        public IList<SelectOption> ClubOptions { get; set; }
    }
}
