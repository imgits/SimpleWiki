using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SimpleWiki.DataProvider.Entities
{
    /// <summary>
    /// The article's section type
    /// </summary>
    public enum SectionType
    {
        Paragraph
    }

    /// <summary>
    /// The article user publish
    /// </summary>
    public class Article
    {
        public Article()
        {
            Sections = new List<Section>();
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ArticleID { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        public DateTime PublishTime { get; set; }

        public User User { get; set; }

        public virtual IList<Section> Sections { get; set; }
    }

    /// <summary>
    /// The section of the article
    /// </summary>
    public class Section
    {
        public Section()
        {
            this.SubSections = new List<Section>();
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long SectionID { get; set; }

        public string Content { get; set; }

        [MaxLength(100)]
        public string SectionTitle { get; set; }

        public SectionType SectionType { get; set; }

        [ForeignKey("SubSections")]
        public Nullable<long> OwnedSectionID { get; set; }

        public virtual IList<Section> SubSections { get; set; }
        public virtual Section ParentSection { get; set; }
        public virtual Article OwnedArticle { get; set; }
    }
}
