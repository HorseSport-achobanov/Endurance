namespace Endurance.Web.Trial
{
    using Endurance.Data.Trial;
    using Endurance.Data.Trial.Seed;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var services = host.Services.CreateScope())
            {
                var context = services.ServiceProvider.GetRequiredService<TrialDbContext>();
                Seed.Initialize(context);
            }
            
            host.Run();
            // Hacks
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
