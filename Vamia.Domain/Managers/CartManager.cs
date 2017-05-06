using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Data;
using Vamia.Data.Entities;
using Vamia.Data.Repositories;
using Vamia.Models;

namespace Vamia.Domain.Managers
{
    public class CartManager
    {
        private CartRepository _cartRepository;

        public CartManager()
        {
            DataContext context = new DataContext();
            _cartRepository = new CartRepository();
        }

        public CartManager(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public CartModel GetCart(int userid)
        {
            //validate input
            //check permission
            return _cartRepository.GetCart(userid);
        }

        public bool AddCartItem(CartModel cartmodel)
        {
            //validate input
            //check permission
            return _cartRepository.AddCartItem(cartmodel);
        }
    }
}
