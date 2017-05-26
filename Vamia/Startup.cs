using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vamia.Data;
using Vamia.Data.Entities;

namespace Vamia
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/auth/login")
            });

            UserManagerFactory = () =>
             {
                 var usermanager = new UserManager<AppUser>(new UserStore<AppUser>(new DataContext()));
                 usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
                 {
                     AllowOnlyAlphanumericUserNames = false
                 };
                 return usermanager;
             };

        }
    }
}