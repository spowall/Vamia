using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Data.Entities;
using Vamia.Models;

namespace Vamia.Data.Repositories
{
    public class CartRepository
    {
        private DataContext _context;

        public CartRepository()
        {
            _context = new DataContext();
        }

        public CartRepository(DataContext context)
        {
            _context = context;
        }

        public CartModel GetCart(int userid)
        {
            var query = from cart in _context.CartItems
                        //join product in _context.Products on cart.ProductId equals product.ProductId
                        where cart.UserId == userid
                        group cart by cart.UserId into cartgroups
                        select new CartModel
                        {
                            UserId = cartgroups.Key,
                            Items = (from item in cartgroups
                                    select new ItemModel
                                    {
                                        Product = new ProductModel
                                        {
                                            Name = item.Product.Name,
                                            Description = item.Product.Description,
                                            Category = item.Product.Category,
                                            Price = item.Product.Amount
                                        }
                                    }).ToList()
                        };

            return query.FirstOrDefault();
        }

        public bool AddCartItem(CartModel cartmodel)
        {
            foreach (var item in cartmodel.Items)
            {
                CartItem cartitem = new CartItem();
                cartitem.UserId = cartmodel.UserId;
                cartitem.ProductId = item.ProductId;

                _context.CartItems.Add(cartitem);
            }

            int result = _context.SaveChanges();
            return result > 0 ? true : false;
        }
    }
}

