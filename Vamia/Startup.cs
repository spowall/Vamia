using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vamia
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/auth/login")
            });
        }
    }
}