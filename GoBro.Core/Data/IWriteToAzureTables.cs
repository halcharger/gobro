using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBro.Core.Data
{
    public interface IWriteToAzureTables
    {
        Task<TableResult> InsertAsync<T>(T entity, string tableName) where T : TableEntity;
    }
}
