namespace Endurance.Web.Trial.ViewModels.Club
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping;
    using global::Data.Common.Models;

    public class BaseClubViewModel : IMapFrom<BaseClub>, IMapTo<BaseClub>
    {
        [Required]
        public string Name { get; set; }
    }
}
