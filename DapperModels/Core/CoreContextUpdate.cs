using System.Text;

namespace DapperModels.Core
{
    internal partial class CoreContextQuery
    {
        internal static string Update<T>(T obj)
        {
            var tableName = typeof(T).Name;




            var query = new StringBuilder($"UPDATE {tableName} ");
                //.Append(CoreContext.ModifyQuery(expression.ToString()
                //        .Replace("=> ", CoreDictionary.Dictionary["=> "])));

            return query.ToString();
        }
    }
}
