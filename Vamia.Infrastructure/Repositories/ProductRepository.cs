using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;
using Vamia.Infrastructure.Data;

namespace Vamia.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public ProductModel GetProductsById(int productId)
        {
            //Query for product and its images
            var query = from product in _context.Set<Product>()
                        where product.ProductId == productId
                        select new
                        {
                            Product = product,
                            Images = product.Images
                        };
            //Return record from Database
            var record = query.FirstOrDefault();
            if (record == null) throw new Exception("Invalid Product Id");

            var images = from image in record.Images
                         select new ImageModel
                         {
                             ImageId = image.ImageId,
                             ProductId = image.ProductId,
                             Url = image.Url
                         };

            var model = new ProductModel
            {
                Description = record.Product.Description,
                Name = record.Product.Name,
                Price = record.Product.Price,
                ProductId = record.Product.ProductId,
                Stock = record.Product.Stock,
                Images = images.ToArray()
            };

            return model;
        }

        /// <summary>
        /// Gets Products with Stock greater than Zero
        /// </summary>
        /// <returns></returns>
        public ProductModel[] GetProductsInStock()
        {
            //Query for each product and its images
            var query = from product in _context.Set<Product>()
                        where product.Stock > 0
                        select new
                        {
                            Product = product,
                            Images = product.Images
                        };
            //Return records from Database
            var records = query.ToArray();


            //Transform the Data
            var products = from record in records
                           let images = from image in record.Images
                                        select new ImageModel
                                        {
                                            ImageId = image.ImageId,
                                            ProductId = image.ProductId,
                                            Url = image.Url
                                        }
                           select new ProductModel
                           {
                               Description = record.Product.Description,
                               Name = record.Product.Name,
                               Price = record.Product.Price,
                               ProductId = record.Product.ProductId,
                               Stock = record.Product.Stock,
                               Images = images.ToArray()
                           };

            return products.ToArray();
        }
    }
}
