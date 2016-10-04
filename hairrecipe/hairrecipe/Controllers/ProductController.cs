using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hairrecipe.data;
using hairrecipe.data.Entities.Products;
using hairrecipe.data.Services;
using AttributeRouting.Web.Mvc;

namespace hairrecipe.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            if (Helpers.DeviceHelpers.IsMobile())
            {
                //return RedirectToAction("Index", "SpProduct");
                return Redirect("/sp/kodawari/index.html");

            } else {

                //return View();
                return Redirect("/kodawari/index.html");
            }
        }

        [Route("/product/Booster")]
        [Route("/product/Apricot")]
        [Route("/product/Kiwi")]
        [Route("/product/Mint")]
        [Route("/product/Apple")]
        public ActionResult ProductLine()       
        
        {

            if (Helpers.DeviceHelpers.IsMobile())
            {
                var requestUrl = Request.RawUrl.ToString();
                return Redirect("/sp/" + requestUrl);
            }
            else
            {
                string url = HttpContext.Request.Url.AbsolutePath;
                string line = url.Split('/').Last();

                if (Helpers.DeviceHelpers.IsMobile())
                {
                    return RedirectToAction(line, "sp/product");

                }
                ViewData["group-title"] = line;
                string filepath = Server.MapPath("~/Content/data/" + line + ".json");
                var productLine = ProductService.GetLineDetails(filepath);
                productLine.ProductListMain = productLine.Products.Where(x => x.Type.Contains("main")).ToList();
                productLine.ProductListRefill = productLine.Products.Where(x => x.Type.Contains("refill")).ToList();
                return View("Product-line", productLine);            
            }

        }


    }
}
