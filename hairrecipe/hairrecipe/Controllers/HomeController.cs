using AttributeRouting.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hairrecipe.Infrastructure;

namespace hairrecipe.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Route("Index")]
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

        [Route("Faq")]
        public ActionResult Faq()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Faq", "Sp");

            }
            else
            {

                return View();
            }
        }

        [Route("Cm")]
        public ActionResult Cm()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Cm", "Sp");

            }
            else
            {

                return View();
            }
        }
    }
}
