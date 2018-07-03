namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Days", "Times_id", "dbo.Times");
            DropIndex("dbo.Days", new[] { "Times_id" });
            AddColumn("dbo.Students", "Timesid", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Timesid");
            AddForeignKey("dbo.Days", "Times_id", "dbo.Times", "id");
            AddForeignKey("dbo.Students", "Timesid", "dbo.Times", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Timesid", "dbo.Times");
            DropForeignKey("dbo.Days", "Times_id1", "dbo.Times");
            DropIndex("dbo.Students", new[] { "Timesid" });
            DropIndex("dbo.Days", new[] { "Times_id1" });
            DropColumn("dbo.Students", "Timesid");
            CreateIndex("dbo.Days", "Times_id1");
            AddForeignKey("dbo.Days", "Times_id1", "dbo.Times", "id");
        }
    }
}
