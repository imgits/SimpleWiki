using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWiki.DataProvider;
using System.Web;
using System.Web.Security;
using SimpleWikiUser = SimpleWiki.DataProvider.Entities.User;

namespace SimpleWiki.WebUtil
{
    public static class WikiSecurity
    {
        public static SimpleWikiUser Login(string username, string password, bool rememberMe)
        {
            SimpleWikiUser user = AccountProvider.Login(username, password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
            }
            return user;
        }

        public static SimpleWikiUser CreateAccountAndLogin(string username, string password)
        {
            SimpleWikiUser user = AccountProvider.CreateAccount(username, password);
            if (user != null)
                FormsAuthentication.SetAuthCookie(username, false);
            return user;
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
