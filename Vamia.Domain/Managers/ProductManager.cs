using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;

namespace Vamia.Domain.Managers
{
    public class ProductManager
    {
        private IProductRepository _product;

        public ProductManager(IProductRepository product)
        {
            _product = product;
        }

        /// <summary>
        /// This returns all the Products that are currently in stock
        /// </summary>
        /// <returns>Array of Products</returns>
        public ProductModel[] GetInventory()
        {
            return _product.GetProductsInStock();
        }

        public ProductModel GetProduct(int productId)
        {
            return _product.GetProductsById(productId);
        }
    }
}
