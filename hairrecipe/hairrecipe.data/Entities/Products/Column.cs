using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairrecipe.data.Entities.Products
{
    public class Column
    {
       public string  Header { get; set; }
       public IList<Phrase> Phrases { get; set; }
    }
}
