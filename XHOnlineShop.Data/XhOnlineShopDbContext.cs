using System.Data.Entity;
using XHOnlineShop.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XHOnlineShop.Data
{
    public class XHOnlineShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public XHOnlineShopDbContext() : base("XHOnlineShopConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }

        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }

        public DbSet<Tag> Tags { set; get; }

        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }

        public static XHOnlineShopDbContext Create()
        {
            return new XHOnlineShopDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(s=>new {s.RoleId, s.UserId}).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(s => s.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(s => s.UserId).ToTable("ApplicationUserClaims");
        }
    }
}