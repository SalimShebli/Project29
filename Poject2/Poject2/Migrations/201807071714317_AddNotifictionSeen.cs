namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotifictionSeen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifacitons", "seen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifacitons", "seen");
        }
    }
}
