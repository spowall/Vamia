using Ninject.Mvc;
using System.Web.Routing;
using Vamia.Web.Infrastructure;
using Vamia.Web.Infrastructure.Modules;

namespace Vamia.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            NinjectContainer.RegisterAssembly();
            DatabaseMigrator.UpdateDatabase();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
