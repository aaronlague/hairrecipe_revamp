using AttributeRouting.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers.sp
{
    public class SpProductController : Controller
    {
        //
        // GET: /SpProduct/
        [Route("/sp/product")]
        public ActionResult Index()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "Product");

            }
            else
            {
                return View();
            }
        }

        [Route("/sp/product/Booster")]
        public ActionResult Booster()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Booster", "Product");

            }
            else
            {
                return View();
            }
        }

        [Route("/sp/product/Apricot")]
        public ActionResult Apricot()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Apricot", "Product");

            }
            else
            {
                return View();
            }
        }

        [Route("/sp/product/Kiwi")]
        public ActionResult Kiwi()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Kiwi", "Product");

            }
            else
            {
                return View();
            }
        }

        [Route("/sp/product/Mint")]
        public ActionResult Mint()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Mint", "Product");

            }
            else
            {
                return View();
            }
        }
    }
}
