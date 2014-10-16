using GoBro.Core.Queries;
using GoBro.Web.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GoBro.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediatr;

        public UserController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [Route("user/{username}")]
        public new async Task<ActionResult> Profile(string username)
        {
            var results = await mediatr.SendAsync(new GetUserVideosQuery { Username = username });
            return View(new UserProfileViewModel { 
                Username = username, 
                Videos = results.MapTo<VideoThumbnailViewModel>()
            });
        }
    }
}