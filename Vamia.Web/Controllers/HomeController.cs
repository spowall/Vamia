using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamia.Domain.Managers;
using Vamia.Infrastructure.Entities;
using Vamia.Infrastructure.Repositories;
using Vamia.Web.Infrastructure.Services;
using Vamia.Web.Models;

namespace Vamia.Web.Controllers
{
    public class HomeController : Controller
    {
        private ProductManager _product;
        private CartService _cart;

        public HomeController(ProductManager product, CartService cart)
        {
            _product = product;
            _cart = cart;
        }
        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                Inventory = _product.GetInventory(),
                Cart = _cart.GetCartItems()
            };
            return View(model);
        }

        public ActionResult ActionA()
        {
            return RedirectToAction("ActionB", new { id = 2, type = "z" });
        }

        public ActionResult ActionB(string type, int id = 0)
        {
            return Content($"Id = {id} and type = {type}");
        }
    }
}