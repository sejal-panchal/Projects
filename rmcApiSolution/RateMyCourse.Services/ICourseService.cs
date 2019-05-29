namespace RateMyCourse.Services
{
    using Domain;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ICourseService
    {
        Course CreateEntity(CourseViewModel courseViewModel);
        CourseViewModel CreateViewModel(Course courseEntity);
        CourseViewModel Get(int id);
        IEnumerable<CourseViewModel> GetAll();
        void Add(CourseViewModel entity);
        void Update(CourseViewModel entity);
        IEnumerable<CourseViewModel> FindBy(Expression<Func<Course, bool>> predicate);
        void Remove(CourseViewModel entity);
        void Remove(int id);
        void SaveChanges();
    }
}