namespace XHOnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XHOnlineShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<XHOnlineShop.Data.XHOnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XHOnlineShop.Data.XHOnlineShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new XHOnlineShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new XHOnlineShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName = "Technology Education"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}