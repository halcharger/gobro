using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NExtensions;

namespace GoBro.Web.Models
{
    public class VideoViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string YoutubeId { get; set; }
        public string Username { get; set; }
    }
}