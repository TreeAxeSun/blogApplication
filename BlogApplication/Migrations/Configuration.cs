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

        protected override void Seed(Models.ApplicationDbContext context)
        {
            // Classes to work with users and roles (provided by Microsoft packages)
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            

            //Check if the roles are already created.
            //If not, create them.
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(p => p.UserName == "veris@naver.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "veris@naver.com",
                    Email = "veris@naver.com",
                    FirstName = "YoungSeok",
                    LastName = "Ahn",
                    DisplayName = "YoungSeok-Ahn",
                }, "Aysmkilt10@");
            }
            if (!context.Users.Any(p => p.UserName == "veris1975@outlook.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "veris1975@outlook.com",
                    Email = "veris1975@outlook.com",
                    FirstName = "YS",
                    LastName = "A",
                    DisplayName = "YS-A",
                }, "Aysmkilt10@");
            }

            var adminId = userManager.FindByEmail("veris1975@outlook.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var moderatorId = userManager.FindByEmail("veris@naver.com").Id;
            userManager.AddToRole(moderatorId, "Moderator");
        }
    }
}