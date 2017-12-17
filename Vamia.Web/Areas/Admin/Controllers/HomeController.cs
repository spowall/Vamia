using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vamia.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("This is the Customer Admin Area");
        }
    }
}