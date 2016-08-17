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


        public static IList<Product> GetAllProducts(string filePath)
       {

            //get the Json filepath  
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(filePath);
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var products = jsonSerializer.Deserialize<List<Product>>(Json);  
            return products;
        }

    }
}
