namespace RateMyCourse.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }

        [Display(Name = "Review Text")]
        [MaxLength(500, ErrorMessage = "Maximum Review Text is 500 characters")]
        public string ReviewText { get; set; }

        public int  Stars { get; set; }

        public int CourseId { get; set; }

        public CourseViewModel Course { get; set; }
        public int StudentId { get; set; }

        public StudentViewModel Student { get; set; }
    }
}
