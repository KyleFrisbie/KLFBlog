﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLFBlog.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string Image { get; set; }
        [AllowHtml]
        public string PostBody { get; set; }
    }
}