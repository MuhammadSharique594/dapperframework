using DapperModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels.Operations.Interfaces
{
    public interface IOperation
    {
        IEnumerable<string> GetDataBasesFromDb(string dataSource, string userName, string password);
        IEnumerable<string> GetTablesFromDb(string databaseName);
        IEnumerable<Table> GetColumnsFromTable(string table);
        IEnumerable<string> GetForignKeysName(string tableName);
    }
}
