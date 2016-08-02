using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class SPController : Controller
    {
        //
        // GET: /SP/

        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Index");
            }
        }

        public ActionResult About()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "About");
            }
        }

        public ActionResult Contact()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Contact");
            }
        }

        public ActionResult Product()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }

    }
}
