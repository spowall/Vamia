using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Models;
using Vamia.Domain.Repositories;

namespace Vamia.Domain.Managers
{
    public class InventoryManager
    {
        private InventoryRepository _inventory;

        public InventoryManager(InventoryRepository inventory)
        {
            _inventory = inventory;
        }

        public List<ProductModel> GetProducts()
        {
            var products = _inventory.GetProducts();
            return products.ToList();
        }
    }
}
