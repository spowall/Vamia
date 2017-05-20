using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamia.Data;
using Vamia.Data.Repositories;
using Vamia.Domain.Managers;

namespace Vamia.Controllers
{
    public class HomeController : Controller
    {
        private InventoryManager _inventoryManager;
        private DataContext _context;

        public HomeController()
        {
            _context = new DataContext();
            var repo = new InventoryRepository(_context);
            _inventoryManager = new InventoryManager(repo);
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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}