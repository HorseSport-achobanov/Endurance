namespace Services.Common.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public interface IAutomapperService
    {
        TDestination Map<TDestination>(object source);

        void Map<TSource, TDestination>(TSource source, TDestination destination);

        IQueryable<TDestination> MapQueryable<TDestination>(IQueryable source, object parameters = null);

        IList<TDestination> MapCollection<TSource, TDestination>(IList<TSource> source);
    }
}
