namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletday3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Timesid", "dbo.Times");
            DropForeignKey("dbo.Students", "Timesid", "dbo.Times");
            DropIndex("dbo.Doctors", new[] { "Timesid" });
            DropIndex("dbo.Students", new[] { "Timesid" });
            DropColumn("dbo.Doctors", "Timesid");
            DropColumn("dbo.Students", "Timesid");
            DropTable("dbo.Times");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TimeBegin = c.String(),
                        Timeend = c.String(),
                        breakBegin = c.String(),
                        breakEnd = c.String(),
                        Dayoff = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Students", "Timesid", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "Timesid", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Timesid");
            CreateIndex("dbo.Doctors", "Timesid");
            AddForeignKey("dbo.Students", "Timesid", "dbo.Times", "id", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "Timesid", "dbo.Times", "id", cascadeDelete: true);
        }
    }
}
