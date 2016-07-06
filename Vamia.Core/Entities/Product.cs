using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Core.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string  Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Detail> Details { get; set; } = new HashSet<Detail>();
    }
}
