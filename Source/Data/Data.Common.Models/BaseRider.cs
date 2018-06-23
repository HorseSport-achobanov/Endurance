namespace Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts;

    [Table("Riders")]
    public class BaseRider : IIdentifiable<int>, IAuditInfo
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set;  }

        public BaseClub Club { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
