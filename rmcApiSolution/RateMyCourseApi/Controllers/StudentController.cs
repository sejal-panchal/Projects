namespace RateMyCourseApi.Controllers
{
    using RateMyCourse.Services;
    using System.Collections.Generic;
    using System.Web.Http;
    using RateMyCourse.ViewModels;

    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("")]
        public IEnumerable<StudentViewModel> Get()
        {
            return _studentService.GetAll();
        }

        [Route("{id}")]
        public StudentViewModel Get(int id)
        {
            return _studentService.Get(id);
        }

        [Route("{id}/courses")]
        public IEnumerable<CourseViewModel> GetCourses(int id)
        {
            return _studentService.Get(id).Courses;
        }

        [Route("{id}/reviews")]
        public IEnumerable<ReviewViewModel> GetReviews(int id)
        {
            return _studentService.Get(id).Reviews;
        }

        [Route("add")]
        public void Post(StudentViewModel student)
        {
            _studentService.Add(student);
            _studentService.SaveChanges();
        }

        [Route("update")]
        public void Put(StudentViewModel student)
        {
            _studentService.Update(student);
            _studentService.SaveChanges();
        }

        [Route("remove/{id}")]
        public void Delete(int id)
        {
            _studentService.Remove(id);
            _studentService.SaveChanges();
        }
    }
}