namespace XHOnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "ParentID", c => c.Int());
            AlterColumn("dbo.ProductCategories", "DisplayOrder", c => c.Int());
            AlterColumn("dbo.ProductCategories", "HomeFlag", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "HomeFlag", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductCategories", "DisplayOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategories", "ParentID", c => c.Int(nullable: false));
        }
    }
}
