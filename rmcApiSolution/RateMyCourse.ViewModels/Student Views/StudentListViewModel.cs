using RateMyCourse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyCourse.ViewModels
{
    public class StudentListViewModel
    {

        public string PageTitle { get; set; }
        public int TotalStudents { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }

    }
}
