using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Commands
{
    public class DeleteVideoCommand : IAsyncRequest<string>
    {
        public string Id { get; set; }
        public string VideoUsername { get; set; }
        public string LoggedOnUsername { get; set; }
    }
}
