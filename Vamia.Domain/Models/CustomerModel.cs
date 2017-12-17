using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Domain.Models
{
    public class CustomerModel: UserModel
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderModel> Orders { get; set; } = new HashSet<OrderModel>();
    }
}
