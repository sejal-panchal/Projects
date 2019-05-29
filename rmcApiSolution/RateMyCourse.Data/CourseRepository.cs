using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RateMyCourse.Data
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DataContext database) : base(database)
        {
            Database = database;
        }

        public override void Add(Course entity)
        {
            if (entity != null)
                base.Add(entity);
        }

        public override void Update(Course entity)
        {
            if (entity == null) return;
            Course updateCourse = base.Get(entity.CourseId);
            if (updateCourse == null) return;
            updateCourse.Code = entity.Code;
            updateCourse.Name = entity.Name;
            updateCourse.Description = entity.Description;
        }

        public override IEnumerable<Course> FindBy(Expression<Func<Course, bool>> predicate)
        {
            return predicate == null ? GetAll() : base.FindBy(predicate);
        }

        public override Course Get(int id)
        {
            var course = (from c in Database.Courses.Include("Reviews").Include("Students")
                where c.CourseId == id
                select c).SingleOrDefault();

            return course;
        }

        public override IEnumerable<Course> GetAll()
        {
            var courses = from c in Database.Courses.Include("Reviews").Include("Students")
                select c;

            return courses;
        }

        public override void Remove(int id)
        {
            if (id > 0)
                base.Remove(id);
        }

        public override void Remove(Course entity)
        {
            if (entity != null)
                base.Remove(entity);
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
        }

    }
}
