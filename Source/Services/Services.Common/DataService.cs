namespace Services.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Common.Contracts;

    public class DataService<T> : IDataService<T>
        where T : class 
    {
        private readonly IRepository<T> data;

        public DataService(IRepository<T> data)
        {
            this.data = data;
        }

        protected IRepository<T> Data => this.data;

        public virtual IEnumerable<T> GetAll() => this.data.GetAll();

        public virtual IQueryable<T> GetAllQueryable() => this.data.GetAllQueryable();

        public virtual T GetById(object id) => this.data.GetById(id);

        public virtual T Add(T entity)
        {
            var addedEntity = this.data.Add(entity);
            this.data.SaveChanges();

            return addedEntity;
        }

        public virtual T Update(T entity)
        { 
            var updatedEntity = this.data.Update(entity);
            this.data.SaveChanges();

            return updatedEntity;
        }

        public virtual T Remove(object id)
        {
            var removedEntity = this.data.Remove(id);
            this.data.SaveChanges();

            return removedEntity;
        }

        public virtual T Remove(T entity)
        {
            var removedEntity = this.data.Remove(entity);
            this.data.SaveChanges();

            return removedEntity;
        }
    }
}
