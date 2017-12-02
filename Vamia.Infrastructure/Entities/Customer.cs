using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Infrastructure.Data
{
    public class Customer
    {
        [Key,ForeignKey("User")]
        public int UserId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        //Relationships
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
