using GoBro.Core.Commands;
using GoBro.Core.Data;
using GoBro.Core.Models;
using MediatR;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.CommandHandlers
{
    public class UploadVideoCommandHandler : IAsyncRequestHandler<UploadVideoCommand, UploadVideoResult>
    {
        private readonly IWriteToAzureTables tables;

        public UploadVideoCommandHandler(IWriteToAzureTables tables)
        {
            this.tables = tables;
        }

        public async Task<UploadVideoResult> Handle(UploadVideoCommand message)
        {
            var vid = new Video();
            vid.Id = Guid.NewGuid().ToString();
            vid.Title = message.Title;
            vid.Description = message.Description;
            vid.SetPartionAndRowKeys();
            vid.YoutubeLink = message.YoutubeLink;

            await tables.InsertAsync(vid, GoBroAzureTables.VideosTableName);

            return new UploadVideoResult { VideoId = vid.Id };
        }
    }
}
