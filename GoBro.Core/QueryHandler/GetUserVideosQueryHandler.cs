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
    public class GetUserVideosQueryHandler : IAsyncRequestHandler<GetUserVideosQuery, IEnumerable<Video>>
    {
        private readonly GoBroAzureTables tables;

        public GetUserVideosQueryHandler(GoBroAzureTables tables)
        {
            this.tables = tables;
        }

        public Task<IEnumerable<Video>> Handle(GetUserVideosQuery message)
        {
            return Task.Factory.StartNew(() =>
            {
                var filter = TableQuery.GenerateFilterCondition(GoBroAzureTables.PartitionKeyFieldName, QueryComparisons.Equal, message.Username);
                var query = new TableQuery<Video>().Where(filter);
                return tables.VideosTable.ExecuteQuery(query);
            });
        }
    }
}
