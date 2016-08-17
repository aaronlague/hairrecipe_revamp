using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "SpProduct");

            } else {

                return View();
            }
        }

        public ActionResult Booster()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Apricot", "SpProduct");

            }
            else
            {

                return View();
            }
        }

        public ActionResult Apricot()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Apricot", "SpProduct");

            }
            else
            {

                return View();
            }
        }

        public ActionResult Kiwi()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Kiwi", "SpProduct");

            }
            else
            {

                return View();
            }
        }

        public ActionResult Mint()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Mint", "SpProduct");

            }
            else
            {

                return View();
            }
        }

    }
}
