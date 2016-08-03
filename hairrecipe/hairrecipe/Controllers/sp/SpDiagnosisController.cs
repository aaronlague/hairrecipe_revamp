using AttributeRouting.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers.sp
{
    public class SpDiagnosisController : Controller
    {
        //
        // GET: /SpDiagnosis/
        [Route("/sp/diagnosis")]
        public ActionResult Index()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "Diagnosis");

            }
            else
            {

                return View();
            }
        }

    }
}
