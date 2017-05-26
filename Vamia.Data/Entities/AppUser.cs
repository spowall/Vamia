using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public int UserId { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
    }
}
