using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Models;

namespace Vamia.Domain.Managers
{
    public class OrderManager
    {
        private IOrderRepository _repo;

        public OrderManager(IOrderRepository repo)
        {
            _repo = repo;
        }
        public OrderModel Order(UserModel user, List<ItemModel> items)
        {
            //Validate User
            var dbUser = _repo.FetchUserById(user.UserId);
            if (dbUser == null) throw new Exception("Invalid UserId");

            //Validate Items
            if (items == null || !items.Any()) throw new Exception("No Items in Order");

            //Create Order
            var order = new OrderModel
            {
                DeliveryDate = DateTime.Now.AddDays(2),
                Items = items
            };

            //Save Order
            var savedOrder = _repo.SaveOrder(order);

            //Return new Order
            return savedOrder;
        }
    }
}
