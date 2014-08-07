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
                article.User = user;
                article.PublishTime = DateTime.Now;

                db.Articles.Add(article);
                db.SaveChanges();
                return article;
            }
        }
    }
}
