using System;
using System.Collections.Generic;
using RateMyCourse.Domain;

namespace RateMyCourse.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CourseViewModel : BaseViewModel
    {
        public int CourseId { get; set; }

        [Display(Name = "Course Code")]
        [MaxLength(10, ErrorMessage = "Maximum Course Code Length is 10 characters")]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Course Name")]
        [MaxLength(50, ErrorMessage = "Maximum Course Name Length is 50 characters")]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public bool canDelete { get; set; }
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
