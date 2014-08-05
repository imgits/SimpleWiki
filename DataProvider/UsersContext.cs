using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MySql.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleWiki.ConfigSetting;
using System.Data.Common;

namespace SimpleWiki.DataProvider
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base(ConfigSetting.ConfigSettings.MYSQL_CONNECTION, false)
        {
        }


        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
