using GoBro.Core.Data;
using GoBro.Core.Models;
using GoBro.Core.Queries;
using MediatR;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.QueryHandler
{
    public class LatestVideoQueryHandler : IAsyncRequestHandler<LatestVideosQuery, IEnumerable<Video>>
    {
        private readonly GoBroAzureTables tables;

        public LatestVideoQueryHandler(GoBroAzureTables tables){
            this.tables = tables;
        }

        public Task<IEnumerable<Video>> Handle(LatestVideosQuery message)
        {
            return Task.Factory.StartNew(() =>
            {
                var query = new TableQuery<Video>().Take(10);
                return tables.VideosTable.ExecuteQuery(query);
            });
        }
    }
}
