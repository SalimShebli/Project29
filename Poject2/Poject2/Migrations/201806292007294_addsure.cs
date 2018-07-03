namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "sure", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "sure");
        }
    }
}
