using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamia.Domain.Managers;

namespace Vamia.Controllers
{
    public class ProductController : Controller
    {
        private InventoryManager _inventory;

        public ProductController()
        {
            _inventory = new InventoryManager();
        }

        // GET: Product
        public ActionResult Details(int id = 0)
        {
            var product = _inventory.FindProduct(id);
            return View(product);
        }
    }
}