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
            return View();
        }

        [Route("/sp/product/Booster")]
        public ActionResult Booster()
        {
            return View();
        }

        [Route("/sp/product/Apricot")]
        public ActionResult Apricot()
        {
            return View();
        }

        [Route("/sp/product/Kiwi")]
        public ActionResult Kiwi()
        {
            return View();
        }

        [Route("/sp/product/Mint")]
        public ActionResult Mint()
        {
            return View();
        }
    }
}
