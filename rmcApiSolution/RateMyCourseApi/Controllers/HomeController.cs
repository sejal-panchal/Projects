using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyCourse.Services;

namespace RateMyCourseApi.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ICourseService cs, IStudentService ss, IReviewService rs)
        {
            var courses = cs.GetAll();

        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
