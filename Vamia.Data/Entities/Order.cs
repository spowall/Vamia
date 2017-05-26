using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Data.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime Delivery { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
        
    }
}
