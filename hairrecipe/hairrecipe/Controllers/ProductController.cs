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

        public ActionResult Index(string param)
        {
            Console.Write(param);
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Product", "sp");

            }
            else
            {
                return View();
            }
        }
    }
}
