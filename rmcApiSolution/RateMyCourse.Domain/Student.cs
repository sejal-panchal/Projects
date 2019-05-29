namespace RateMyCourse.Domain
{
    using System.Collections.Generic;

    public class Student : BaseDomain, IStudent
    {
        public Student()
        {
            Reviews = new HashSet<Review>();
            Courses = new HashSet<Course>();
        }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
