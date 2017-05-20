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
    public class ProductController : Controller
    {
        private InventoryManager _inventory;
        private DataContext _context;

        public ProductController()
        {
            _context = new DataContext();
            var inventoryRepo = new InventoryRepository(_context);
            _inventory = new InventoryManager(inventoryRepo);
        }

        // GET: Product
        public ActionResult Details(int id = 0)
        {
            var product = _inventory.FindProduct(id);
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}