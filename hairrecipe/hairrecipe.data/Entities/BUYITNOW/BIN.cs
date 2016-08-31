using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairrecipe.data.Entities.BUYITNOW
{
    public class BIN
    {
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public IList<Store> Stores { get; set; }
    }
}
