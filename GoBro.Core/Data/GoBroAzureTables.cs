using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Data
{
    public class GoBroAzureTables
    {
        public const string VideosTableName = "videos";

        private readonly CloudTable videosTable;

        public GoBroAzureTables() : this("VideoStore.ConnectionString") { }
        public GoBroAzureTables(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            videosTable = tableClient.GetTableReference(VideosTableName);

            //need to configure this so we don't run it each and everytime
            videosTable.CreateIfNotExists();
        }

        public CloudTable VideosTable { get { return videosTable; } }
    }
}
