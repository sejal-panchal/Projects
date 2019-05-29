namespace RateMyCourse.Domain
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Code { get; set; }
        int CourseId { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        ICollection<Review> Reviews { get; set; }
        ICollection<Student> Students { get; set; }
    }
}