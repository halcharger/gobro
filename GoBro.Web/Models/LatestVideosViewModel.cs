using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoBro.Web.Models
{
    public class LatestVideosViewModel
    {
        public LatestVideosViewModel()
        {
            Videos = Enumerable.Empty<VideoThumbnailViewModel>();
        }
        public LatestVideosViewModel(IEnumerable<VideoThumbnailViewModel> videos)
        {
            Videos = videos;
        }

        public IEnumerable<VideoThumbnailViewModel> Videos { get; set; }
    }
}