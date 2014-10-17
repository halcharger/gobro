using GoBro.Core.Queries;
using GoBro.Web.Infrastructure;
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
        private readonly IUserProvider userProvider;

        public UserController(IMediator mediatr, IUserProvider userProvider)
        {
            this.mediatr = mediatr;
            this.userProvider = userProvider;
        }

        [Route("user/{username}")]
        public new async Task<ActionResult> Profile(string username)
        {
            var canManage = userProvider.Username == username;
            var results = await mediatr.SendAsync(new GetUserVideosQuery { Username = username });
            return View(new UserProfileViewModel { 
                Username = username, 
                Videos = results.MapTo<VideoThumbnailViewModel>(vm => vm.CanManage = canManage), 
                CanManage = canManage
            });
        }
    }
}