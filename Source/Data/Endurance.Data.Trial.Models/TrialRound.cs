namespace Endurance.Data.Trial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using global::Data.Common.Contracts;

    [Table("Rounds")]
    public class TrialRound : IIdentifiable<int>
    {
        public int Id { get; set; }

        public float LengthInKilometers { get; set; }

        public TimeSpan MaxRestTimeSpan { get; set; }
    }
}
