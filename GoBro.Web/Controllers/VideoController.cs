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

namespace GoBro.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IMediator mediator;

        public VideoController(IMediator mediator)
        {
            this.mediator = mediator;
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
        [ValidateAntiForgeryToken]
        [Route("{username}/delete/{id}")]
        public async Task<ActionResult> Delete(string username, string id)
        {
            //confirm the logged on user is deleteing their own videos


            await mediator.SendAsync(new DeleteVideoCommand { Id = id });
            return Redirect("/{0}".FormatWith(username));
        }
    }
}