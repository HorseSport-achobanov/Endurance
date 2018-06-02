namespace Endurance.Data.Trial.Models
{
    using System;
    using global::Data.Common.Contracts;
    public class TrialRound : IIdentifiable<int>
    {
        public int Id { get; set; }

        public float LengthInKilometers { get; set; }

        public TimeSpan MaxRestTimeSpan { get; set; }
    }
}
