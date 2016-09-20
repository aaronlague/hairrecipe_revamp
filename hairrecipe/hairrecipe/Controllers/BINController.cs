using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using hairrecipe.data.Services;

namespace hairrecipe.Controllers
{
    public class BINController : Controller
    {
        //
        // GET: /BIN/
        [HttpPost]
        [Route("/GetBIN")]
        public ActionResult GetBIN()
        {
            var binId = Request.Form["binId"];
            var gaca = Request.Form["gaca"];
            var BIN = BINServices.GetBIN(binId);
            return PartialView("_BINPopUp", BIN);
        }
    }
}
