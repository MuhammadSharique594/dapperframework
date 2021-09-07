using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels.Core
{
    internal class CoreContext
    {
        internal static string GetValue(string type, object value)
        {
            if (type.ToLower().Contains("string") || type.ToLower().Contains("datetime"))
            {
                return $"'{value}'";
            }
            else
            {
                return value.ToString();
            }
        }

        internal static string ModifyQuery(string query)
        {
            var and = ExpressionType.AndAlso.ToString();
            var or = ExpressionType.OrElse.ToString();

            return query.ToString().Replace("=>", CoreDictionary.Dictionary["=>"])
                                   .Replace("==", CoreDictionary.Dictionary["=="])
                                   .Replace("\"", CoreDictionary.Dictionary["\""])
                                   .Replace(or, CoreDictionary.Dictionary[or])
                                   .Replace(and, CoreDictionary.Dictionary[and]);
        }
    }
}
