using GoBro.Core.Commands;
using GoBro.Core.Models;
using GoBro.Core.Queries;
using GoBro.Web.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NExtensions;
using GoBro.Web.Infrastructure;

namespace GoBro.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserProvider userProvider;

        public VideoController(IMediator mediator, IUserProvider userProvider)
        {
            this.mediator = mediator;
            this.userProvider = userProvider;
        }

        [HttpGet]
        [Route("video/{id}")]
        public async Task<ViewResult> View(string id)
        {
            var video = await mediator.SendAsync<Video>(new GetVideoQuery { Id = id });
            return View(video.MapTo<VideoViewModel>());
        }

        [HttpPost]
        [Authorize]
        //[ValidateAntiForgeryToken]
        [Route("{username}/delete/{id}")]
        public async Task<JsonResult> Delete(string username, string id)
        {
            try
            {
                var result = await mediator.SendAsync(new DeleteVideoCommand { Id = id, VideoUsername = username, LoggedOnUsername = userProvider.Username });
                return new JsonResult { Data = result };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = ex.Message };
            }
        }
    }
}