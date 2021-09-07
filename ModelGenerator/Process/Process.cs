using ModelGenerator.Interfaces;
using ModelGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ModelGenerator.Config;
using ModelGenerator.Operations;

namespace ModelGenerator.Process
{
    public static class Process
    {
        private static IOperation _operations;

        private static void Initialise(IOperation operations)
        {
            _operations = operations;
        }

        static Process()
        {
            Initialise(new Operation_sql());
        }

        public static void StartProcessing(string databaseName, string outputPath)
        {
            try
            {
                var tableNames = _operations.GetTablesFromDb(databaseName);

                var createdTables = new Stack<string>();

                foreach (var tableName in tableNames)
                {
                    if (createdTables.Contains(tableName)) continue;

                    var tableDetails = _operations.GetColumnsFromTable(tableName);
                    var properties = GetProperties(tableDetails, tableName);
                    var forignProperties = GetProperties(_operations.GetForignKeysName(tableName));
                    var template = Configuration.GetClassFormat;

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(outputPath, tableName + ".cs"), true))
                    {
                        var temp = template.Replace("{databaseName}", databaseName)
                                           .Replace("{className}", tableName)
                                           .Replace("{properties}", properties)
                                           .Replace("{forignKeys}", forignProperties);
                        outputFile.WriteLine(temp);
                    }

                    createdTables.Push(tableName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Internal error occured, please contact to shariquekhan594@hotmail.com!");
            }
        }

        private static string GetProperties(IEnumerable<Table> columns, string tableName)
        {
            var properties = new StringBuilder();

            var template = Configuration.GetClassPropertiesFormat;
	        var identityColumn = _operations.IsIdentity(tableName);

			foreach (var col in columns)
            {
                var temp = template;
                temp = temp.Replace("{Name}", col.Name).Replace("{Type}", GetType(col.Type));

	            if (col.Name.Equals(identityColumn))
	            {
					properties.Append("		[Identity]\n");
	            }

                properties.Append(temp).Append(Environment.NewLine);
            }

            return properties.ToString();
        }

        private static string GetProperties(IEnumerable<string> columns)
        {
            var template = Configuration.GetClassPropertiesFormat;
            if (columns != null)
            {
                var properties = new StringBuilder();

                foreach (var col in columns)
                {
                    var temp = template;
                    temp = temp.Replace("{Name}", col).Replace("{Type}", $"List<{col}>");
                    properties.Append(temp).Append(Environment.NewLine);
                }

                return properties.ToString();
            }

            return string.Empty;
        }

        private static string GetType(string type)
        {
            type = type.ToLower();

            if (type.Equals("bigint"))
            {
                return "long";
            }
            else if (type.Equals("int"))
            {
                return type;
            }
            else if (type.Contains("decimal"))
            {
                return "decimal";
            }
            else if (type.Equals("datatime") || type.Contains("date") || type.Contains("time"))
            {
                return "DateTime";
            }
            else
            {
                return "string";
            }
        }
    }
}
