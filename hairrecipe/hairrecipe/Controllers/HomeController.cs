using AttributeRouting.Web.Mvc;
using Newtonsoft.Json.Linq;
using hairrecipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hairrecipe.Infrastructure;
using System.Web.Script.Serialization;
using hairrecipe.data;
using hairrecipe.data.Entities.Products;
using hairrecipe.data.Entities.CM;
using hairrecipe.data.Entities.Info;
using hairrecipe.data.Services;


namespace hairrecipe.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //[Route("Index")]
        public ActionResult Index()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("Index", "Sp");
                return Redirect("/sp/index.html");

            }
            else
            {

                return View();
            }
        }

        [Route("/about")]
        public ActionResult About()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("About", "Sp");
                return Redirect("/sp/about/index.html");
            }
            else
            {
                return View();
            }
        }

        [Route("/contact")]
        public ActionResult Contact()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("Contact", "Sp");
                return Redirect("/sp/contact/index.html");

            }
            else
            {

                return View();
            }
        }

        [Route("/faq")]
        public ActionResult Faq()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("Faq", "Sp");
                return Redirect("/sp/faq/index.html");

            }
            else
            {

                return View();
            }
        }

        [Route("/cm")]
        public ActionResult Cm()
        {
           if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("Cm", "Sp");
                return Redirect("/sp/cm/index.html");

            }
            else
            {
                var returnList = JsonServices.QueryJsonListOfObject<Video>("/Content/data/VideoList.json");
                return View(returnList);
            }
        }

        [Route("/reco_recipe")]
        public ActionResult reco_recipe()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("reco_recipe", "Sp");
                return Redirect("/sp/reco_recipe/index.html");

            }
            else
            {

                return View();
            }
        }

        [Route("/kodawari")]
        public ActionResult kodawari()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("kodawari", "Sp");
                return Redirect("/sp/kodawari/index.html");

            }
            else
            {

                return View();
            }
        }

        [Route("/info")]
        public ActionResult info()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("info", "Sp");
                return Redirect("/sp/info/index.html");

            }
            else
            {

                var returnList = JsonServices.QueryJsonListOfObject<InfoList>("/Content/data/InfoList.json");
                return View(returnList);
            }
        }

        [Route("/sitemap")]
        public ActionResult sitemap()
        {
            if (Request.Browser.IsMobileDevice)
            {
                //return RedirectToAction("Sitemap", "Sp");
                return Redirect("/sp/sitemap/index.html");

            }
            else
            {

                return View();
            }
        }
    }
}
