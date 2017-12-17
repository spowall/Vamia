using System.Web.Routing;
using Vamia.Web.Infrastructure;

namespace Vamia.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseMigrator.UpdateDatabase();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
