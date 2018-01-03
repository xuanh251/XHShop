namespace XHOnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Tags", c => c.String());
            AddColumn("dbo.Posts", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Tags");
            DropColumn("dbo.Products", "Tags");
        }
    }
}
