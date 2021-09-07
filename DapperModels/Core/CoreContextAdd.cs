using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels.Core
{
    internal partial class CoreContextQuery
    {
        internal static string GetAddQuery<T>(T obj)
        {
            var type = typeof(T);
            var tableName = type.Name;
            var properties = type.GetProperties();

            var query = new StringBuilder($"INSERT INTO {tableName} (");

            for (var i = 1; i < properties.Length; i++)
            {
                query.Append($"{properties[i].Name}, ");
            }

            query.Remove(query.Length - 2, 2);
            query.Append(") Values (");

            for (var i = 1; i < properties.Length; i++)
            {
                query.Append($"{CoreContext.GetValue(properties[i].PropertyType.Name, properties[i].GetValue(obj))}, ");
            }

            query.Remove(query.Length - 2, 2);
            query.Append(");");

            return query.ToString();
        }

        internal static string SelectQuery<T>(T obj)
        {
            var type = typeof(T);
            var tableName = type.Name;
            var properties = type.GetProperties();

            return string.Empty;
        }
    }
}
