namespace Endurance.Web.Trial.Config
{
    using System.Reflection;
    using Common.Constants;
    using Microsoft.Extensions.DependencyInjection;

    using global::Services.Common;
    using global::Services.Common.Contracts;
    using Common.Mapping;
    using Endurance.Data.Trial.Contracts.Trial;
    using Endurance.Data.Trial.Queries.Trial;
    using Services.Trial.Account;
    using Services.Trial.Contracts.Account;
    using Services.Trial.Contracts.Performance;
    using Services.Trial.Contracts.Trial;
    using Services.Trial.Performance;
    using Services.Trial.Trial;

    public static class ServicesConfig
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            MapCustomServices(services);
            MapQueries(services);
        }

        public static void AddMapper(this IServiceCollection services)
        {
            var config = AutomapperConfig.Configure(Assembly.Load(Assemblies.ViewModels));
            services.AddSingleton(sp => config.CreateMapper());
        }

        private static void MapCustomServices(IServiceCollection services)
        {
            services.AddScoped<IUsersBusinessService, UsersBusinessService>();
            services.AddScoped<IUsersDataService, UsersDataService>();
            services.AddScoped<IAutomapperService, AutomapperService>();
            services.AddScoped<ITrialsBusinessService, TrialsBusinessService>();
            services.AddScoped<ITrialsDataService, TrialsDataService>();
            services.AddScoped<IPerformanceDataService, PerformanceDataService>();
        }

        private static void MapQueries(IServiceCollection services)
        {
            services.AddScoped<IQueryTrials, QueryTrials>();
        }
    }
}
