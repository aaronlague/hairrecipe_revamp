using AttributeRouting.Web.Mvc;
using hairrecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace hairrecipe.Controllers.sp
{
    public class SpController : Controller
    {
        //
        // GET: /Sp/

        public ActionResult Index()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                string file = Server.MapPath("~/Content/data/ProductList.json");
                string Json = System.IO.File.ReadAllText(file);
                JavaScriptSerializer productObj = new JavaScriptSerializer();
                var productList = productObj.Deserialize<List<ProductListingViewModel>>(Json);

                return View(productList);
            }
        }

        [Route("sp/about")]
        public ActionResult About()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("About", "Home");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/contact")]
        public ActionResult Contact()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Contact", "Home");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/faq")]
        public ActionResult Faq()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Faq", "Home");

            }
            else
            {

                return View();
            }
        }

        [Route("sp/cm")]
        public ActionResult Cm()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Cm", "Home");

            }
            else
            {

                return View();
            }
        }
    }
}
