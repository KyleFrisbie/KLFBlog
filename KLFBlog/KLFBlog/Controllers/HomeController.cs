using KLFBlog.DAL;
using KLFBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLFBlog.Controllers
{
    public class HomeController : Controller
    {
        KLFBlogDb _db = new KLFBlogDb();

        //public ActionResult Autocomplete(string term)
        //{
        //    var model =
        //        _db.BlogPosts
        //            .Where(b => b.Title.StartsWith(term))
        //            .Select(b => new
        //            {
        //                label = b.Title
        //            });
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Index()
        {
            var model =
                _db.BlogPosts
                    .Select(b => new BlogPostViewModel
                    {
                        Id = b.Id,
                        Title = b.Title,
                        SubTitle = b.SubTitle,
                        Date = b.Date,
                        Tags = b.Tags,
                        Image = b.Image,
                        PostBody = b.PostBody
                    });

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}