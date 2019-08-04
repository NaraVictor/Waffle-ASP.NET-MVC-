namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResourcesTitleandPathRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClassResources", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ClassResources", "Path", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClassResources", "Path", c => c.String());
            AlterColumn("dbo.ClassResources", "Title", c => c.String());
        }
    }
}
