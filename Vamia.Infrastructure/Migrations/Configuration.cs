namespace Vamia.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Vamia.Infrastructure.Data.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.DataEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Products.AddOrUpdate(p => p.Name, new Data.Product
            {
                Name = "Chessboard",
                Price = 1000,
                Stock = 10,
                Description = "A Cool Chess Set"
            },
            new Data.Product
            {
                Name = "HP Notebook",
                Price = 150000,
                Stock = 7,
                Description = "A HP Ultra Book Laptop"
            },
            new Data.Product
            {
                Name = "PSP",
                Price = 50000,
                Stock = 5,
                Description = "Sony Playstation Portable"
            }, new Data.Product
            {
                Name = "Puma Boot",
                Price = 8000,
                Stock = 25,
                Description = "Puma Football Boots"
            });
        }
    }
}
