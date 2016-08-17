using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hairrecipe.Helpers
{
    public static class DataExtensions
    {

        public static T JsonFieldAs<T>(this string data)
        {
            return !string.IsNullOrEmpty(data)
                       ? default(T)
                       : JsonConvert.DeserializeObject<T>(data);
        }

        public static T JsonFieldAs<T>(this object data)
        {
            return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data.ToString());
        }

    }
}