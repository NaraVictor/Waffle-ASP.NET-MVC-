namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedOrderToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Playlists", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Playlists", "Order", c => c.Short(nullable: false));
        }
    }
}
