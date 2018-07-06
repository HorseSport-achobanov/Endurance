namespace Services.Common
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Contracts;

    public class AutomapperService : IAutomapperService
    {
        private readonly IMapper mapper;

        public AutomapperService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source) => this.mapper.Map<TDestination>(source);

        public void Map<TSource, TDestination>(TSource source, TDestination destination) =>
            this.mapper.Map(source, destination);

        public IQueryable<TDestination> MapQueryable<TDestination>(IQueryable source, object parameters = null) =>
            source.ProjectTo<TDestination>(this.mapper.ConfigurationProvider, parameters);

        public IList<TDestination> MapCollection<TSource, TDestination>(IEnumerable<TSource> source) =>
            mapper.Map<IEnumerable<TSource>, IList<TDestination>>(source);
    }
}
