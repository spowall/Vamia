using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;

namespace Vamia.Domain.Managers
{
    public class OrderManager
    {
        private IOrderRepository _repo;

        public OrderManager(IOrderRepository repo)
        {
            _repo = repo;
        }
        public OrderModel PlaceOrder(int userId, ItemModel[] items)
        {
            //Validate Customer
            if (!_repo.UserExists(userId)) throw new Exception("Invalid UserId");

            //Create Customer if not Exists
            var customer = _repo.GetCustomer(userId);

            if(customer == null) customer = _repo.CreateCustomer(userId);

            // Validate Items
            //Make Sure Items are Not Empty
            if (items == null || !items.Any()) throw new Exception("There no Items Supplied");
            //Make Sure there are no negative Quantities
            if(items.Any(i => i.Quantity <= 0)) throw new Exception("Items cannot have Zero or Negative Quantities");


            // Create Order and Add Items to Order
            var order = _repo.CreateOrder(customer.UserId, items);
            return order;
        }
    }
}
