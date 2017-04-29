using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Entities;
using Vamia.Domain.Models;

namespace Vamia.Domain.Repositories
{
    public class InventoryRepository
    {
        private DataContext _context;

        public InventoryRepository(DataContext context)
        {
            _context = context;
        }
        public ProductModel[] GetProducts()
        {
            var query = from product in _context.Products
                        select new ProductModel
                        {
                            Price = product.Amount,
                            Category = product.Category,
                            Description = product.Description,
                            Name = product.Name,
                            ProductId = product.ProductId
                        };

            return query.ToArray();
        }
    }
}
