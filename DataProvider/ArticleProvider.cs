using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWiki.DataProvider.Entities;
using SimpleWiki.SystemUtil;

namespace SimpleWiki.DataProvider
{
    public static class ArticleProvider
    {
        /// <summary>
        /// User create a new article
        /// </summary>
        /// <param name="user"></param>
        /// <param name="title"></param>        
        public static Article CreateArticle(User user, string title)
        {
            using (var db = new SimpleWikiContext())
            {
                Article article = new Article();
                article.Title = title;
                article.OwnedUserID = user.UserID;
                article.PublishTime = DateTime.Now;

                db.Articles.Add(article);
                db.SaveChanges();
                return article;
            }
        }

        /// <summary>
        /// Get the article by the user name and title.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="title"></param>
        public static Article GetArticle(string username, string title)
        {
            using (var db = new SimpleWikiContext())
            {
                User user = db.Users.Where(u => u.UserName == username).FirstOrDefault();
                if (user != null)
                    return db.Articles.Where(a => a.OwnedUserID == user.UserID).FirstOrDefault();
                else
                    return null;
            }
        }

        /// <summary>
        /// Get the user's articles list.
        /// </summary>
        /// <param name="username"></param>
        public static IList<Article> GetUserArticles(string username)
        {
            using (var db = new SimpleWikiContext())
            {
                User user=db.Users.Where(u=>u.UserName == username).FirstOrDefault();
                if (user != null)
                    return db.Articles.Where(a => a.OwnedUserID == user.UserID).ToList();
                else
                    return null;
            }
        }
    }
}
