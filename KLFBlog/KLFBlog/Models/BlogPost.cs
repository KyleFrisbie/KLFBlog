using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KLFBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string Image { get; set; }
        public string PostBody { get; set; }
    }
}