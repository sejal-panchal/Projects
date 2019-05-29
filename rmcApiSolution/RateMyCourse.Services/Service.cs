namespace RateMyCourse.Services
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public abstract class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        protected Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public virtual T Get(int id)
        {
            T entity = _repository.Get(id);

            return entity;
        } 

        public virtual IEnumerable<T> GetAll()
        {
            var query = _repository.GetAll();

            return query;
        }

        public virtual void Remove(int id)
        {
            _repository.Remove(id);
        }

        public virtual void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public virtual void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
