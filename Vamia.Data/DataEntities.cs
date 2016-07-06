using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Core.Entities;

namespace Vamia.Data
{
    public class DataEntities: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
