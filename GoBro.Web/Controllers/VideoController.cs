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

namespace GoBro.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IMediator mediator;

        public VideoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("video/{id}")]
        public async Task<ViewResult> View(string id)
        {
            var video = await mediator.SendAsync<Video>(new GetVideoQuery { Id = id });
            return View(video.MapTo<VideoViewModel>());
        }
    }
}