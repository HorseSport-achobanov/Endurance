namespace Data.Common.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        IQueryable<T> GetAllQueryable();

        T GetById(object id);

        T Add(T entity);

        T Update(T entity);

        T Remove(object id);

        T Remove(T entity);

        void SaveChanges();
    }
}
