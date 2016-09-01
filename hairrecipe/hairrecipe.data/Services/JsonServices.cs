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
        //return a list of object (multiple object)
        public static List<T> QueryJsonListOfObject<T>(string jsonFile)
        {
            JavaScriptSerializer jsonObj = new JavaScriptSerializer();
            var retVal = jsonObj.Deserialize<List<T>>(ReturnJsonStr(jsonFile));
            return retVal;
        }
        //return a single project
        public static T QueryJsonObject<T>(string jsonFile)
        {
            JavaScriptSerializer jsonObj = new JavaScriptSerializer();
            var retVal = jsonObj.Deserialize<T>(ReturnJsonStr(jsonFile));
            return retVal;
        }
        //return json string
        private static string ReturnJsonStr(string jsonFile)
        {
            string file = System.Web.Hosting.HostingEnvironment.MapPath(jsonFile);
            string retVal = System.IO.File.ReadAllText(file);
            return retVal;

        }
    }
}
