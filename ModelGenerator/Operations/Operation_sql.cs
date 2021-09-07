using Dapper;
using ModelGenerator.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ModelGenerator.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using ModelGenerator.Interfaces;

namespace ModelGenerator.Operations
{
    internal class Operation_sql : IOperation
    {
        IEnumerable<string> IOperation.GetTablesFromDb(string databaseName)
        {
            using (var con = new SqlConnection(Configuration.ConnectionString))
            {
                con.Open();
                con.Query("SELECT Table_Name FROM Information_Schema.Tables");
                return con.Query<string>("SELECT Table_Name FROM Information_Schema.Tables");
            }
        }

        IEnumerable<Table> IOperation.GetColumnsFromTable(string tableName)
        {
            using (var con = new SqlConnection(Configuration.ConnectionString))
            {
                con.Open();
                return con.Query<Table>($"SELECT Column_Name Name, Data_Type Type from Information_Schema.COLUMNS WHERE TABLE_NAME = '{tableName}'");
            }
        }

        IEnumerable<string> IOperation.GetForignKeysName(string tableName)
        {
            using (var con = new SqlConnection(Configuration.ConnectionString))
            {
                con.Open();
                return con.Query<string>($"SELECT OBJECT_NAME (fk.referenced_object_id) AS Referenced_Table_Name FROM sys.foreign_keys fk INNER JOIN sys.objects o ON fk.referenced_object_id = o.object_id where OBJECT_NAME(fk.parent_object_id) = '{tableName}'");
            }
        }

	    string IOperation.IsIdentity(string tableName)
	    {
		    using (var con = new SqlConnection(Configuration.ConnectionString))
		    {
				con.Open();
				return con.QueryFirstOrDefault<string>($"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where COLUMNPROPERTY(object_id(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 and TABLE_NAME = '{tableName}'");
		    }
	    }
	}
}
