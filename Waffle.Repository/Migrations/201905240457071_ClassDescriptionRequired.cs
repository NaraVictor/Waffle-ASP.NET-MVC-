namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassDescriptionRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "Description", c => c.String());
        }
    }
}
