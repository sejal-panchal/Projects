namespace RateMyCourse.Services
{
    using Data;
    using Domain;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class CourseService : Service<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository) : base(courseRepository as IRepository<Course>)
        {
            _courseRepository = courseRepository;
        }

        public new CourseViewModel Get(int id)
        {
            return CreateViewModel(base.Get(id));
        }


        public new IEnumerable<CourseViewModel> GetAll()
        {
            return base.GetAll().Select(CreateViewModel);
        }

        public void Add(CourseViewModel entity)
        {
            base.Add(CreateEntity(entity));
        }

        public void Update(CourseViewModel entity)
        {
            base.Update(CreateEntity(entity));
        }

        public new IEnumerable<CourseViewModel> FindBy(Expression<Func<Course, bool>> predicate)
        {
            return base.FindBy(predicate).Select(CreateViewModel);
        }

        public void Remove(CourseViewModel entity)
        {
            base.Remove(CreateEntity(entity));
        }

        public CourseViewModel CreateViewModel(Course courseEntity)
        {
            var model = new CourseViewModel
            {
                CourseId = courseEntity.CourseId,
                Code = courseEntity.Code,
                Name = courseEntity.Name,
                Description = courseEntity.Description,
                Reviews = (from r in courseEntity.Reviews
                    select new ReviewViewModel
                    {
                        ReviewId = r.ReviewId,
                        ReviewDate = r.ReviewDate,
                        ReviewText = r.ReviewText,
                        Stars = r.Stars,
                        CourseId = r.CourseId
                    }).ToList(),
                Students = (from s in courseEntity.Students
                    select new StudentViewModel
                    {
                        StudentId = s.StudentId,
                        Name = s.Name,
                        City = s.City,
                        PhoneNumber = s.PhoneNumber,
                        Status = s.Status
                    }).ToList(),

                canDelete = true
            };

            return model;
        }

        public Course CreateEntity(CourseViewModel courseViewModel)
        {
            var model = new Course
            {
                CourseId = courseViewModel.CourseId,
                Code = courseViewModel.Code,
                Name = courseViewModel.Name,
                Description = courseViewModel.Description
            };

            return model;
        }
    }
}
