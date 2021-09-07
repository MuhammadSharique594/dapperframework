using Dapper;
using DapperModels.Operations.Interfaces;
using DapperModels.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DapperModels.Models;
using System;
using DapperModels.Core;
using System.Linq.Expressions;

namespace DapperModels.Operations
{
    class Operation_sql : IOperation
    {
        public IEnumerable<string> GetDataBasesFromDb(string dataSource, string userName, string password)
        {
            using (var con = new SqlConnection(Configuration.GetConnectionString(dataSource, userName, password)))
            {
                con.Open();
                return con.Query<string>("SELECT Name FROM master.dbo.sysdatabases");
            }
        }

        public IEnumerable<string> GetTablesFromDb(string databaseName)
        {
            using (var con = new SqlConnection(Configuration.GetConnectionString(databaseName)))
            {
                con.Open();
                con.Query("SELECT Table_Name FROM Information_Schema.Tables");
                return con.Query<string>("SELECT Table_Name FROM Information_Schema.Tables");
            }
        }

        public IEnumerable<Table> GetColumnsFromTable(string tableName)
        {
            using (var con = new SqlConnection(Configuration.GetConnectionString()))
            {
                con.Open();
                return con.Query<Table>($"SELECT Column_Name Name, Data_Type Type from Information_Schema.COLUMNS WHERE TABLE_NAME = '{tableName}'");
            }
        }

        public IEnumerable<string> GetForignKeysName(string tableName)
        {
            using (var con = new SqlConnection(Configuration.GetConnectionString()))
            {
                con.Open();
                return con.Query<string>($"SELECT OBJECT_NAME (fk.referenced_object_id) AS Referenced_Table_Name FROM sys.foreign_keys fk INNER JOIN sys.objects o ON fk.referenced_object_id = o.object_id where OBJECT_NAME(fk.parent_object_id) = '{tableName}'");
            }
        }
    }

    //public static class Context
    //{
    //    private static string _connectionString;

    //    public static string ConnectionString
    //    {
    //        set
    //        {
    //            _connectionString = value;
    //        }
    //    }

    //    #region Add

    //    public static void AddIntoDb<T>(T obj)
    //    {
    //        if (string.IsNullOrEmpty(_connectionString)) throw new ApplicationException("Connection string is not defined!");

    //        using (var connection = new SqlConnection(_connectionString))
    //        {
    //            connection.Open();
    //            connection.Query(CoreContextAdd.GetAddQuery<T>(obj));
    //        }
    //    }

    //    #endregion

    //    #region Select

    //    public static IEnumerable<T> SelectWhere<T>(Expression<Predicate<T>> expression)
    //    {
    //        if (string.IsNullOrEmpty(_connectionString)) throw new ApplicationException("Connection string is not defined!");

    //        using (var connection = new SqlConnection(_connectionString))
    //        {
    //            connection.Open();
    //            return connection.Query<T>(CoreContextSelect.SelectWhere(expression));
    //        }
    //    }

    //    public static IEnumerable<T> SelectAll<T>()
    //    {
    //        if (string.IsNullOrEmpty(_connectionString)) throw new ApplicationException("Connection string is not defined!");

    //        using (var connection = new SqlConnection(_connectionString))
    //        {
    //            connection.Open();
    //            return connection.Query<T>(CoreContextSelect.SelectAll<T>());
    //        }
    //    }

    //    public static IEnumerable<T> SelectFirstOrDefault<T>(Expression<Predicate<T>> expression)
    //    {
    //        if (string.IsNullOrEmpty(_connectionString)) throw new ApplicationException("Connection string is not defined!");

    //        using (var connection = new SqlConnection(_connectionString))
    //        {
    //            connection.Open();
    //            return connection.Query<T>(CoreContextSelect.SelectWhere(expression));
    //        }
    //    }

    //    #endregion


    //    public static void Update<T>(T obj)
    //    {
    //        if (string.IsNullOrEmpty(_connectionString)) throw new ApplicationException("Connection string is not defined!");

    //        using (var connection = new SqlConnection(_connectionString))
    //        {
    //            connection.Open();
    //            connection.Query(CoreContextQuery.Update());
    //        }
    //    }

    //    private static string GetUpdateQuery<T>(T obj)
    //    {
    //        var type = typeof(T);
    //        var tableName = type.Name;
    //        var properties = type.GetProperties();

    //        var query = new StringBuilder($"Select {tableName} ");

    //        for (var i = 1; i < properties.Length; i++)
    //        {
    //            query.Append($"{properties[i].Name}, ");
    //        }

    //        query.Remove(query.Length - 1, 1);

    //        return string.Empty;
    //    }



    //}
}
