﻿namespace RateMyCourse.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Remove(T entity);
        void Remove(int id);
        void SaveChanges();
    }
}