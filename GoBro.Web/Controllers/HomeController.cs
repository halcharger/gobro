using GoBro.Core.Queries;
using GoBro.Web.Models;
using MediatR;
using System.Threading.Tasks;
using System.Web.Mvc;
using StackExchange.Profiling;

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
            var profiler = MiniProfiler.Current;
            using (profiler.Step("HomeControllerIndexMethod"))
            {
                var latestVideos = await mediator.SendAsync(new LatestVideosQuery());

                return View(new LatestVideosViewModel(latestVideos.MapTo<VideoThumbnailViewModel>()));
            }
        }
    }
}