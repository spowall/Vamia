using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vamia.Models;

namespace Vamia.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel{
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            
            if (ModelState.IsValid)
            {                
                //make a call to db or webservice
                if (model.Username=="admin@admin.com" && model.Password == "123456")
                {
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Email, model.Username),
                        new Claim("streetno", "no 33")
                        }, "ApplicationCookie");

                    //perform authentication
                    var context = Request.GetOwinContext();
                    var authmanager = context.Authentication;

                    //login
                    authmanager.SignIn(identity);

                    var returnstring = GetRedirectUrl(model.ReturnUrl);
                    return Redirect(returnstring);
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authmanager = context.Authentication;
            authmanager.SignOut("ApplicationCookie");

            return Redirect(Url.Action("index", "home"));
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}