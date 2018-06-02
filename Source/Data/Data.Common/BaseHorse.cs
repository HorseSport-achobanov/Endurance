namespace Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts;

    [Table("Horses")]
    public class BaseHorse : IIdentifiable<int>, IAuditInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
