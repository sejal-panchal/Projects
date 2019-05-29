namespace RateMyCourse.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class StudentViewModel : BaseViewModel
    {
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        [MaxLength(30, ErrorMessage ="Maximum name is 30 characters")]
        [Required]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum city is 30 characters")]
        public string City { get; set; }

        [Display(Name = "Home Phone")]
        [MaxLength(16, ErrorMessage = "Maximum phone length is 16 characters")]
        public string PhoneNumber { get; set; }
        public ICollection<ReviewViewModel> Reviews { get; set; }
        public ICollection<CourseViewModel> Courses { get; set; }
    }
}
