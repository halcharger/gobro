using GoBro.Core.Commands;
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
    public class UploadController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserProvider userProvider;

        public UploadController(IMediator mediator, IUserProvider userProvider)
        {
            this.mediator = mediator;
            this.userProvider = userProvider;
        }

        [HttpGet, Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Authorize]
        public async Task<ActionResult> NewVideo(UploadVideoBindingModel model)
        {
            var command = model.MapTo<UploadVideoCommand>();
            command.Username = userProvider.Username;

            var result = await mediator.SendAsync(command);
            return new RedirectResult("/");
        }
    }
}