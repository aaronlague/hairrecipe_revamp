using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace hairrecipe.data.Helpers.PageFilter
{
    public class StreamOutputCDN : IHttpModule
    {

        //-----------------------------------------------------------------------------------------
        public void Init (HttpApplication app)
        {
            app.ReleaseRequestState         += new EventHandler(InstallResponseFilter);
        }


        /// <summary>
        /// Use this event to wire a page filter.
        /// </summary>
        private void InstallResponseFilter(object sender, EventArgs e) 
        {
            HttpResponse response = HttpContext.Current.Response;

            if(response.ContentType == "text/html")
                response.Filter = new StreamFilter(response.Filter);      
        }
        public void Dispose() { }
    }
}

