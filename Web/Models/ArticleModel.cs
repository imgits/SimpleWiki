using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleWiki.Web.Models
{
    public class CreateArticleModel
    {
        [Required]
        public string Title { get; set; }
    }

    public class ArticleDetailModel
    {
        public string UserName { get; set; }

        public string Title { get; set; }
    }
}