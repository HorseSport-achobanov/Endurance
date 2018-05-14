namespace Data.Common
{
    using System;
    using Contracts;

    public class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
