using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            /*var post = new BlogPost();
            post.Body = "this is the body";
            post.Created = DateTime.Now;
            post.Published = true;
            post.Title = "this is the title";

            var context = ApplicationDbContext.Create();

            //context.Posts.Add(post);
            //context.SaveChanges();

            //var post = context.Posts.Where(p => p.Id == 1).FirstOrDefault();

            //post.Title = "this is my new title";

            //var comment = new Comment();
            //comment.Body = "body";
            //comment.BlogPostId = 1;
            //comment.AuthorId = "";
            //context.Comments.Add(comment);

            var comment = context.Comments.Where(p => p.Id == 2).FirstOrDefault();


            context.SaveChanges();*/

            return View(db.Posts.ToList());
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
    }
}