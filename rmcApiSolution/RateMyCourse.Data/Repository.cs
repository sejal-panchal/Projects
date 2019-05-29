namespace RateMyCourse.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext Database;
        private readonly IDbSet<T> _dbSet;

        protected Repository(DataContext database)
        {
            Database = database;
            _dbSet = database.Set<T>();
        }

        public virtual T Get(int id)
        {
            T entity = _dbSet.Find(id);
            return entity;      
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual void Add(T entity)
        {
            if (entity != null)
                _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
        }

        public virtual void Remove(T entity)
        {
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public virtual void Remove(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity!=null)
                _dbSet.Remove(entity);
        }

        public virtual void SaveChanges()
        {
            Database.SaveChanges();
        }
    }
}
