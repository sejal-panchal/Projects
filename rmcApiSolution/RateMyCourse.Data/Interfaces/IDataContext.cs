namespace RateMyCourse.Data
{
    using System.Data.Entity;
    using Domain;

    public interface IDataContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Student> Students { get; set; }
    }
}