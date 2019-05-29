[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RateMyCourse.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RateMyCourse.Web.App_Start.NinjectWebCommon), "Stop")]

namespace RateMyCourse.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Domain;
    using Data;
    using Services;
    using Ninject.Web.Common.WebHost;
    using System.Web.Http;
    using Ninject.Web.WebApi;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();


                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Repository
            kernel.Bind<DataContext>().ToSelf().InRequestScope();
            kernel.Bind<IStudentRepository>().To<StudentRepository>().InRequestScope();
            kernel.Bind<ICourseRepository>().To<CourseRepository>().InRequestScope();
            kernel.Bind<IReviewRepository>().To<ReviewRepository>().InRequestScope();

            // services
            kernel.Bind<IStudentService>().To<StudentService>().InRequestScope();
            kernel.Bind<ICourseService>().To<CourseService>().InRequestScope();
            kernel.Bind<IReviewService>().To<ReviewService>().InRequestScope();
        }
    }
}
