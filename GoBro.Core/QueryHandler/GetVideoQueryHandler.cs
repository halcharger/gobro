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
    public class GetVideoQueryHandler : IAsyncRequestHandler<GetVideoQuery, Video>
    {
        private readonly GoBroAzureTables tables;

        public GetVideoQueryHandler(GoBroAzureTables tables)
        {
            this.tables = tables;
        }

        public async Task<Video> Handle(GetVideoQuery message)
        {
            var result = await tables.VideosTable.ExecuteAsync(TableOperation.Retrieve<Video>(message.Username, message.Id));
            return (Video)result.Result;
        }
    }
}
