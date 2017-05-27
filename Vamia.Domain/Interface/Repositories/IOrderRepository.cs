using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Models;

namespace Vamia.Domain.Interface.Repositories
{
    public interface IOrderRepository
    {
        UserModel FetchUserById(string userId);
        OrderModel SaveOrder(OrderModel order);
    }
}
