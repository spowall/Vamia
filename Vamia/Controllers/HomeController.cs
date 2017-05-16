using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamia.Domain.Managers;

namespace Vamia.Controllers
{
    public class HomeController : Controller
    {
        private InventoryManager _inventoryManager;

        public HomeController()
        {
            _inventoryManager = new InventoryManager();
        }

        // GET: Home
        public ActionResult Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                var products = _inventoryManager.GetProducts();
                return View(products);
            }
            else
            {
                var products = _inventoryManager.Find(search);
                return View(products);
            }
        }
    }
}