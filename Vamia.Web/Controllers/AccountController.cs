using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vamia.Domain.Managers;
using Vamia.Domain.Models;
using Vamia.Infrastructure.Entities;
using Vamia.Infrastructure.Repositories;
using Vamia.Infrastructure.Utilities;
using Vamia.Web.Models;

namespace Vamia.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager _user;

        public AccountController(UserManager user)
        {
            _user = user;
        }

        // GET: Account
        public ActionResult Login()
        {
            Authentication.SignOut();
            return View();
        }

        public IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _user.Login(model.Email, model.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,user.Email),    //Email
                        new Claim(ClaimTypes.Name, user.Email),    //UserName
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),  //UserID
                    };

                    //Check to see if User is a Customer
                    var roleClaims = user.Roles.Select(r => new Claim(ClaimTypes.Role, r));

                    claims.AddRange(roleClaims);

                    var identity = new ClaimsIdentity(claims, Constants.Authentication.Type);


                    //Sign In the User based on the Identity created
                    var property = new AuthenticationProperties { IsPersistent = model.RememberMe };
                    Authentication.SignIn(property, identity);


                    //Redirect User Back
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("index", "home");
                }
            }

            ModelState.AddModelError("Invalid Login", "Invalid Username or Password");
            return View(model);
        }

        public ActionResult Logout()
        {
            Authentication.SignOut();
            return RedirectToAction("index","home");
        }

        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new UserModel
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                    };

                    //Register User
                    _user.RegisterUser(user, model.Password);

                    //Return to Login Page
                    return RedirectToAction("login");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("RegistrationError", ex);
                }
            }
            return View(model);
        }
    }
}