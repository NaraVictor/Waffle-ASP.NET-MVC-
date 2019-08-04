namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeClassTitleUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Classes", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Classes", new[] { "Title" });
        }
    }
}
