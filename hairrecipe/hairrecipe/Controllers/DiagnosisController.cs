using AttributeRouting;
using AttributeRouting.Web.Mvc;
using hairrecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers
{
    [RoutePrefix("Diagnosis")]
    public class DiagnosisController : Controller
    {
        //
        // GET: /Diagnosis/
        [Route("Diagnosis/{question?}/{page?}")]
        public ActionResult Index(string question, string page)
        {
            var model = new DiagnosisViewModel
            {
                QuestionsPartial = (question == null) ? "_diagnosisLanding" : question + "/" + page
            };
            
            return View(model);
        }

    }
}
