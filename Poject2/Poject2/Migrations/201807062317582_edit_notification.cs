namespace Poject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_notification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifacitons", "id_resiever", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifacitons", "id_resiever");
        }
    }
}
