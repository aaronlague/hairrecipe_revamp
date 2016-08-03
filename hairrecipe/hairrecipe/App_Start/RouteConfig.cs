using hairrecipe.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hairrecipe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Diagnosis",
                url: "{controller}/{action}/{id}/{page}",
                defaults: new { controller = "Home", action = "Diagnosis", id = "", page = "" }
            );

            routes.Add(new LegacyRoute(
                "index.html",
                "~/index.html"
            ));

            //routes.MapRoute(
            //    name: "CrazyPants",
            //    url: "{page}.html",
            //    defaults: new { controller = "Home", action = "Html", page = UrlParameter.Optional }
            //);
        }
    }
}