using AttributeRouting.Web.Mvc;
using Newtonsoft.Json.Linq;
using hairrecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using hairrecipe.data;
using hairrecipe.data.Entities.Products;
using hairrecipe.data.Services;

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

        [Route("sp/sitemap")]
        public ActionResult Sitemap()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Sitemap", "Home");

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
                string file = Server.MapPath("~/Content/data/VideoList.json");
                string Json = System.IO.File.ReadAllText(file);
                JavaScriptSerializer videoObj = new JavaScriptSerializer();
                var videoList = videoObj.Deserialize<List<CmViewModel>>(Json);

                return View(videoList);
            }
        }

        [Route("sp/reco_recipe")]
        public ActionResult reco_recipe()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("reco_recipe", "Home");

            }
            else
            {

                return View();
            }
        }

        [Route("sp/kodawari")]
        public ActionResult kodawari()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("kodawari", "Home");

            }
            else
            {
                string file = Server.MapPath("~/Content/data/StoriesList.json");
                string Json = System.IO.File.ReadAllText(file);
                JavaScriptSerializer storiesObj = new JavaScriptSerializer();
                var storyList = storiesObj.Deserialize<List<StoriesListing>>(Json);

                return View(storyList);
            }
        }

        [Route("sp/info")]
        public ActionResult info()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("info", "Home");

            }
            else
            {

                string file = Server.MapPath("~/Content/data/InfoList.json");
                string Json = System.IO.File.ReadAllText(file);
                JavaScriptSerializer infoObj = new JavaScriptSerializer();
                var infoList = infoObj.Deserialize<List<InfoViewModel>>(Json);

                return View(infoList);
            }
        }
    }
}
