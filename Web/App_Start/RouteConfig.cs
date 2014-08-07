using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleWiki.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "articleoperate",
                url: "article/operate/{action}/{parameters}",
                defaults: new { controller = "Article", parameters = UrlParameter.Optional }
            );

            routes.MapRoute(name: "articlesummary",
                url: "article/{username}",
                defaults: new { controller = "Article", action = "Summary" }
            );

            routes.MapRoute(name: "articledetail",
                url: "article/{username}/{title}",
                defaults: new { controller = "Article", action = "Detail" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}