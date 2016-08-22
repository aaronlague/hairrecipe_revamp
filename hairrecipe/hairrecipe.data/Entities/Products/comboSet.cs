using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairrecipe.data.Entities.Products
{
    public class ComboSet
    {
        public string Title { get; set; }
        public string BackgroundClass { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IList<ProductSet> ProductSets { get; set; }
    }
}
