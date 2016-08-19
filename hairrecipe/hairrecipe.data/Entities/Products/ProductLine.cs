using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairrecipe.data.Entities.Products
{
    public class ProductLine
    {
        public string GroupName { get; set; }
        public string GroupKeyword { get; set; }     
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public string BannerText { get; set; }
        public string FooterBannerBackground { get; set; }
        public IList<Product> Products { get; set; }
    }
}
