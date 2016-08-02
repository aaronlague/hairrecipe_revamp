using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "sp");  
            
            } else {

                return View();
            
            }

        }

    }
}
