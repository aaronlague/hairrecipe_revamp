using hairrecipe.data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace hairrecipe.data.Services
{
    public  class ProductService
    {


        public static ProductLine GetLineDetails(string filePath)
       {
            //get the Json filepath  
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(filePath);
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var productLine = jsonSerializer.Deserialize<ProductLine>(Json);
            return productLine;
        }

    }
}
