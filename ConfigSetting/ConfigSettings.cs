using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MySql.Data.Entity;
using System.Data.Common;

namespace SimpleWiki.ConfigSetting
{
    /// <summary>
    /// System global settings.
    /// </summary>
    public static class ConfigSettings
    {
        /// <summary>
        /// Get or set the system global settings.
        /// </summary>
        public static string MYSQL_CONNECTION_STRING = "server=localhost;database=simplewiki;uid=root;pwd=;";

        public static DbConnection MYSQL_CONNECTION
        {
            get
            {
                MySqlConnectionFactory factory = new MySqlConnectionFactory();
                return factory.CreateConnection(MYSQL_CONNECTION_STRING);
            }
        }
    }
}
