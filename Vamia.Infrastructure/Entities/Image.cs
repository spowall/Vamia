using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Infrastructure.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
