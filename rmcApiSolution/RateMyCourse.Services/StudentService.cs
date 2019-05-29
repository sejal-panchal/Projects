namespace RateMyCourse.Services
{
    using Data;
    using Domain;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class StudentService : Service<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository) : base(studentRepository as IRepository<Student>)
        {
            _studentRepository = studentRepository;
        }

        public new StudentViewModel Get(int id)
        {
            return CreateViewModel(base.Get(id));
        }

        public new IEnumerable<StudentViewModel> GetAll()
        {
            return base.GetAll().Select(CreateViewModel);
        }

        public void Add(StudentViewModel entity)
        {
            base.Add(CreateEntity(entity));
        }

        public void Update(StudentViewModel entity)
        {
            base.Update(CreateEntity(entity));
        }

        public new IEnumerable<StudentViewModel> FindBy(Expression<Func<Student, bool>> predicate)
        {
            return base.FindBy(predicate).Select(CreateViewModel);
        }

        public void Remove(StudentViewModel entity)
        {
            base.Remove(CreateEntity(entity));
        }

        public StudentViewModel CreateViewModel(Student studentEntity)
        {
            var model = new StudentViewModel
            {
                StudentId = studentEntity.StudentId,
                Name = studentEntity.Name,
                PhoneNumber = studentEntity.PhoneNumber,
                City = studentEntity.City,
                Reviews = (from r in studentEntity.Reviews
                    select new ReviewViewModel
                    {
                        ReviewId = r.ReviewId,
                        ReviewDate = r.ReviewDate,
                        ReviewText = r.ReviewText,
                        Stars = r.Stars,
                        CourseId = r.CourseId
                    }).ToList(),
                Courses = (from c in studentEntity.Courses
                    select new CourseViewModel
                    {
                        CourseId = c.CourseId,
                        Name = c.Name,
                        Description = c.Description,
                        Code = c.Code,
                        Status = c.Status
                    }).ToList()
            };

            return model;
        }

        public Student CreateEntity(StudentViewModel studentViewModel)
        {
            var entity = new Student
            {
                StudentId = studentViewModel.StudentId,
                Name = studentViewModel.Name,
                PhoneNumber = studentViewModel.PhoneNumber,
                City = studentViewModel.City
            };

            return entity;
        }
    }
}
