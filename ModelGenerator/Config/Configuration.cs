using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelGenerator.Config
{
    public static class Configuration
    {
        private static string _connectionString;
        private static Lazy<Assembly> _assembly = new Lazy<Assembly>(() => Assembly.LoadFile($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\ModelGenerator.dll"));
        public static string ConnectionString
        {
            internal get; set;
        }

        internal static string GetClassFormat
        {
            get
            {
                return GetFile("ClassFormat");
            }
        }

        internal static string GetClassPropertiesFormat
        {
            get
            {
                return GetFile("ColumnFormat");
            }
        }

        private static string GetFile(string fileName)
        {
            using (var stream = _assembly.Value.GetManifestResourceStream($"ModelGenerator.Format.{fileName}.txt"))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
