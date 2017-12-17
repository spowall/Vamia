using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Models;

namespace Vamia.Domain.Interface.Repositories
{
    public interface IOrderRepository
    {
        OrderModel CreateOrder(int userId, ItemModel[] items);
        CustomerModel GetCustomer(int userId);
        bool UserExists(int userId);
        //Creates blank customer record
        CustomerModel CreateCustomer(int customerId);
    }
}
