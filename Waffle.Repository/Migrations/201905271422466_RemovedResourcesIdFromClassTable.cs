namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedResourcesIdFromClassTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Classes", "ClassResourcesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "ClassResourcesId", c => c.Int(nullable: false));
        }
    }
}
