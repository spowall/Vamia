namespace Vamia.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Entities.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Entities.DataEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Products.AddOrUpdate(p => p.Name, new Entities.Product
            {
                Name = "Chessboard",
                Price = 1000,
                Stock = 10,
                Description = "A Cool Chess Set"
            },
            new Entities.Product
            {
                Name = "HP Notebook",
                Price = 150000,
                Stock = 7,
                Description = "A HP Ultra Book Laptop"
            },
            new Entities.Product
            {
                Name = "PSP",
                Price = 50000,
                Stock = 5,
                Description = "Sony Playstation Portable"
            }, new Entities.Product
            {
                Name = "Puma Boot",
                Price = 8000,
                Stock = 25,
                Description = "Puma Football Boots"
            });

            context.Roles.AddOrUpdate(r => r.Name, new Entities.Role
            {
                Name = "Admin"
            },
            new Entities.Role
            {
                Name = "Customer"
            });

        }
    }
}
