using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Data.Entities;
using Vamia.Domain.Interface.Repositories;
using Vamia.Models;

namespace Vamia.Data.Repositories
{
    public class InventoryRepository: IInventoryRepository
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
                            ProductId = product.ProductId,
                            PictureURL = product.PictureURL
                        };

            return query.ToArray();
        }

        public ProductModel FindProduct(int id)
        {
            var query = from product in _context.Products
                        where product.ProductId == id
                        select new ProductModel
                        {
                            Price = product.Amount,
                            Category = product.Category,
                            Description = product.Description,
                            Name = product.Name,
                            ProductId = product.ProductId,
                            PictureURL = product.PictureURL
                        };

            return query.FirstOrDefault();
        }

        public ProductModel[] FindProduct(string search)
        {
            var query = from product in _context.Products
                        where product.Name.Contains(search)
                        || product.Description.Contains(search)
                        || product.Category.Contains(search)
                        select new ProductModel
                        {
                            Price = product.Amount,
                            Category = product.Category,
                            Description = product.Description,
                            Name = product.Name,
                            ProductId = product.ProductId,
                            PictureURL = product.PictureURL
                        };

            return query.ToArray();
        }
    }
}
