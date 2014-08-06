using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWiki.SystemUtil
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
    }
}
