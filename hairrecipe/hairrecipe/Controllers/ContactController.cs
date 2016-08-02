using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Contact", "sp");
            }
            else
            {
                return View();
            }
        }

    }
}
