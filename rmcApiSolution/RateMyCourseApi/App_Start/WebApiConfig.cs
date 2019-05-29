namespace RateMyCourseApi
{
    using Newtonsoft.Json.Serialization;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using App_Start;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CoursesRoute",
                routeTemplate: "api/courses/{id}",
                defaults: new { Controller = "course", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "StudentsRoute",
                routeTemplate: "api/students/{id}",
                defaults: new { Controller = "student", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ReviewsRoute",
                routeTemplate: "api/reviews/{id}",
                defaults: new { Controller = "review", id = RouteParameter.Optional }
            );

            var jsonFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
            };
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));           
        }
    }
}
