namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeClassFKNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "CategoryId", "dbo.ClassCategories");
            DropForeignKey("dbo.Classes", "LevelId", "dbo.ClassLevels");
            DropForeignKey("dbo.Classes", "TypeId", "dbo.ClassTypes");
            DropIndex("dbo.Classes", new[] { "CategoryId" });
            DropIndex("dbo.Classes", new[] { "LevelId" });
            DropIndex("dbo.Classes", new[] { "TypeId" });
            AlterColumn("dbo.Classes", "CategoryId", c => c.Int());
            AlterColumn("dbo.Classes", "LevelId", c => c.Int());
            AlterColumn("dbo.Classes", "TypeId", c => c.Int());
            CreateIndex("dbo.Classes", "CategoryId");
            CreateIndex("dbo.Classes", "LevelId");
            CreateIndex("dbo.Classes", "TypeId");
            AddForeignKey("dbo.Classes", "CategoryId", "dbo.ClassCategories", "ClassCategoryId");
            AddForeignKey("dbo.Classes", "LevelId", "dbo.ClassLevels", "ClasslevelId");
            AddForeignKey("dbo.Classes", "TypeId", "dbo.ClassTypes", "ClassTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TypeId", "dbo.ClassTypes");
            DropForeignKey("dbo.Classes", "LevelId", "dbo.ClassLevels");
            DropForeignKey("dbo.Classes", "CategoryId", "dbo.ClassCategories");
            DropIndex("dbo.Classes", new[] { "TypeId" });
            DropIndex("dbo.Classes", new[] { "LevelId" });
            DropIndex("dbo.Classes", new[] { "CategoryId" });
            AlterColumn("dbo.Classes", "TypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "LevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "TypeId");
            CreateIndex("dbo.Classes", "LevelId");
            CreateIndex("dbo.Classes", "CategoryId");
            AddForeignKey("dbo.Classes", "TypeId", "dbo.ClassTypes", "ClassTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Classes", "LevelId", "dbo.ClassLevels", "ClasslevelId", cascadeDelete: true);
            AddForeignKey("dbo.Classes", "CategoryId", "dbo.ClassCategories", "ClassCategoryId", cascadeDelete: true);
        }
    }
}
