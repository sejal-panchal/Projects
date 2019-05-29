
namespace RateMyCourseApi.Controllers
{
    using RateMyCourse.ViewModels;
    using RateMyCourse.Services;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Route("")]
        public IEnumerable<ReviewViewModel> Get()
        {
            return _reviewService.GetAll();
        }

        [Route("{id}")]
        public ReviewViewModel Get(int id)
        {
            return _reviewService.Get(id);
        }

        [Route("{id}/course")]
        public CourseViewModel GetCourse(int id)
        {
            return _reviewService.Get(id).Course;
        }

        [Route("{id}/student")]
        public StudentViewModel GetStudent(int id)
        {
            return _reviewService.Get(id).Student;
        }

        [Route("add")]
        public void Post(ReviewViewModel review)
        {
            _reviewService.Add(review);
            _reviewService.SaveChanges();
        }

        [Route("update")]
        public void Put(ReviewViewModel review)
        {
            _reviewService.Update(review);
            _reviewService.SaveChanges();
        }

        [Route("remove/{id}")]
        public void Delete(int id)
        {
            _reviewService.Remove(id);
            _reviewService.SaveChanges();
        }
    }
}