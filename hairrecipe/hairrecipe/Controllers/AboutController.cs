using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("About", "sp");

            }
            else
            {

                return View();

            }
        }

    }
}
