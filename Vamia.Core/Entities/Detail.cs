using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Core.Entities
{
    public class Detail
    {
        public int DetailID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
