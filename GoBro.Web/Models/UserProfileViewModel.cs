using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoBro.Web.Models
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            Videos = new VideoThumbnailViewModel[] { };
        }

        public string Username { get; set; }
        public IEnumerable<VideoThumbnailViewModel> Videos { get; set; }
        public bool CanManage { get; set; }
    }
}