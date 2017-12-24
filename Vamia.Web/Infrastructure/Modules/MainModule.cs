using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Interface.Utility;
using Vamia.Infrastructure.Entities;
using Vamia.Infrastructure.Repositories;
using Vamia.Infrastructure.Utilities;

namespace Vamia.Web.Infrastructure.Modules
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncryption>().To<MD5Encryption>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<DbContext>().To<DataEntities>().InRequestScope();
        }
    }
}