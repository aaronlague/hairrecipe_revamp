using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace hairrecipe.Helpers
{
    public class DeviceHelpers
    {
        public static bool IsTablet()
        {
            String userAgent = HttpContext.Current.Request.UserAgent;
            Boolean isMobile = HttpContext.Current.Request.Browser.IsMobileDevice;
            Regex r = new Regex("Tablet|iPad|PlayBook|BB10|Z30|Nexus 10|Nexus 7|GT-P|SCH-I800|Xoom|Kindle|Silk|KFAPWI", RegexOptions.IgnoreCase); ;

            bool isTablet = false;
            if (userAgent != null)
            {
                isTablet = r.IsMatch(userAgent) && isMobile;
            }
            return isTablet;
        }

        public static bool IsMobile()
        {
            Boolean isMobile = HttpContext.Current.Request.Browser.IsMobileDevice;
            if (IsTablet())
            {
                isMobile = false;
            }
            return isMobile;
        }

        public static bool IsSearchBot()
        {
            String userAgent = HttpContext.Current.Request.UserAgent;
            Regex r = new Regex("Googlebot", RegexOptions.IgnoreCase);

            bool IsSearchBot = false;
            if (userAgent != null)
            {
                IsSearchBot = r.IsMatch(userAgent);
            }
            return IsSearchBot;
        }

    }
}