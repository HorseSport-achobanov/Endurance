namespace Endurance.Web.Trial.ViewModels.Trial
{
    using Common.Mapping;
    using Data.Trial.Models;
    public class TrialRoundViewModel : IMapFrom<TrialRound>
    {
        public int Index { get; set; }

        public int LengthInKilometers { get; set; }

        public double MaxRestTimeInMinutes { get; set; }

        public double VetGateEntryInMinutes { get; set; }
    }
}
