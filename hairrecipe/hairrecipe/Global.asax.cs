﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;


namespace hairrecipe
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            string urlRequest = Request.Url.AbsolutePath.ToString();

            if (urlRequest.Equals("/index.html"))
            {
                Context.RewritePath("/index");
            }
            else if (urlRequest.Equals("/sp/index.html"))
            {
                Context.RewritePath("/sp/index");
            }
            else if (urlRequest.Equals("/about/index.html"))
            {
                Context.RewritePath("/about");
            }
            else if (urlRequest.Equals("/sp/about/index.html"))
            {
                Context.RewritePath("/sp/about");
            }

        }

        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();

            //The Android view
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("android")
            {
                ContextCondition = Context => Context.Request.Browser.Platform == "Android"
            });

            //The iPhone view
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iphone")
            {
                ContextCondition = Context => Context.Request.Browser.MobileDeviceModel == "iPhone"
            });

            //The mobile view
            //This has a lower priority than the other two so will only be used by a mobile device
            //that isn't Android or iPhone
            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("mobile")
            {
                ContextCondition = Context => Context.Request.Browser.IsMobileDevice
            });

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}