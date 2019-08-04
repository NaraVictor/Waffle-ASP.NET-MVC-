namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class textDependant : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "ClassResourcesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "ClassResourcesId", c => c.Int());
        }
    }
}
