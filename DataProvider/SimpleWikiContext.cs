using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MySql.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleWiki.SystemUtil;
using System.Data.Common;
using SimpleWiki.DataProvider.Entities;

namespace SimpleWiki.DataProvider
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SimpleWikiContext : DbContext
    {
        public SimpleWikiContext()
            : base(DbUtil.Connection, false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriend>().HasRequired(f => f.Master).WithMany(u=>u.UserFriends).Map(m => m.MapKey("MasterID"));
            modelBuilder.Entity<UserFriend>().HasRequired(f => f.Friend).WithMany().Map(m => m.MapKey("FriendID"));
            modelBuilder.Entity<UserFriend>().HasRequired(f => f.Group).WithMany(g => g.UserFriends).Map(m => m.MapKey("GroupID"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAppend> UserAppends { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
