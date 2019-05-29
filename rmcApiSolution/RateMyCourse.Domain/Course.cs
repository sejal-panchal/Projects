namespace RateMyCourse.Domain
{
    using System.Collections.Generic;

    public class Course : BaseDomain, ICourse
    {
        public Course()
        {
            Reviews = new HashSet<Review>();
            Students = new HashSet<Student>();
        }
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
