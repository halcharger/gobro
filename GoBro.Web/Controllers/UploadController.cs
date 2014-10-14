using GoBro.Core.Commands;
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
    public class UploadController : Controller
    {
        private readonly IMediator mediator;

        public UploadController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet, Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Authorize]
        public async Task<ActionResult> NewVideo(UploadVideoModel model)
        {
            var result = await mediator.SendAsync(model.MapTo<UploadVideoCommand>());
            return new RedirectResult("/");
        }
    }
}