using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vamia.Domain.Managers;
using Vamia.Models;

namespace Vamia.Services.Controllers
{
    public class ProductsController : ApiController
    {
        private InventoryManager _inventoryManager;

        public ProductsController()
        {
            _inventoryManager = new InventoryManager();
        }

        // GET: api/Products
        public IEnumerable<ProductModel> Get()
        {
            return _inventoryManager.GetProducts();
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
