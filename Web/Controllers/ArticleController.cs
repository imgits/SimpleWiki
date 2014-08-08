using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleWiki.Web.Models;
using SimpleWiki.DataProvider;
using SimpleWiki.DataProvider.Entities;

namespace SimpleWiki.Web.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Summary(string username)
        {
            ViewBag.UserName = username;
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            return PartialView("_CreateArticlePartial");
        }

        public ActionResult Create(CreateArticleModel model)
        {
            ArticleProvider.CreateArticle(AccountProvider.GetUserByName(User.Identity.Name), model.Title);
            return Redirect("/article/" + User.Identity.Name + "/" + model.Title);
        }

        public ActionResult Detail(ArticleDetailModel model)
        {
            Article article = ArticleProvider.GetArticle(model.UserName, model.Title);
            return View(article);
        }

        public ActionResult ArticleList(string username)
        {
            IList<Article> articles = ArticleProvider.GetUserArticles(username);
            return PartialView("_ArticleListPartial", articles);
        }
    }
}
