using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hairrecipe.data.Entities.CM;
using hairrecipe.data.Entities.Home;
using hairrecipe.data.Entities.Info;

namespace hairrecipe.data.Entities.Home
{
    public class HomeDualObj
    {
        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<HomeProducts> HomeProducts { get; set; }
        public IEnumerable<InfoList> InfoList { get; set; }
    }

}
