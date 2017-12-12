using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vamia.Domain.Managers;
using Vamia.Infrastructure.Entities;
using Vamia.Infrastructure.Repositories;
using Vamia.Web.Models;

namespace Vamia.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager _user;

        public AccountController()
        {
            _user = new UserManager(new UserRepository(new DataEntities()));
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _user.Login(model.Email, model.Password);
                if (user != null)
                {
                    var auth = HttpContext.GetOwinContext().Authentication;

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
                    auth.SignIn(property, identity);


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
    }
}