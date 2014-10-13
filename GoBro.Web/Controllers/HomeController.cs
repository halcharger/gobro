using GoBro.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GoBro.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            var latestVideos = await mediator.SendAsync(new LatestVideosQuery());
            return View();
        }
    }
}