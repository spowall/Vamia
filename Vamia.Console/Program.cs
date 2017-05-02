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

                ConsoleKeyInfo keyPressed = default(ConsoleKeyInfo);
                do
                {
                    WriteLine("1 - List Products");
                    WriteLine("2 - Display Cart Items");
                    WriteLine("3 - Add Item to Cart");
                    WriteLine("4 - Place Order");
                    WriteLine("Press Command.. Q to exit");

                    keyPressed = ReadKey();
                    WriteLine("");

                    switch (keyPressed.Key){
                        case ConsoleKey.D1:
                            var products = manager.GetProducts();
                            foreach (var product in products)
                            {
                                WriteLine($"{product.Name} {product.Price}");
                            }
                            break;
                        case ConsoleKey.D2:

                            break;
                    }
                } while (keyPressed.Key != ConsoleKey.Q);
                
            }
        }
    }
}
