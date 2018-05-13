namespace Endurance.Web.Trial.Config
{
    using Microsoft.Extensions.DependencyInjection;
    using Services.Trial.Account;
    using Services.Trial.Contracts.Account;

    public static class ServicesConfig
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            MapCustomServices(services);
        }

        private static void MapCustomServices(IServiceCollection services)
        {
            services.AddScoped<IUsersDataService, UsersDataService>();
        }
    }
}
