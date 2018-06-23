namespace Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts;

    [Table("Clubs")]
    public class BaseClub : IIdentifiable<int>, IAuditInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
