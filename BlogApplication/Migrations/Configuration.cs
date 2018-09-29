namespace BlogApplication.Migrations
{
    using BlogApplication.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogApplication.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moder"))
            {
                roleManager.Create(new IdentityRole { Name = "Moder" });
            }

            if (!context.Users.Any(p => p.Email == "veris49@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "veris49@gmail.com",
                    Email = "veris49@gmail.com",
                    FirstName = "YS",
                    LastName = "Ahn",
                    DisplayName = "Master"
                }, "Adminuser@1");
            }

            if (!context.Users.Any(p => p.Email == "sophia1975@naver.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "sophia1975@naver.com",
                    Email = "sophia1975@naver.com",
                    FirstName = "Sophia",
                    LastName = "Lee",
                    DisplayName = "Sophie"
                }, "Moders1234@");
            }

            var adminId = userManager.FindByEmail("veris49@gmail.com").Id;
            userManager.AddToRole(adminId, "Admin");


            var moderId = userManager.FindByEmail("sophia1975@naver.com").Id;
            userManager.AddToRole(moderId, "Moder");

        }
    }
}