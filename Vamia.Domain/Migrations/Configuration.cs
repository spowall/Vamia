namespace Vamia.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Vamia.Domain.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Vamia.Domain.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(e => e.Name, 
                new[]{
                    new Entities.Product
                    {
                        Amount = 1500000,
                        Category = "Car",
                        Description = "BMW X13",
                        Name = "BMW-1",
                        ProductId = 1,
                        Quantity = 10
                    },
                    new Entities.Product
                    {
                        Amount = 100000,
                        Category = "Car",
                        Description = "Lamborhgini Contach",
                        Name = "Lamborghini-1",
                        ProductId = 2,
                        Quantity = 5,
                    }
                }
            );
        }
    }
}
