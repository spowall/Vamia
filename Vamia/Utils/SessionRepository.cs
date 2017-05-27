using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vamia.Domain.Interface.Repositories;
using Vamia.Models;

namespace Vamia.Utils
{
    public class SessionRepository : ICartRepository
    {
        public void Clear()
        {
            SaveCartItems(new List<ItemModel>());
        }

        public List<ItemModel> GetCartItems()
        {
            var cartItems = HttpContext.Current.Session["Cart"] as List<ItemModel>;
            if(cartItems == null)
            {
                cartItems = new List<ItemModel>();
                HttpContext.Current.Session["Cart"] = cartItems;
            }
            return cartItems;
        }

        public void SaveCartItems(List<ItemModel> items)
        {
            if (items == null) throw new ArgumentNullException("Items cannot be null");
            HttpContext.Current.Session["Cart"] = items;
        }
    }
}