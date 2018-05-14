namespace Data.Common.Contracts.Queries
{
    using System.Collections.Generic;

    public interface IBaseQuery<T>
        where T : class
    {
        T Create(T model);

        IEnumerable<T> CreateBatch(IEnumerable<T> batch);

    }
}
