using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hairrecipe.Infrastructure
{
    public class LegacyRoute : RouteBase
    {
        private string[] staticUrls;

        public LegacyRoute(params string[] targetUrls)
        {
            staticUrls = targetUrls;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData resultRouteData = null;
            string urlRequest = httpContext.Request.AppRelativeCurrentExecutionFilePath;

            if (staticUrls.Contains(urlRequest, StringComparer.OrdinalIgnoreCase))
            {
                resultRouteData = new RouteData(this, new MvcRouteHandler());

                if (string.IsNullOrEmpty(urlRequest))
                {
                    resultRouteData.Values.Add("controller", "Home");
                    resultRouteData.Values.Add("action", "Index");
                }
                else if (urlRequest.ToLower().Equals("~/index.html"))
                {
                    resultRouteData.Values.Add("controller", "Home");
                    resultRouteData.Values.Add("action", "Index");
                }
            }
            return resultRouteData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;

            if (values.ContainsKey("legacyURL") &&
                staticUrls.Contains((string)values["legacyURL"], StringComparer.OrdinalIgnoreCase))
            {
                result = new VirtualPathData(this,
                new UrlHelper(requestContext)
                .Content((string)values["legacyURL"]).Substring(1));
            }
            return result;
        }
    }
}