using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleWiki.Web.Models;
using SimpleWiki.DataProvider;

namespace SimpleWiki.Web.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Summary()
        {
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
            return View(model);
        }
    }
}
