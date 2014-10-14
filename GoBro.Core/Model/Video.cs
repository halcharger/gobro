using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Model
{
    public class Video : TableEntity
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string YoutubeLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void SetPartionAndRowKeys()
        {
            PartitionKey = Id;
            RowKey = Id;
        }

    }
}
