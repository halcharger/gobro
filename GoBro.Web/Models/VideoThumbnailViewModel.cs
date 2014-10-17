using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NExtensions;

namespace GoBro.Web.Models
{
    public class VideoThumbnailViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string YoutubeId { get; set; }
        public bool CanManage { get; set; }
    }
}