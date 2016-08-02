using AttributeRouting.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "Sp");

            }
            else
            {

                return View();
            }
        }

        [Route("About")]
        public ActionResult About()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("About", "Sp");

            }
            else
            {

                return View();
            }
        }

        [Route("Contact")]
        public ActionResult Contact()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Contact", "Sp");

            }
            else
            {

                return View();
            }
        }
    }
}
