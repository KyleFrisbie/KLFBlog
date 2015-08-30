using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KLFBlog.DAL;
using KLFBlog.Models;

namespace KLFBlog.Controllers
{
    public class BlogPostsAPIController : ApiController
    {
        private KLFBlogDb db = new KLFBlogDb();

        // GET: api/BlogPostsAPI
        [Route("api/blogposts")]
        public IEnumerable<BlogPostViewModel> GetBlogPosts()
        {
            var posts = db.BlogPosts
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
            return posts;
        }

        [Route("api/blogposts/{id}")]
        // GET: api/BlogPostsAPI/5
        [ResponseType(typeof(BlogPost))]
        public IHttpActionResult GetBlogPost(int id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        //// PUT: api/BlogPostsAPI/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBlogPost(int id, BlogPost blogPost)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != blogPost.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(blogPost).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BlogPostExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/BlogPostsAPI
        //[ResponseType(typeof(BlogPost))]
        //public IHttpActionResult PostBlogPost(BlogPost blogPost)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.BlogPosts.Add(blogPost);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = blogPost.Id }, blogPost);
        //}

        //// DELETE: api/BlogPostsAPI/5
        //[ResponseType(typeof(BlogPost))]
        //public IHttpActionResult DeleteBlogPost(int id)
        //{
        //    BlogPost blogPost = db.BlogPosts.Find(id);
        //    if (blogPost == null)
        //    {
        //        return NotFound();
        //    }

        //    db.BlogPosts.Remove(blogPost);
        //    db.SaveChanges();

        //    return Ok(blogPost);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool BlogPostExists(int id)
        //{
        //    return db.BlogPosts.Count(e => e.Id == id) > 0;
        //}
    }
}