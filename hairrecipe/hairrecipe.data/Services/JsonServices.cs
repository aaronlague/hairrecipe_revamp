using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using hairrecipe.data;
using hairrecipe.data.Entities.Products;
using hairrecipe.data.Entities.CM;


namespace hairrecipe.data.Services
{
    public static class JsonServices
    {
        public static List<T> QueryJsonObject<T>(string jsonFile)
        {
            var x = new Video();
            string file = System.Web.Hosting.HostingEnvironment.MapPath(jsonFile);
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer jsonObj = new JavaScriptSerializer();
            var retVal = jsonObj.Deserialize<List<T>>(Json);
            return retVal;
        }
    }
}
