﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KLFBlog.DAL;
using KLFBlog.Models;

namespace KLFBlog.Controllers
{
    [Authorize]
    public class BlogPostsController : Controller
    {
        private KLFBlogDb db = new KLFBlogDb();

        [AllowAnonymous]
        public ActionResult Autocomplete(string term)
        {
            var model =
                db.BlogPosts
                    .Where(b => b.Title.StartsWith(term))
                    .Select(b => new
                    {
                        label = b.Title
                    });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Posts(string searchTerm)
        {
            var model =
                db.BlogPosts
                    .Where(b => searchTerm == null || b.Title.Contains(searchTerm))
                    .OrderByDescending(b => b.Date)
                    .Select(b => new BlogPostViewModel
                    {
                        Id = b.Id,
                        Title = b.Title,
                        SubTitle = b.SubTitle,
                        Date = b.Date,
                        Tags = b.Tags,
                        Image = b.Image,
                        PostBody = b.PostBody,
                    });

            ViewBag.display = "Group";

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Posts", model);
            }

            return View(model);
        }


        [AllowAnonymous]
        public ActionResult _Posts(int id)
        {
            var model =
                db.BlogPosts
                    .Where(b => b.Id.Equals(id))
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

            ViewBag.display = "Single";

            return View("Posts", model);
        }

        // GET: BlogPosts
        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,SubTitle,Date,Image,PostBody")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.BlogPosts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,SubTitle,Date,Image,PostBody")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
