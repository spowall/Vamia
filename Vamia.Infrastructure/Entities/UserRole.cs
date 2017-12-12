using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Infrastructure.Entities;

namespace Vamia.Infrastructure.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
