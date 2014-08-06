using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWiki.DataProvider;
using SimpleWikiUser = SimpleWiki.DataProvider.Entities.User;

namespace SimpleWiki.WebUtil
{
    public static class WikiSecurity
    {
        public static SimpleWikiUser Login(string username, string password, bool rememberMe)
        {
            return null;
        }

        public static SimpleWikiUser CreateAccountAndLogin(string username, string password)
        {
            SimpleWikiUser user = AccountProvider.CreateAccount(username, password);
            return user;
        }

        public static void Logout()
        {
        }
    }
}
