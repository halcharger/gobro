using GoBro.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Queries
{
    public class LatestVideosQuery : IRequest<IEnumerable<Video>>
    {
    }
}
