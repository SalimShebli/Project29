namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletday4 : DbMigration
    {
        public override void Up()
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
                        Dayoff = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Doctors", "Timesid", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Timesid", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "Timesid");
            CreateIndex("dbo.Students", "Timesid");
            AddForeignKey("dbo.Doctors", "Timesid", "dbo.Times", "id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Timesid", "dbo.Times", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Timesid", "dbo.Times");
            DropForeignKey("dbo.Doctors", "Timesid", "dbo.Times");
            DropIndex("dbo.Students", new[] { "Timesid" });
            DropIndex("dbo.Doctors", new[] { "Timesid" });
            DropColumn("dbo.Students", "Timesid");
            DropColumn("dbo.Doctors", "Timesid");
            DropTable("dbo.Times");
        }
    }
}
