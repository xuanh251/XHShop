namespace XHOnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XHOnlineShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<XHOnlineShop.Data.XHOnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XHOnlineShopDbContext context)
        {
            CreateProductSample(context);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new XHOnlineShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new XHOnlineShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "tedu",
            //    Email = "tedu.international@gmail.com",
            //    EmailConfirmed = true,
            //    Birthday = DateTime.Now,
            //    FullName = "Technology Education"

            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

        }
        //private void CreateProductCategorySample(XHOnlineShopDbContext context)
        //{
        //    if (context.ProductCategories.Count() == 0)
        //    {
        //        List<ProductCategory> list = new List<ProductCategory>()
        //        {
        //            new ProductCategory(){Name="Máy tính",Alias="may-tinh",Status=true},
        //            new ProductCategory(){Name="Điện thoại",Alias="dien-thoai",Status=true},
        //            new ProductCategory(){Name="Đồ gia dụng",Alias="do-gia-dung",Status=true},
        //            new ProductCategory(){Name="Nội thất",Alias="noi-that",Status=true},
        //        };
        //        context.ProductCategories.AddRange(list);
        //        context.SaveChanges();
        //    }
        //}
        private void CreateProductSample(XHOnlineShopDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> list = new List<Product>()
                {
                    new Product(){Name="Laptop Dell",Alias="laptop-dell",CreatedDate=DateTime.Now,CategoryID=1,Price=3000000,Status=true},
                    new Product(){Name="Laptop Asus",Alias="laptop-asus",CreatedDate=DateTime.Now,CategoryID=1,Price=2000000,Status=false},
                    new Product(){Name="Điện thoại Nokia 8",Alias="dien-thoai-nokia-8",CreatedDate=DateTime.Now,CategoryID=2,Price=7000000,Status=true},
                };
                context.Products.AddRange(list);
                context.SaveChanges();
            }
        }

    }
}