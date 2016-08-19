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
            if (!Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("Index", "Product");

            }
            else
            {
                return View();
            }
        }


        [Route("/sp/product/Booster")]
        [Route("/sp/product/Apricot")]
        [Route("/sp/product/Kiwi")]
        [Route("/sp/product/Mint")]
        public ActionResult ProductLine()
        {
            string url = HttpContext.Request.Url.AbsolutePath;
            string line = url.Split('/').Last();
            ViewData["group-title"] = line;
            string filepath = Server.MapPath("~/Content/data/" + line + ".json");
            var productLine = ProductService.GetLineDetails(filepath);

            return View("Product-line", productLine);
        }

    }
}
