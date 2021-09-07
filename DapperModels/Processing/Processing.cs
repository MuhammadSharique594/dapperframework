using DapperModels.Models;
using System;
using System.Collections.Generic;
using DapperModels.Config;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels
{
    public partial class DapperModelCreator
    {
        private void GetDataBasesFromSql()
        {
            var serverName = ServerName.Text;
            var userName = UserName.Text;
            var password = Password.Text;


            if (!string.IsNullOrWhiteSpace(serverName) && !string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                try
                {
                    var databasesNames = _operation.GetDataBasesFromDb(serverName, userName, password);
                    DatabasesDropDown.DataSource = databasesNames;
                }
                catch
                {
                    DatabasesDropDown.DataSource = null;
                }
            }
        }

        private void StartProcessing(string databaseName)
        {
            var tableNames = _operation.GetTablesFromDb(databaseName);

            var createdTables = new Stack<string>();

            foreach (var tableName in tableNames)
            {
                if (createdTables.Contains(tableName)) continue;

                var tableDetails = _operation.GetColumnsFromTable(tableName);
                var properties = GetProperties(tableDetails);
                var forignProperties = GetProperties(_operation.GetForignKeysName(tableName));
                var template = File.ReadAllText(Configuration.GetClassFormatPath);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(OutputPath.Text, tableName + ".cs"), true))
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

        private void StartProcessing(string databaseName, bool flag)
        {
            var tableNames = _operation.GetTablesFromDb(databaseName);
        }

        private string GetProperties(IEnumerable<Table> columns)
        {
            var properties = new StringBuilder();

            var template = File.ReadAllText(Configuration.GetClassPropertiesFormatPath);

            foreach(var col in columns)
            {
                var temp = template;
                temp = temp.Replace("{Name}", col.Name).Replace("{Type}", GetType(col.Type));
                properties.Append(temp).Append(Environment.NewLine);
            }

            return properties.ToString();
        }

        private string GetProperties(IEnumerable<string> columns)
        {
            var template = File.ReadAllText(Configuration.GetClassPropertiesFormatPath);
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

        private string GetType(string type)
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
