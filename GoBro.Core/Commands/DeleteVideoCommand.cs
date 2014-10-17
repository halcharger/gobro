using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Commands
{
    public class DeleteVideoCommand : IAsyncRequest
    {
        public string Id { get; set; }
    }
}
