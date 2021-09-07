using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperModels.Config
{
    static class Configuration
    {
        private static string _dataSource;
        private static string _userName;
        private static string _password;
        private static string _catalog;

        public static string GetConnectionString(string dataSource, string userName, string password)
        {
            _dataSource = dataSource;
            _userName = userName;
            _password = password;

            return $"Data Source={dataSource};User ID={userName};Password={password}";
        }

        public static string GetConnectionString(string catalog)
        {
            _catalog = catalog;
            return $"Data Source={_dataSource};Initial Catalog={catalog};User ID={_userName};Password={_password}";
        }

        public static string GetConnectionString()
        {
            return $"Data Source={_dataSource};Initial Catalog={_catalog};User ID={_userName};Password={_password}";
        }

        public static string GetClassFormatPath
        {
            get
            {
                return Path.GetDirectoryName(Environment.CurrentDirectory).Replace("bin", "Format\\ClassFormat.txt");
            }
        }

        public static string GetClassPropertiesFormatPath
        {
            get
            {
                return Path.GetDirectoryName(Environment.CurrentDirectory).Replace("bin", "Format\\ColumnFormat.txt");
            }
        }
    }
}
