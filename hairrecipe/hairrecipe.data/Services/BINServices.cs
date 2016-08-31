using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using hairrecipe.data.Entities.BIN;
using Newtonsoft.Json.Linq;


namespace hairrecipe.data.Services
{
    public class BINServices
    {
        public static BIN GetBIN(string SKU)
        {
            string filePath = System.Configuration.ConfigurationManager.AppSettings["BINSourceFilepath"];
            string Json = System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(filePath));

            JArray jArryObj = JArray.Parse(Json);
            var binObj = jArryObj.ToObject<List<BIN>>();
            var rtn = new BIN();
            try { 
                rtn = binObj.Where(x => x.SKU.Contains(SKU)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //do nothing
            }
            return rtn;
        }
    }
}
