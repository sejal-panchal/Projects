
namespace RateMyCourseApi.Controllers
{
    using RateMyCourse.Services;
    using RateMyCourse.ViewModels;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Route("")]
        public IEnumerable<CourseViewModel> Get()
        {
            return _courseService.GetAll();
        }


        // Note: To override the routeprefix - ie. Get with id
        // [Route("~/api/course/{id}")]
        [Route("{id}")]
        public CourseViewModel Get(int id)
        {
            return _courseService.Get(id);
        }

        [Route("{id}/reviews")]
        public IEnumerable<ReviewViewModel> GetReviews(int id)
        {
            return _courseService.Get(id).Reviews;
        }

        [Route("{id}/students")]
        public IEnumerable<StudentViewModel> GetStudents(int id)
        {
            return _courseService.Get(id).Students;
        }

        [Route("add")]
        public void Post(CourseViewModel course)
        {
            _courseService.Add(course);
            _courseService.SaveChanges();
        }

        [Route("update")]
        public void Put(CourseViewModel course)
        {
            _courseService.Update(course);
            _courseService.SaveChanges();
        }

        [Route("remove/{id}")]
        public void Delete(int id)
        {
            _courseService.Remove(id);
            _courseService.SaveChanges();
        }
    }
}
