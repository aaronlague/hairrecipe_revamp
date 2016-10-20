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
                return Redirect("/sp/kodawari/");

            } else {

                //return View();
                return Redirect("/kodawari/");
            }
        }

        [Route("/product/Booster")]
        [Route("/product/Apricot")]
        [Route("/product/Kiwi")]
        [Route("/product/Mint")]
        [Route("/product/Apple-ginger")]
        public ActionResult ProductLine()       
        
        {

            if (Helpers.DeviceHelpers.IsMobile())
            {
                var requestUrl = Request.RawUrl.ToString();
                return Redirect("/sp/" + requestUrl);
            }
            else
            {
                /* Get the last segment of the URI to identify the view */
                Uri uriAddress1 = new Uri(HttpContext.Request.Url.AbsoluteUri);
                int numsegment = uriAddress1.Segments.Length - 1;
                string line = uriAddress1.Segments[numsegment].Replace("/", "");

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
