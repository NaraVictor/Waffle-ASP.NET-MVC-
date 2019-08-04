namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassCategories",
                c => new
                    {
                        ClassCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClassCategoryId);
            
            AddColumn("dbo.Classes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "CategoryId");
            AddForeignKey("dbo.Classes", "CategoryId", "dbo.ClassCategories", "ClassCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "CategoryId", "dbo.ClassCategories");
            DropIndex("dbo.Classes", new[] { "CategoryId" });
            DropColumn("dbo.Classes", "CategoryId");
            DropTable("dbo.ClassCategories");
        }
    }
}
