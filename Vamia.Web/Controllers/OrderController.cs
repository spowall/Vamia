using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamia.Domain.Managers;
using Vamia.Domain.Models;
using Vamia.Infrastructure.Entities;
using Vamia.Infrastructure.Repositories;
using Vamia.Web.Infrastructure.Services;

namespace Vamia.Web.Controllers
{
    public class OrderController : Controller
    {
        private CartService _cart;
        private OrderManager _order;

        public OrderController()
        {
            _cart = new CartService();
            _order = new OrderManager(new OrderRepository(new DataEntities()));
        }

        public ActionResult Place()
        {
            return RedirectToAction("index","home");
        }

        [Authorize, HttpPost]
        public ActionResult Place(FormCollection collection)
        {
            try
            { 
                //Read contents of Cart
                var items = _cart.GetCartItems().ToArray();
                //Get User Id
                var userId = User.Identity.GetUserId<int>();
                //Place Order with UserId and Items
                var order = _order.PlaceOrder(userId, items);
                return View(order);
            }
            catch(Exception ex)
            {
                TempData[Constants.TempData.Message] = ex.Message;
                return RedirectToAction("index", "home");
            }
        }
    }
}