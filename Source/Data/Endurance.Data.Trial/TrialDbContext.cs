namespace Endurance.Data.Trial
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using global::Data.Common.Contracts;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models.Account;

    public class HssDbContext : IdentityDbContext<User>
    {
        public HssDbContext(DbContextOptions<HssDbContext> options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

#if DEBUG
            //// Use this to see DB validation errors
            return this.SaveChangesWithTracingDbExceptions();
#else
            return base.SaveChanges();
#endif
        }

        public void ClearDatabase()
        {
            throw new NotImplementedException();
        }

        public new DbSet<T> Set<T>()
            where T : class => base.Set<T>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            var auditInfoEntries = this.ChangeTracker
                .Entries()
                .Where(e => 
                    e.Entity is IAuditInfo 
                    && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in auditInfoEntries)
            {
                var entity = (IAuditInfo) entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private int SaveChangesWithTracingDbExceptions()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Exception currentException = ex;
                while (currentException != null)
                {
                    Trace.TraceError(currentException.Message);
                    currentException = currentException.InnerException;
                }

                throw;
            }
        }
    }
}
