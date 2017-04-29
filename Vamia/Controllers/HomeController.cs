using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vamia.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Json(new { greeting = "Hello", target = "World" }, JsonRequestBehavior.AllowGet);
        }
    }
}