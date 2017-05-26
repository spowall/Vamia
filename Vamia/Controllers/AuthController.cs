using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vamia.Data.Entities;
using Vamia.Models;

namespace Vamia.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController():this(Startup.UserManagerFactory.Invoke()) { }

        public AuthController(UserManager<AppUser> usermanager)
        {
            _userManager = usermanager;
        }

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
                var user = _userManager.Find(model.Username, model.Password);

                if (user != null)
                {
                    SignIn(user);

                    var returnstring = GetRedirectUrl(model.ReturnUrl);
                    return Redirect(returnstring);
                }
            }

            return View(model);
        }

        private void SignIn(AppUser user)
        {
            /*var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Email, model.Username),
                        new Claim("streetno", "no 33")
                        }, "ApplicationCookie");*/
            var identity = _userManager.CreateIdentity(user, "ApplicationCookie");

            //perform authentication
            var context = Request.GetOwinContext();
            var authmanager = context.Authentication;

            //login
            authmanager.SignIn(identity);
        }

        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authmanager = context.Authentication;
            authmanager.SignOut("ApplicationCookie");

            return Redirect(Url.Action("index", "home"));
        }

        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            var model = new RegisterModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var user = new AppUser();
            user.Email = model.Email;
            user.Password = model.Password;
            user.UserName = model.Email;

            var result = _userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                //sign in the user
                SignIn(user);

                //redirect user
                var returnstring = GetRedirectUrl(model.ReturnUrl);
                return Redirect(returnstring);
            }

            return View(model);
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