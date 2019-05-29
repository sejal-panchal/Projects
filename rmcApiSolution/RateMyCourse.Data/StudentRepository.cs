using System.Linq;

namespace RateMyCourse.Data
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext database) : base(database)
        {
            Database = database;
        }

        public override void Add(Student entity)
        {
            if (entity!=null)
                base.Add(entity);
        }
        public override void Update(Student entity)
        {
            if (entity == null) return;
            Student updateStudent = base.Get(entity.StudentId);
            if (updateStudent == null) return;
            updateStudent.Status = entity.Status;
            updateStudent.City = entity.City;
            updateStudent.Name = entity.Name;
            updateStudent.PhoneNumber = entity.PhoneNumber;
        }

        public override IEnumerable<Student> FindBy(Expression<Func<Student, bool>> predicate)
        {
            return predicate == null ? GetAll() : base.FindBy(predicate);
        }

        public override Student Get(int id)
        {
            var student = (from s in Database.Students.Include("Reviews").Include("Courses")
                           where s.StudentId == id
                select s).SingleOrDefault();

            return student;
        }

        public override IEnumerable<Student> GetAll()
        {
            var students = from s in Database.Students.Include("Reviews").Include("Courses")
                select s;

            return students;
        }

        public override void Remove(int id)
        {
            if(id > 0) 
                base.Remove(id);
        }

        public override void Remove(Student entity)
        {
            if (entity!=null)
                base.Remove(entity);
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
        }

    }
}
