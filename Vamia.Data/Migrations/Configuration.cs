namespace Vamia.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Vamia.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Vamia.Data.DataContext context)
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

            //users
            context.Users.AddOrUpdate(u => u.Email, new[] {
                new Entities.User
                {
                    Email = "k@k.com", Password="password"
                },
                new Entities.User
                {
                    Email = "s@s.com", Password="password"
                },
                new Entities.User
                {
                    Email = "a@a.com", Password="password"
                }
                });

            //products
            context.Products.AddOrUpdate(e => e.Name, 
                new[]{
                    new Entities.Product
                    {
                        Amount = 1500000,
                        Category = "Car",
                        Description = "BMW X13",
                        Name = "BMW-1",
                        ProductId = 1,
                        Quantity = 10,
                        PictureURL ="http://tse2.mm.bing.net/th?id=OIP.hKSxCxbItEq1FAQseqwEvgDHBQ&pid=15.1"
                    },
                    new Entities.Product
                    {
                        Amount = 100000,
                        Category = "Car",
                        Description = "Lamborhgini Contach",
                        Name = "Lamborghini-1",
                        ProductId = 2,
                        Quantity = 5,
                        PictureURL="http://tse1.mm.bing.net/th?id=OIP.ysxj5uDy4bJvvLSlMIm_sQCmB1&pid=15.1"
                    }
                    ,
                    new Entities.Product
                    {
                        Amount = 100000,
                        Category = "Soap",
                        Description = "for bathing",
                        Name = "Lux",
                        ProductId = 3,
                        Quantity = 5,
                        PictureURL="http://tse4.mm.bing.net/th?id=OIP.Wd_eppvGV0xTdkue3NStgQEsEs&w=146&h=160&c=7&qlt=90&o=4&pid=1.7"
                    }
                    ,
                    new Entities.Product
                    {
                        Amount = 100000,
                        Category = "Phone",
                        Description = "Best mobile device",
                        Name = "iPhone 6",
                        ProductId = 4,
                        Quantity = 5,
                        PictureURL="http://tse4.mm.bing.net/th?id=OIP.MPT632HiAzLXLxaXCBQ1nwC0C0&w=119&h=150&c=7&qlt=90&o=4&pid=1.7"
                    }
                    ,
                    new Entities.Product
                    {
                        Amount = 100000,
                        Category = "Phone",
                        Description = "Best mobile device",
                        Name = "Samsung Phone",
                        ProductId = 5,
                        Quantity = 5,
                        PictureURL="http://tse4.mm.bing.net/th?id=OIP.DwU8Cw5LHlIZy0pHYipoJwCqCq&w=150&h=150&c=7&qlt=90&o=4&pid=1.7"
                    }
                    ,
                    new Entities.Product
                    {
                        Amount = 100000,
                        Category = "Phone",
                        Description = "Best mobile device",
                        Name = "LG",
                        ProductId = 6,
                        Quantity = 5,
                        PictureURL="http://tse3.mm.bing.net/th?id=OIP.iDmj2BOT6kIC6WjGD92W0wB9C-&w=115&h=160&c=7&qlt=90&o=4&pid=1.7"
                    }
                }
            );

        }
    }
}
