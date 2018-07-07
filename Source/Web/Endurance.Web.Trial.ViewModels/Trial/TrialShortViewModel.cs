namespace Endurance.Web.Trial.ViewModels.Trial
{
    using Common.Mapping;
    using Data.Trial.Models;

    public class TrialShortViewModel : IMapFrom<Trial>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
