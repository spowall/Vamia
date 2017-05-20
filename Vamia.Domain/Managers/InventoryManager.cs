using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Models;
using Vamia.Domain.Interface.Repositories;

namespace Vamia.Domain.Managers
{
    public class InventoryManager
    {
        private IInventoryRepository _inventory;

        public InventoryManager(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }

        public ProductModel FindProduct(int id)
        {
            return _inventory.FindProduct(id);
        }

        public List<ProductModel> GetProducts()
        {
            var products = _inventory.GetProducts();
            return products.ToList();
        }

        public List<ProductModel> Find(string search)
        {
            var products = _inventory.FindProduct(search);
            return products.ToList();
        }
    }
}
