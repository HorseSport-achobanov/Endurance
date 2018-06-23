namespace Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Contracts;

    [Table("Competitors")]
    public class BaseCompetitor : IIdentifiable<int>, IAuditInfo
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
