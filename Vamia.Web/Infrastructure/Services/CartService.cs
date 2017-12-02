using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vamia.Domain.Models;

namespace Vamia.Web.Infrastructure.Services
{
    public class CartService
    {
        public static string Key = "Cart";

        public List<ItemModel> GetCartItems()
        {
            if (HttpContext.Current.Session[Key] == null)
            {
                HttpContext.Current.Session[Key] = new List<ItemModel>();
            }
            return HttpContext.Current.Session[Key] as List<ItemModel>;
        }

        public void AddToCart(ProductModel product)
        {
            var items = GetCartItems();
            var cartItem = items.FirstOrDefault(i => i.ProductId == product.ProductId);
            if(cartItem == null)
            {
                items.Add(new ItemModel
                {
                    ProductId = product.ProductId,
                    Product = product,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity += 1;
            }


            SaveCart(items);
        }

        private void SaveCart(List<ItemModel> items)
        {
            HttpContext.Current.Session[Key] = items;
        }

        public void RemoveFromCart(int productId)
        {
            var items = GetCartItems();
            var cartItem = items.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem != null)
            {
                if( cartItem.Quantity > 1)
                {
                    cartItem.Quantity -= 1;
                }
                else
                {
                    items.Remove(cartItem);
                }
            }

            SaveCart(items);
        }

        public void ClearCart()
        {
            SaveCart(new List<ItemModel>());
        }
    }
}