﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Commands
{
    public class UploadVideoCommand : IAsyncRequest<UploadVideoResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string YoutubeId { get; set; }
        public string Username { get; set; }
    }
}
