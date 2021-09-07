using ModelGenerator.Models;
using System.Collections.Generic;

namespace ModelGenerator.Interfaces
{
    internal interface IOperation
    {
        IEnumerable<string> GetTablesFromDb(string databaseName);
        IEnumerable<Table> GetColumnsFromTable(string table);
        IEnumerable<string> GetForignKeysName(string tableName);
	    string IsIdentity(string tableName);
    }
}
