using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BlogApplication.Controllers
{
    [RequireHttps]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>({1})</p><p> Message:</p><p>{2}</p>";
                    var from = WebConfigurationManager.AppSettings["username"];
                    model.Body = "This is a message from your portfolio site. The name and the email of the contacting person is above.";

                    var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = "Portfolio Contact Email",
                        Body = string.Format(body, model.FromName, model.FromEmail, model.Body),
                        IsBodyHtml = true
                    };

                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);

                    return View(new EmailModel());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }


        public ActionResult Contact()
        {
            EmailModel model = new EmailModel();
            return View(model);

            //ViewBag.Message = "Your contact page.";
            //return View();
        }
    }
}