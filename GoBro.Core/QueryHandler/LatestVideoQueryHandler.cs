using GoBro.Core.Model;
using GoBro.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.QueryHandler
{
    public class LatestVideoQueryHandler : IAsyncRequestHandler<LatestVideosQuery, IEnumerable<Video>>
    {
        public Task<IEnumerable<Video>> Handle(LatestVideosQuery message)
        {
            var result = new[]{
                new Video{Title="title1"}, 
                new Video{Title="title2"}
            };

            return Task.FromResult(result.AsEnumerable());
        }
    }
}
