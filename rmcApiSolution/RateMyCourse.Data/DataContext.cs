namespace RateMyCourse.Data
{
    using Domain;
    using System.Data.Entity;

    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
