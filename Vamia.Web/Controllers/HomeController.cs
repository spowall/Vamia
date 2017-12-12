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

        public HomeController()
        {
            var productRepo = new ProductRepository(new DataEntities());
            _product = new ProductManager(productRepo);

            _cart = new CartService();
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
    }
}