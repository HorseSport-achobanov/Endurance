namespace Endurance.Data.Trial.Seed
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Internal;
    using Models.Account;

    public static class Seed
    {
        public static void Initialize(TrialDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Trials.Any())
            {
                context.Trials.Add(Data.Trial);

                context.Users.Add(Data.AdminUser);

                context.SaveChanges();
            }
        }
    }
}
