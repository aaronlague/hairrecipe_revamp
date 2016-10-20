using AttributeRouting.Web.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hairrecipe.Models;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using hairrecipe.data;
using hairrecipe.data.Entities.Products;
using hairrecipe.data.Services;


namespace hairrecipe.Controllers.sp
{
    public class SpProductController : Controller
    {
        //
        // GET: /SpProduct/
        [Route("/sp/product")]
        public ActionResult Index()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Index", "Product");
                //return RedirectToAction("kodawari", "Home");
                return Redirect("/kodawari/");

            }
            else
            {
                //string file = Server.MapPath("~/Content/data/StoriesList.json");
                //string Json = System.IO.File.ReadAllText(file);
                //JavaScriptSerializer storiesObj = new JavaScriptSerializer();
                //var storyList = storiesObj.Deserialize<List<StoriesListing>>(Json);

                //return View(storyList);
                //return RedirectToAction("kodawari", "Sp");
                return Redirect("/sp/kodawari/");
            }
        }


        [Route("/sp/product/Booster")]
        [Route("/sp/product/Apricot")]
        [Route("/sp/product/Kiwi")]
        [Route("/sp/product/Mint")]
        [Route("/sp/product/Apple-ginger")]
        public ActionResult ProductLine()
        {
            if (!Helpers.DeviceHelpers.IsMobile() && !Helpers.DeviceHelpers.IsSearchBot())
            {
                //return RedirectToAction("Index", "Diagnosis");
                var requestUrl = Request.RawUrl.ToString().Replace("/sp", "");
                return Redirect(requestUrl);

            }
            else
            {
                /* Get the last segment of the URI to identify the view */
                Uri uriAddress1 = new Uri(HttpContext.Request.Url.AbsoluteUri);
                int numsegment = uriAddress1.Segments.Length - 1;
                string line = uriAddress1.Segments[numsegment].Replace("/", "");

                ViewData["group-title"] = line;
                string filepath = Server.MapPath("~/Content/data/" + line + ".json");
                var productLine = ProductService.GetLineDetails(filepath);

                return View("Product-line", productLine);
            }
        }

    }
}
