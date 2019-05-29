namespace RateMyCourse.Domain
{
    using System;

    public class Review : BaseDomain, IReview
    {
        public int ReviewId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewText { get; set; }
        public int Stars { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
