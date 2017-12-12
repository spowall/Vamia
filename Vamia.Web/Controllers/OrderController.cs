using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vamia.Web.Controllers
{
    public class OrderController : Controller
    {
        [Authorize]
        public ActionResult Place()
        {
            return Content($"You {User.Identity.Name} have successfully placed an Order");
        }
    }
}