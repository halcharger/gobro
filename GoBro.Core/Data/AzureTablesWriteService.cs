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
    public class AzureTablesWriteService : IWriteToAzureTables
    {
        private readonly GoBroAzureTables tables;

        public AzureTablesWriteService(GoBroAzureTables tables)
        {
            this.tables = tables;
        }

        public async Task<TableResult> InsertAsync<T>(T entity, string tableName) where T : TableEntity
        {
            var insertOperation = TableOperation.Insert(entity);
            return await tables.VideosTable.ExecuteAsync(insertOperation);
        }


        public async Task<TableResult> DeleteAsync<T>(T entity, string tableName) where T : TableEntity
        {
            var deleteOperation = TableOperation.Delete(entity);
            return await tables.VideosTable.ExecuteAsync(deleteOperation);
        }
    }
}
