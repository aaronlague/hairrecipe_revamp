using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hairrecipe.Models
{
    public class ProductListingViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductIntroText { get; set; }
    }
}