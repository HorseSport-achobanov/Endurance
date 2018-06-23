namespace Data.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => this.dbSet.ToList();

        public IQueryable<T> GetQueryableAll() => this.dbSet;

        public T GetById(object id) => this.dbSet.Find(id);

        public T Add(T entity) => this.dbSet.Add(entity).Entity;

        public T Remove(object id)
        {
            var entity = this.GetById(id);
            if (entity == null)
            {
                return null;
            }

            return this.Remove(entity);
        }

        public T Remove(T entity) => this.dbSet.Remove(entity).Entity;

        public void SaveChanges() => this.context.SaveChanges();
    }
}
