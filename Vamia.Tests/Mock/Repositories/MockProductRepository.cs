using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;

namespace Vamia.Tests.Mock.Repositories
{
    class MockProductRepository : IProductRepository
    {
        public ProductModel GetProductsById(int productId)
        {
            return GetProductsInStock().FirstOrDefault(p => p.ProductId == productId);
        }

        public ProductModel[] GetProductsInStock()
        {
            return new[]
            {
                new ProductModel
                {
                    Name = "Chessboard",
                    Price = 1000,
                    Stock = 10,
                    ProductId = 1,
                    Description = "A Cool Chess Set"
                }
            };
        }
    }
}
