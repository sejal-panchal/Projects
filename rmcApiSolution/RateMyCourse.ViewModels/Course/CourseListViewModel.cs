using RateMyCourse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyCourse.ViewModels
{
    public class CourseListViewModel
    {
        public string PageTitle { get; set; }
        public int TotalCourses { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
