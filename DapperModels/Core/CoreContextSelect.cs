using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels.Core
{
    internal partial class CoreContextQuery
    {
        internal static string SelectWhere<T>(Expression<Predicate<T>> expression)
        {
            var tableName = typeof(T).Name;

            var query = new StringBuilder($"Select * FROM {tableName} ")
                .Append(CoreContext.ModifyQuery(expression.ToString()));

            return query.ToString();
        }

        internal static string SelectAll<T>()
        {
            var tableName = typeof(T).Name;

            var query = new StringBuilder($"Select * FROM {tableName};");

            return query.ToString();
        }

        internal static string SelectFirstOrDefault<T>(Expression<Predicate<T>> expression)
        {
            var tableName = typeof(T).Name;

            var query = new StringBuilder($"Select * FROM {tableName} ")
                .Append(CoreContext.ModifyQuery(expression.ToString()));

            return query.ToString();
        }
    }
}
