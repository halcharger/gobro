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
    public class LatestVideoQueryHandler : IRequestHandler<LatestVideosQuery, IEnumerable<Video>>
    {
        public IEnumerable<Video> Handle(LatestVideosQuery message)
        {
            return new Video[] { };
        }
    }
}
