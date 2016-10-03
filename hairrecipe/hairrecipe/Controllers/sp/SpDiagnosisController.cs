using AttributeRouting;
using AttributeRouting.Web.Mvc;
using hairrecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hairrecipe.Controllers.sp
{
    //[RoutePrefix("SpDiagnosis")]
    public class SpDiagnosisController : Controller
    {
        //
        // GET: /SpDiagnosis/
        [Route("sp/diagnosis/{question?}/{page?}")]
        public ActionResult Index(string question, string result, string page)
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Index", "Diagnosis");
                var requestUrl = Request.RawUrl.ToString().Replace("/sp", "");
                return Redirect(requestUrl);

            }
            else
            {
                var model = new DiagnosisViewModel
                {
                    QuestionsPartial = ((question != null)) ? question + "/" + page : ((question == "result")) ? "result/" + page : "_diagnosisLanding"
                };

                return View(model);
            }
        }

    }
}
