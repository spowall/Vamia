using System;
using System.Collections.Generic;
using System.Linq;
using Vamia.Domain.Interface.Repositories;
using Vamia.Models;

namespace Vamia.Domain.Managers
{
    public class CartManager
    {
        private ICartRepository _cartRepository;
        private IInventoryRepository _inventoryRepository;

        public CartManager(ICartRepository cartRepository, IInventoryRepository inventoryRepository)
        {
            _cartRepository = cartRepository;
            _inventoryRepository = inventoryRepository;
        }

        public List<ItemModel> GetCartItems()
        {
            //validate input
            //check permission
            return _cartRepository.GetCartItems();
        }

        public bool AddCartItem(int productId)
        {
            //Validate Product Id
            var product = _inventoryRepository.FindProduct(productId);
            if (product == null) return false;

            var items = _cartRepository.GetCartItems();
            var cartItem = items.Where(i => i.ProductId == product.ProductId).FirstOrDefault();
            if (cartItem == null)
            {
                items.Add(new ItemModel
                {
                    Product = product,
                    ProductId = productId,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity = cartItem.Quantity + 1;
            }

            _cartRepository.SaveCartItems(items);
            return true;
        }

        public void RemoveCartItem(int productId)
        {
            var items = _cartRepository.GetCartItems();
            var cartItem = items.Where(i => i.ProductId == productId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Quantity = cartItem.Quantity - 1;
                if (cartItem.Quantity >= 0) items.Remove(cartItem);
                _cartRepository.SaveCartItems(items);
            }

            //If Product doesn't exist in cart then do nothing
        }
    }
}
