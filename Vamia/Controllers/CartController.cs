using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamia.Data;
using Vamia.Data.Repositories;
using Vamia.Domain.Managers;
using Vamia.Utils;

namespace Vamia.Controllers
{
    public class CartController : Controller
    {
        private DataContext _context;
        private CartManager _cartManager;

        public CartController()
        {
            _context = new DataContext();
            var cartRepo = new SessionRepository();
            var inventoryRepo = new InventoryRepository(_context);
            _cartManager = new CartManager(cartRepo, inventoryRepo);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var items = _cartManager.GetCartItems();
            return View(items);
        }

        public ActionResult Add(int id = 0)
        {
            //Add to Cart
            _cartManager.AddCartItem(id);

            //Redirect back to Index
            return RedirectToAction("index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}