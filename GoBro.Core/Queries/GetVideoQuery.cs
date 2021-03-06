﻿using GoBro.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Queries
{
    public class GetVideoQuery : IAsyncRequest<Video>
    {
        public string Username { get; set; }
        public string Id { get; set; }
    }
}
