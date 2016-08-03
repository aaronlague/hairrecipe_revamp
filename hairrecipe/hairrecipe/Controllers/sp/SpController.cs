using AttributeRouting.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers.sp
{
    public class SpController : Controller
    {
        //
        // GET: /Sp/

        public ActionResult Index()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/about")]
        public ActionResult About()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("About", "Home");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/contact")]
        public ActionResult Contact()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Contact", "Home");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/faq")]
        public ActionResult Faq()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Faq", "Home");

            }
            else
            {

                return View();
            }
        }

        [Route("sp/cm")]
        public ActionResult Cm()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Cm", "Home");

            }
            else
            {

                return View();
            }
        }
    }
}
