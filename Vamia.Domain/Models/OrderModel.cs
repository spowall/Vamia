using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Domain.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime DeliveryDate { get; set; }

        public List<ItemModel> Items { get; set; } = new List<ItemModel>();

    }
}
