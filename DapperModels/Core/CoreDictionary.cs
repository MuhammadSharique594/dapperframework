using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels.Core
{
    internal class CoreDictionary
    {
        internal static Dictionary<string, string> Dictionary = new Dictionary<string, string>
        {
            { "=>", "WHERE"},
            { "=> ", "SET "},
            { "==", "="},
            { "\"", "'"},
            { ExpressionType.AndAlso.ToString(), "AND"},
            { ExpressionType.OrElse.ToString(), "OR"}
        };
    }
}
