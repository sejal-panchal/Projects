namespace RateMyCourse.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Domain;

    public interface ICourseRepository
    {
        void Add(Course entity);
        void Update(Course entity);
        IEnumerable<Course> FindBy(Expression<Func<Course, bool>> predicate);
        Course Get(int id);
        IEnumerable<Course> GetAll();
        void Remove(int id);
        void Remove(Course entity);
        void SaveChanges();
    }
}