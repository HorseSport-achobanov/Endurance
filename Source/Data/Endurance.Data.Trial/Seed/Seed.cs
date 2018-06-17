namespace Endurance.Data.Trial.Seed
{
    using Microsoft.EntityFrameworkCore.Internal;
    using Models;
    using Web.Trial.Data.Migrations;

    public static class Seed
    {
        public static void Initialize(TrialDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Trials.Any())
            {
                context.Trials.Add(Data.Trial);

                context.SaveChanges();
            }
        }
    }
}
