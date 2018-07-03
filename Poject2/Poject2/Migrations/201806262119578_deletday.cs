namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletday : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Days", "Times_id", "dbo.Times");
            DropIndex("dbo.Days", new[] { "Times_id" });
            AddColumn("dbo.Times", "Dayoff", c => c.Int(nullable: false));
            DropTable("dbo.Days");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Days = c.Int(nullable: false),
                        Times_id = c.Int(nullable: false),
                        Times_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.Times", "Dayoff");
            CreateIndex("dbo.Days", "Times_id");
            AddForeignKey("dbo.Days", "Times_id1", "dbo.Times", "id");
        }
    }
}
