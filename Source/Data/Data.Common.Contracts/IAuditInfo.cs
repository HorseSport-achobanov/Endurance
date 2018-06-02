namespace Data.Common.Contracts
{
    using System;

    public interface IAuditInfo
    {
        bool PreserveCreatedOn { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
