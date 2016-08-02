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
            return View();
        }

        [Route("sp/about")]
        public ActionResult About()
        {
            return View();
        }

        [Route("sp/contact")]
        public ActionResult Contact()
        {
            return View();
        }

    }
}
