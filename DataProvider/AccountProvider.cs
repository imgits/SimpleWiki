using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWiki.DataProvider.Entities;
using SimpleWiki.SystemUtil;

namespace SimpleWiki.DataProvider
{
    public static class AccountProvider
    {
        /// <summary>
        /// User login process, if login success, return the user, or return the null
        /// </summary>
        /// <param name="username">login user name</param>
        /// <param name="password">login password</param>
        public static User Login(string username, string password)
        {
            using (var db = new SimpleWikiContext())
            {
                string haspwd = SecurityUtil.GetMD5Hash(password);
                return db.Users.Where(u => (u.UserName == username && u.HashPwd == haspwd)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Create the user account.
        /// </summary>
        /// <param name="username">the user name</param>
        /// <param name="password">the user password</param>
        /// <returns>return user if create success, or false.</returns>
        public static User CreateAccount(string username, string password)
        {
            using (var db = new SimpleWikiContext())
            {
                User user = new User();
                user.UserName = username;
                user.HashPwd = SecurityUtil.GetMD5Hash(password);
                user.RegTime = DateTime.Now;
                db.Users.Add(user);
                if (db.SaveChanges() > 0)
                    return user;
                else
                    return null;
            }
        }

        /// <summary>
        /// return where the user has a local user account
        /// </summary>
        /// <param name="userid">the user's id to assert.</param>
        public static bool HasLocalAccount(int userid)
        {
            using (var db = new SimpleWikiContext())
            {
                User user = db.Users.Find(userid);
                return user == null || user.HashPwd == null;
            }
        }

        /// <summary>
        /// return where the user has a local user account.
        /// </summary>
        /// <param name="username">the user's name to assert</param>
        public static bool HasLocalAccount(string username)
        {
            using (var db = new SimpleWikiContext())
            {
                User user = db.Users.Where(u => u.UserName == username).FirstOrDefault();
                return user == null || user.HashPwd == null;
            }
        }

        public static IList<User> GetOAuthAccountsFromUserName(string userName)
        {
            using (var db = new SimpleWikiContext())
            {
                return db.Users.Where(u => (u.UserName == userName && u.Provider != null)).ToList();
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

        /// <summary>
        /// Get the User by the user name.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static User GetUserByName(string username)
        {
            using (var db = new SimpleWikiContext())
            {
                return db.Users.Where(u => u.UserName == username).FirstOrDefault();
            }
        }
    }
}
