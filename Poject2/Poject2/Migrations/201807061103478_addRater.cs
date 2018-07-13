namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRater : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "RaterId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "RaterId");
        }
    }
}
