using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Domain.Models
{
    public class OrderModel: Model
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public virtual ICollection<ItemModel> Items { get; set; } = new HashSet<ItemModel>();
    }
}
