using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hairrecipe.Models
{
    public class StoriesListing
    {
        public int StoryId { get; set; }
        public string StoryThumb { get; set; }
        public string StoryTitle { get; set; }
        public string StoryText { get; set; }
        public string StoryBg { get; set; }
    }
}