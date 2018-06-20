namespace Endurance.Data.Trial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using global::Data.Common.Contracts;

    [Table("Rounds")]
    public class TrialRound : IIdentifiable<int>
    {
        public int Id { get; set; }

        public double LengthInKilometers { get; set; }
        
        public double VetGateEntryInMinutes { get; set; }

        public double MaxRestTimeInMinutes { get; set; }
    }
}
