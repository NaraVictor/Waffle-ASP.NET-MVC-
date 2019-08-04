namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassTitleRequired : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Classes", new[] { "Title" });
            AlterColumn("dbo.Classes", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "Title", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Classes", "Title", unique: true);
        }
    }
}
