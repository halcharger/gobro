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
    public class DeleteVideoCommandHandler : IAsyncRequestHandler<DeleteVideoCommand, string>
    {
        private readonly IWriteToAzureTables writeService;
        private readonly IMediator mediatr;

        public DeleteVideoCommandHandler(IWriteToAzureTables writeService, IMediator mediatr)
        {
            this.writeService = writeService;
            this.mediatr = mediatr;
        }

        public async Task<string> Handle(DeleteVideoCommand message)
        {
            var vid = await mediatr.SendAsync(new GetVideoQuery { Username=message.VideoUsername, Id = message.Id });

            if (vid.Username != message.LoggedOnUsername)
                return "Video deletion failed: You cannot delete this video as you are not the user who uploaded it.";

            await writeService.DeleteAsync(vid, GoBroAzureTables.VideosTableName);
            return "SUCCESS";
        }
    }
}
