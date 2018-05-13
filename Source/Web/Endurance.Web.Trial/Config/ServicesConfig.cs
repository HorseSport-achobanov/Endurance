namespace Endurance.Web.Trial.Config
{
    using System.Reflection;
    using Common.Constants;
    using Microsoft.Extensions.DependencyInjection;

    using global::Services.Common;
    using global::Services.Common.Contracts;
    using Common.Mapping;
    using Services.Trial.Account;
    using Services.Trial.Contracts.Account;

    public static class ServicesConfig
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            MapCustomServices(services);
        }

        public static void AddMapper(this IServiceCollection services)
        {
            var config = AutomapperConfig.Configure(Assembly.Load(Assemblies.ViewModels));
            services.AddSingleton(sp => config.CreateMapper());
        }

        private static void MapCustomServices(IServiceCollection services)
        {
            services.AddScoped<IUserBusinessService, UserBusinessService>();
            services.AddScoped<IUserDataService, UserDataService>();
            services.AddScoped<IAutomapperService, AutomapperService>();
        }
    }
}
