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
        public ActionResult Index(string question, string page)
        {
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "SpDiagnosis");

            }
            else
            {
                ViewBag.question = Request.QueryString["question"];
                ViewBag.page = Request.QueryString["page"];
                ViewBag.text = "test";
                return View();
            }
        }

    }
}
