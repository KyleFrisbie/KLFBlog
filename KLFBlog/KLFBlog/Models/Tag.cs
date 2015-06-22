using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLFBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BlogPost> Posts { get; set; }
    }
}
