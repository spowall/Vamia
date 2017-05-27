using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Data.Entities;
using Vamia.Domain.Interface.Repositories;
using Vamia.Models;

namespace Vamia.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public UserModel FetchUserById(string userId)
        {
            var query = from user in _context.AppUsers
                        where user.Id == userId
                        select new UserModel
                        {
                            Email = user.Email,
                            UserId = user.Id
                        };
            return query.FirstOrDefault();
        }

        public OrderModel SaveOrder(OrderModel model)
        {
			//Create Order Record
            var order = new Order
            {
                UserId = model.UserId,
                Delivery = model.DeliveryDate,
            };


			//Go Through the Items and Create Records for them too
            foreach (var modelItem in model.Items)
            {
                var item = new OrderItem
                {
                    ProductId = modelItem.ProductId,
                    Quantity = modelItem.Quantity,
                };

				//Add Item Record to Order Record
                order.Items.Add(item);
            }


			//Add Order to Database
            _context.Orders.Add(order);


			//Save Changes
            _context.SaveChanges();

			//Update Model OrderId with Record OrderId
            model.OrderId = order.OrderId;


			//Return Order
            return model;
        }
    }
}
