using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain;
using Vamia.Domain.Entities;
using Vamia.Domain.Managers;
using Vamia.Domain.Repositories;
using static System.Console;

namespace Vamia.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                var repo = new InventoryRepository(context);
                var manager = new InventoryManager(repo);


                WriteLine("1 - List Products");
                WriteLine("Press Command");

                var keyPressed = ReadKey();
                if(keyPressed.Key == ConsoleKey.D1)
                {
                    var products = manager.GetProducts();
                    foreach(var product in products)
                    {
                        WriteLine($"{product.Name} {product.Price}");
                    }
                }
            }
        }
    }
}
