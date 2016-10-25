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
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Index", "Home");
                return Redirect("/");

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
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("About", "Home");
                return Redirect("/about");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/contact")]
        public ActionResult Contact()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Contact", "Home");
                return Redirect("/contact");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/sitemap")]
        public ActionResult Sitemap()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Sitemap", "Home");
                return Redirect("/sitemap");

            }
            else
            {
                return View();
            }
        }

        [Route("sp/faq")]
        public ActionResult Faq()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Faq", "Home");
                return Redirect("/faq");

            }
            else
            {

                return View();
            }
        }

        [Route("sp/cm")]
        public ActionResult Cm()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Cm", "Home");
                return Redirect("/cm");

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
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("reco_recipe", "Home");
                return Redirect("/reco_recipe");

            }
            else
            {

                return View();
            }
        }

        [Route("sp/kodawari")]
        public ActionResult kodawari()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("kodawari", "Home");
                return Redirect("/kodawari");

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
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("info", "Home");
                return Redirect("/info");

            }
            else
            {
                var returnList = JsonServices.QueryJsonListOfObject<InfoList>("/Content/data/InfoList.json");
                return View(returnList);
            }
        }

        [Route("sp/hawaii")]
        public ActionResult hawaii()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("reco_recipe", "Home");
                return Redirect("/hawaii");

            }
            else
            {

                return View();
            }
        }
    }
}
