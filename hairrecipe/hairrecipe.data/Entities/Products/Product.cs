﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairrecipe.data.Entities.Products
{
    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Line { get; set; }
        public string DesktopDirection { get; set; }
        public string Type { get; set; }
        public string EnTitle { get; set; }
        public string JpTitle1 { get; set; }
        public string JpTitle2 { get; set; }
        public string JpTitle3 { get; set; }
        public string BackgroundClass { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Howtouse { get; set; }
        public bool IsActive { get; set; }
        public bool HasReview { get; set; }
        public bool HasBIN { get; set; }
        public string BINGACA { get; set; }
        public string BINStoreGaca { get; set; }
        public string ReviewReadGACA { get; set; }
        public string ReviewWriteGACA { get; set; }
        public IList<Column> Columns { get; set; }
    }
}
