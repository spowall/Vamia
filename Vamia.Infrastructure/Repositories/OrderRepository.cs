using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;
using Vamia.Infrastructure.Entities;

namespace Vamia.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DbContext _context;

        public OrderRepository(DbContext context)
        {
            _context = context;
        }

        public CustomerModel CreateCustomer(int userId)
        {
            var customer = new Customer
            {
                UserId = userId
            };
            _context.Set<Customer>().Add(customer);

            _context.SaveChanges();

            var model = new CustomerModel
            {
                UserId = customer.UserId
            };
            return model;
        }

        public OrderModel CreateOrder(int userId, ItemModel[] items)
        {
            if (userId <= 0) throw new Exception("Invalid UserId");

            //Create Order
            var order = new Order
            {
                DateCreated = DateTime.Now,
                DeliveryDate = null,
                UserId = userId
            };
            //Add Items to Order
            foreach (var item in items)
            {
                order.Items.Add(new Item
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }

            //Add Order to context
            _context.Set<Order>().Add(order);
            //Save Order
            _context.SaveChanges();

            var model = new OrderModel
            {
                DateCreated = order.DateCreated,
                DeliveryDate = order.DeliveryDate,
                OrderId = order.OrderId,
                UserId = order.UserId,
                Items = items
            };
            return model;
        }

        public CustomerModel GetCustomer(int userId)
        {
            //Retrieve Customer Record
            var query = from customer in _context.Set<Customer>()
                        where customer.UserId == userId
                        select new CustomerModel
                        {
                            Address = customer.Address,
                            Email = customer.User.Email,
                            FirstName = customer.User.FirstName,
                            Image = customer.User.Image,
                            LastName = customer.User.LastName,
                            PhoneNumber = customer.PhoneNumber,
                            UserId = customer.UserId,
                        };
            return query.FirstOrDefault();
        }

        public bool UserExists(int userId)
        {
            var user = _context.Set<User>().Find(userId);
            var exists = user != null;
            return exists;
        }
    }
}
