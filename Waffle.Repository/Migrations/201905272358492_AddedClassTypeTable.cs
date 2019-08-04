namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassTypes",
                c => new
                    {
                        ClassTypeId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClassTypeId);
            
            CreateIndex("dbo.Classes", "TypeId");
            AddForeignKey("dbo.Classes", "TypeId", "dbo.ClassTypes", "ClassTypeId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TypeId", "dbo.ClassTypes");
            DropIndex("dbo.Classes", new[] { "TypeId" });
            DropTable("dbo.ClassTypes");
        }
    }
}
