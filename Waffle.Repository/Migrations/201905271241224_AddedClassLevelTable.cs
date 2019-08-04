namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassLevelTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassLevels",
                c => new
                    {
                        ClasslevelId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClasslevelId);
            
            CreateIndex("dbo.Classes", "LevelId");
            AddForeignKey("dbo.Classes", "LevelId", "dbo.ClassLevels", "ClasslevelId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "LevelId", "dbo.ClassLevels");
            DropIndex("dbo.Classes", new[] { "LevelId" });
            DropTable("dbo.ClassLevels");
        }
    }
}
