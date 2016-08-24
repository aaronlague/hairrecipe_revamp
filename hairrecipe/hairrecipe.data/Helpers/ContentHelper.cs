using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;


namespace hairrecipe.data.Helpers
{
    public static class ContentHelper
    {
        public static string LineBreak(this string str, string platform)
        {

            string desktopKey = System.Configuration.ConfigurationManager.AppSettings["desktopStringBreaker"];
            string mobileKey = System.Configuration.ConfigurationManager.AppSettings["mobileStringBreaker"];
            if(desktopKey == platform ){
                str = str.Replace(mobileKey, "").Replace(desktopKey, "<br/>");
            }else{
                str = str.Replace(desktopKey, "").Replace(mobileKey, "<br/>");
            }
            return str;
        }

    }
}
