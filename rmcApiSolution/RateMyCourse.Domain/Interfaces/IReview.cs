namespace RateMyCourse.Domain
{
    using System;

    public interface IReview
    {
        Course Course { get; set; }
        int CourseId { get; set; }
        Student Student { get; set; }
        int StudentId { get; set; }
        DateTime ReviewDate { get; set; }
        int ReviewId { get; set; }
        string ReviewText { get; set; }
        int Stars { get; set; }
    }
}