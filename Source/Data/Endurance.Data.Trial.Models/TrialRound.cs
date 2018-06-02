namespace Endurance.Data.Trial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using global::Data.Common.Contracts;

    [Table("Rounds")]
    public class TrialRound : IIdentifiable<int>
    {
        private TimeSpan timeSpan;

        public int Id { get; set; }

        public double LengthInKilometers { get; set; }

        public int MaxRestTimeInMinutes
        {
            get => timeSpan.Minutes;
            set => timeSpan = new TimeSpan(0, value, 0);
        }
    }
}
