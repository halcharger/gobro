﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NExtensions;

namespace GoBro.Core.Models
{
    public class Video : TableEntity
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string YoutubeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void SetPartionAndRowKeys()
        {
            Username.ThrowIfNullOrEmpty("Username");
            Id.ThrowIfNullOrEmpty("Id");

            PartitionKey = Username;
            RowKey = Id;
        }

    }
}
