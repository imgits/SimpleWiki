using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWiki.DataProvider.Entities;

namespace SimpleWiki.DataProvider
{
    public static class AccountProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Login(string username, string password)
        {
            using (var db = new SimpleWikiContext())
            {
                return db.Users.Where(u => (u.UserName == username && u.Password == password)).FirstOrDefault();
            }
        }

        public static User CreateAccount(string username, string password)
        {
            using (var db = new SimpleWikiContext())
            {
                User user = new User();
                user.UserName = username;
                user.Password = password;
                user.RegTime = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }

        public static bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return true;
        }

        public static int GetUserId(string username)
        {
            return 0;
        }
    }
}
