using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using MySql.Data.Entity;
using SimpleWiki.SystemUtil;

namespace SimpleWiki.DataProvider
{
    public static class DbUtil
    {
        private static DbConnection _connection;

        /// <summary>
        /// Get the mysql connection.
        /// </summary>
        public static DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    MySqlConnectionFactory factory = new MySqlConnectionFactory();
                    _connection = factory.CreateConnection(ConfigSettings.MYSQL_CONNECTION_STRING);
                }

                return _connection;
            }
        }
    }
}
