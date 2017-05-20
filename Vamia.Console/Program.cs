using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Data;
using Vamia.Data.Repositories;
using Vamia.Domain;
using Vamia.Domain.Managers;
using Vamia.Models;
using static System.Console;

namespace Vamia.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                var inventoryRepo = new InventoryRepository(context);
                var cartRepo = new InMemoryCartRepository();

                //define business manager and repository
                var inventoryManager = new InventoryManager(inventoryRepo);
                var cartManager = new CartManager(cartRepo, inventoryRepo);

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

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:
                            //List Products
                            var products = inventoryManager.GetProducts();
                            WriteLine("================ INVENTORY ==================");
                            foreach (var prod in products)
                            {
                                WriteLine($"{prod.ProductId} - {prod.Name} {prod.Price}");
                            }
                            break;
                        case ConsoleKey.D2:
                            //Display Cart Items
                            var items = cartManager.GetCartItems();
                            if (items.Any())
                            {
                                WriteLine("================ CART ==================");
                                foreach (var item in items)
                                {
                                    WriteLine($"{item.Quantity} - {item.Product.Name} {item.Product.Price}");
                                }
                            }
                            else
                            {
                                WriteLine($"No cart item for user Please add item");
                            }
                            break;

                        case ConsoleKey.D3:
                            //Add Item to Cart
                            WriteLine("Specify the Product id"); //get userid
                            string id = ReadLine();
                            var productId = int.Parse(id);
                            bool result = cartManager.AddCartItem(productId);
                            if (result)
                            {
                                WriteLine("item added to cart");
                            }
                            else
                            {
                                WriteLine("invalid data or error occurred");
                            }
                            break;
                    }

                    WriteLine(Environment.NewLine);
                } while (keyPressed.Key != ConsoleKey.Q);

            }
        }
    }
}
