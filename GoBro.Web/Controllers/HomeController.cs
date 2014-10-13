using GoBro.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            var latestVideos = mediator.Send(new LatestVideosQuery());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}