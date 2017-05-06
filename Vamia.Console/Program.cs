using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //define business manager and repository
            var inventoryManager = new InventoryManager();
            var cartManager = new CartManager();

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
                        var products = inventoryManager.GetProducts();
                        foreach (var product in products)
                        {
                            WriteLine($"{product.Name} {product.Price}");
                        }
                        break;
                    case ConsoleKey.D2:
                        WriteLine("Type your userid:");
                        string input = ReadLine();
                        int userid = int.Parse(input);
                        //call the business manager
                        var cart = cartManager.GetCart(userid);
                        if ( cart != null)
                        {
                            WriteLine($"cart item for user {userid}");
                            foreach (var item in cart.Items)
                            {
                                WriteLine($"{item.Product.Name} {item.Product.Price}");
                            }
                        }
                        else
                        {
                            WriteLine($"No cart item for user {userid}. Please add item");
                        }
                        break;

                    case ConsoleKey.D3:
                        WriteLine("Specify your user id"); //get userid
                        string id = ReadLine();
                        userid = int.Parse(id);
                        WriteLine("Specify your product id");
                        string productinput = ReadLine();
                        int productid = int.Parse(productinput);

                        //create cartitem object
                        CartModel cartmodel = new CartModel();
                        cartmodel.UserId = userid;
                        cartmodel.Items.Add(new ItemModel
                        {
                            ProductId = productid
                        });

                        bool result = cartManager.AddCartItem(cartmodel);
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
