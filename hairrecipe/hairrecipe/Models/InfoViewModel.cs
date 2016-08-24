using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hairrecipe.Models
{
    public class InfoViewModel
    {
        public int InfoId { get; set; }
        public string InfoImage { get; set; }
        public string InfoTitle { get; set; }
        public string InfoDate { get; set; }
        public string InfoNews { get; set; }
        public string InfoClass { get; set; }
        public string InfoLink { get; set; }
    }
}