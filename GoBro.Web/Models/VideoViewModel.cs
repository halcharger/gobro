using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NExtensions;

namespace GoBro.Web.Models
{
    public class VideoViewModel
    {
        public string YoutubeLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string YoutubeId { 
            get {
                return YoutubeLink.HasValue() ? HttpUtility.ParseQueryString(new Uri(YoutubeLink).Query).Get("v") : string.Empty;
            } 
        }
    }
}