using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Vamia.Data;
using Vamia.Data.Entities;
using Vamia.Data.Repositories;
using Vamia.Domain.Managers;
using Vamia.Models;
using Vamia.Utils;

namespace Vamia.Controllers
{
    public class CartController : Controller
    {
        private DataContext _context;
        private CartManager _cartManager;
        private UserManager<AppUser> _userManager;
        private OrderManager _orderManager;

        public CartController()
        {
            _context = new DataContext();
            var cartRepo = new SessionRepository();
            var inventoryRepo = new InventoryRepository(_context);
            _cartManager = new CartManager(cartRepo, inventoryRepo);
            _orderManager = new OrderManager(new OrderRepository(_context));
            _userManager = new UserManager<AppUser>(new UserStore<AppUser>(_context));
        }

        // GET: Cart
        public ActionResult Index()
        {
            var items = _cartManager.GetCartItems();
            return View(items);
        }

        public ActionResult Add(int id = 0)
        {
            //Add to Cart
            _cartManager.AddCartItem(id);

            //Redirect back to Index
            return RedirectToAction("index", "home");
        }

        [Authorize]
        public ActionResult Checkout()
        {
            //Get Items from Crart
            var items = _cartManager.GetCartItems();

            //Get User Information
            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId).AsUser();

            //Create Order
            var newOrder = _orderManager.Order(user, items);

            //Clear our Cart
            _cartManager.Clear();

            //Generate Payment Parameters
            var model = new OrderViewModel()
            {
                Reference = Guid.NewGuid().ToString(),
                Order = newOrder,
                User = user,
                PaymentPage= "https://sandbox.interswitchng.com/webpay/pay",
                ProductId = "6205",
                ItemCode = "101",
                Total = newOrder.Items.Select(i => i.Product.Price * i.Quantity).Sum(),
                ReceiptUrl = "http://localhost:63937/payment/receipt",
                MacKey = "D3D1D05AFE42AD50818167EAC73C109168A0F108F32645C8B59E897FA930DA44F9230910DAC9E20641823799A107A02068F7BC0F4CC41D2952E249552255710F"
            };

            model.Hash = GenerateHash(model);
            return View(model);
        }

        private string GenerateHash(OrderViewModel order)
        {
            var tohash = order.Reference + order.ProductId + order.ItemCode + Convert.ToInt64(order.Total * 100) + order.ReceiptUrl + order.MacKey;
            var bytes = Encoding.ASCII.GetBytes(tohash);
            byte[] hash = null;
            using (SHA512 sha = new SHA512Managed())
            {
                hash = sha.ComputeHash(bytes);
            }
            return hash.Select(x => string.Format("{0:x2}", x)).Aggregate((ag, s) => ag + s);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}