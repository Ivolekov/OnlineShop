[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineStorePlatform.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineStorePlatform.Web.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineStorePlatform.Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Service.Interfaces;
    using Service;
    using Data.Interfaces;
    using Data;

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
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAdminmanagerService>().To<AdminmanagerService>();
            kernel.Bind<IAdminService>().To<AdminService>();
            kernel.Bind<IBlogService>().To<BlogService>();
            kernel.Bind<ICartService>().To<CartService>();
            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<ILogService>().To<LogService>();
            kernel.Bind<INavService>().To<NavService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IOnlineStoreDbContext>().To<OnlineStorePlatformContext>();
            kernel.Bind<IOnlineStoreData>().To<OnlineStoreData>();
        }        
    }
}
