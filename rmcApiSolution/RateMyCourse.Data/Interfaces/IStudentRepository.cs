namespace RateMyCourse.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Domain;

    public interface IStudentRepository
    {
        void Add(Student entity);
        void Update(Student entity);
        IEnumerable<Student> FindBy(Expression<Func<Student, bool>> predicate);
        Student Get(int id);
        IEnumerable<Student> GetAll();
        void Remove(Student entity);
        void Remove(int id);
        void SaveChanges();
    }
}