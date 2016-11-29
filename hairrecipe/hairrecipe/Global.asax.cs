using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using System.Web.Configuration;

namespace hairrecipe
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            string urlRequest = Request.Url.AbsolutePath.ToString();
            string DomainName = Request.Url.Host;
            bool isCDNActivated = Convert.ToBoolean(WebConfigurationManager.AppSettings["isCDNActivated"]);
            string CDNActivatedEnvironment = WebConfigurationManager.AppSettings["CDNActivatedEnvironment"];

            if (Helpers.DeviceHelpers.IsMobile())
            {
                if (urlRequest.Equals("/sp/diagnosis/index.html"))
                {
                    Context.RewritePath(urlRequest.Replace("index.html", ""));

                }
                else if (urlRequest.Contains("diagnosis/q") || urlRequest.Contains("diagnosis/result") || urlRequest.Contains("product/"))
                {
                    Context.RewritePath(urlRequest.Replace(".html", ""));
                }
                else {
                    
                    Context.RewritePath(urlRequest.Replace("index.html", ""));
                }

            }
            else
            {

                if (urlRequest.Contains("diagnosis/q") || urlRequest.Contains("diagnosis/result") || urlRequest.Contains("product/"))
                {
                    Context.RewritePath(urlRequest.Replace(".html", ""));
                }
                else
                {
                    Context.RewritePath(urlRequest.Replace("index.html", ""));
                }

            }



            if (DisplayModeProvider.Instance != null && HttpContext.Current.Request.UserAgent != null)
            {
                Regex r = new Regex("/sp/", RegexOptions.IgnoreCase);

                if (r.IsMatch(urlRequest))
                {
                    // GoogleBot UserAgent?
                    DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("mobile")
                    {
                        ContextCondition = (context => context.Request.UserAgent != null && context.GetOverriddenUserAgent().IndexOf("Googlebot", StringComparison.OrdinalIgnoreCase) >= 0)
                    });
                }
                else
                {
                    // GoogleBot UserAgent?
                    DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode()
                    {
                        ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("Googlebot", StringComparison.OrdinalIgnoreCase) >= 0)
                    });

                    // For iPad, display desktop
                    DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode()
                    {
                        ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0)
                    });
                }
            }

            if (DomainName == CDNActivatedEnvironment)
            { 
                Application["bv_api_server"] = WebConfigurationManager.AppSettings["bv_api_server_prod"];
                Application["bv_api_key"] = WebConfigurationManager.AppSettings["bv_api_key_prod"];
            }
            else
            {
                Application["bv_api_server"] = WebConfigurationManager.AppSettings["bv_api_server_stage"];
                Application["bv_api_key"] = WebConfigurationManager.AppSettings["bv_api_key_stage"];
            }

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();
                Response.Redirect("/");
            }
        }


    }

}