using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamia.Domain.Managers;
using Vamia.Infrastructure.Entities;
using Vamia.Infrastructure.Repositories;
using Vamia.Web.Infrastructure.Services;

namespace Vamia.Web.Controllers
{
    public class CartController : Controller
    {
        private ProductManager _product;
        private CartService _cart;

        public CartController()
        {
            var productRepo = new ProductRepository(new DataEntities());
            _product = new ProductManager(productRepo);
            _cart = new CartService();
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int id = 0)
        {
            try
            {
                var product = _product.GetProduct(id);
                _cart.AddToCart(product);
            }
            catch(Exception ex)
            {
                Error(ex.Message);
            }

            return RedirectToAction("index", "home");
        }

        public void Error(string message)
        {
            TempData["message"] = message;
        }
        public ActionResult Remove(int id = 0)
        {
            try
            {
                _cart.RemoveFromCart(id);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }

            return RedirectToAction("index", "home");
        }
    }
}