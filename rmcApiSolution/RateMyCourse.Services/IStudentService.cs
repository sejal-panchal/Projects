using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RateMyCourse.Services
{
    using Data;
    using Domain;
    using ViewModels;

    public interface IStudentService
    {
        Student CreateEntity(StudentViewModel courseViewModel);
        StudentViewModel CreateViewModel(Student courseEntity);
        StudentViewModel Get(int id);
        IEnumerable<StudentViewModel> GetAll();
        void Add(StudentViewModel entity);
        void Update(StudentViewModel entity);
        IEnumerable<StudentViewModel> FindBy(Expression<Func<Student, bool>> predicate);
        void Remove(StudentViewModel entity);
        void Remove(int id);
        void SaveChanges();
    }
}