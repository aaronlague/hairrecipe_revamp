using AttributeRouting;
using AttributeRouting.Web.Mvc;
using hairrecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hairrecipe.data.Entities.Diagnosis;

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
            if (Request.Browser.IsMobileDevice)
            {
                var requestUrl = Request.RawUrl.ToString();
                return Redirect("/sp/" + requestUrl);
                //return Redirect("/sp/diagnosis/index.html");
            }
            else
            {
                var model = new Diagnosis()
                {
                    QuestionsPartial = (question == null) ? "_diagnosisLandingDesktop" : question + "/" + page
                };

                return View(model);
            }
        }

    }
}
