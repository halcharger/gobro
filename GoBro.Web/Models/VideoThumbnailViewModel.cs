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
        public string UserId { get; set; }
        public string YoutubeLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ThumbnailImageUrl { 
            get {
                var youtubeThumbnailImgTemplate = "http://img.youtube.com/vi/{0}/0.jpg";

                if (YoutubeLink.HasValue())
                {
                    var youtubeId = HttpUtility.ParseQueryString(new Uri(YoutubeLink).Query).Get("v");
                    return string.Format(youtubeThumbnailImgTemplate, youtubeId);
                }

                return youtubeThumbnailImgTemplate;
            } 
        }
    }
}