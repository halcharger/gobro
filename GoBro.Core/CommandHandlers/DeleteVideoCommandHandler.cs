using GoBro.Core.Commands;
using GoBro.Core.Data;
using GoBro.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.CommandHandlers
{
    public class DeleteVideoCommandHandler : AsyncRequestHandler<DeleteVideoCommand>
    {
        private readonly IWriteToAzureTables writeService;
        private readonly IMediator mediatr;

        public DeleteVideoCommandHandler(IWriteToAzureTables writeService, IMediator mediatr)
        {
            this.writeService = writeService;
            this.mediatr = mediatr;
        }

        protected override async Task HandleCore(DeleteVideoCommand message)
        {
            var vid = await mediatr.SendAsync(new GetVideoQuery{Id = message.Id});
            await writeService.DeleteAsync(vid, GoBroAzureTables.VideosTableName);
        }
    }
}
