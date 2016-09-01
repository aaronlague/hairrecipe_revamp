using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using AttributeRouting.Web.Mvc;
using Newtonsoft.Json.Linq;
using hairrecipe.Models;
using hairrecipe.data;
using hairrecipe.data.Entities.Products;
using hairrecipe.data.Entities.CM;
using hairrecipe.data.Entities.Home;
using hairrecipe.data.Entities.Info;
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
                //return RedirectToAction("Index", "Home");
                return Redirect("/index.html");

            }
            else
            {
                var returnList = JsonServices.QueryJsonListOfObject<HomeProducts>("/Content/data/ProductList.json");
                return View(returnList);
            }
        }

        [Route("sp/about")]
        public ActionResult About()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("About", "Home");
                return Redirect("/about/index.html");

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
                //return RedirectToAction("Contact", "Home");
                return Redirect("/contact/index.html");

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
                //return RedirectToAction("Sitemap", "Home");
                return Redirect("/sitemap/index.html");

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
                //return RedirectToAction("Faq", "Home");
                return Redirect("/faq/index.html");

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
                //return RedirectToAction("Cm", "Home");
                return Redirect("/cm/index.html");

            }
            else
            {
                var returnList = JsonServices.QueryJsonListOfObject<Video>("/Content/data/VideoList.json");
                return View(returnList);
            }
        }

        [Route("sp/reco_recipe")]
        public ActionResult reco_recipe()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("reco_recipe", "Home");
                return Redirect("/reco_recipe/index.html");

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
                //return RedirectToAction("kodawari", "Home");
                return Redirect("/kodawari/index.html");

            }
            else
            {
                var returnList = JsonServices.QueryJsonListOfObject<KodawariStoreListing>("/Content/data/StoriesList.json");
                return View(returnList);
            }
        }

        [Route("sp/info")]
        public ActionResult info()
        {
            if (!Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("info", "Home");
                return Redirect("/info/index.html");

            }
            else
            {
                var returnList = JsonServices.QueryJsonListOfObject<InfoList>("/Content/data/InfoList.json");
                return View(returnList);
            }
        }
    }
}
