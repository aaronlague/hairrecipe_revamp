using AttributeRouting.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class DiagnosisController : Controller
    {
        //
        // GET: /Diagnosis/
        [Route("Diagnosis")]
        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "SpDiagnosis");

            }
            else
            {

                return View();
            }
        }

    }
}
