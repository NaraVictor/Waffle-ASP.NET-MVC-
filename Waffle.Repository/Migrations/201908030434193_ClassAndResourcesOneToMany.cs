namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassAndResourcesOneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassResources", "ClassResourcesId", "dbo.Classes");
            DropColumn("dbo.ClassResources", "ClassId");
            RenameColumn(table: "dbo.ClassResources", name: "ClassResourcesId", newName: "ClassId");
            RenameIndex(table: "dbo.ClassResources", name: "IX_ClassResourcesId", newName: "IX_ClassId");
            DropPrimaryKey("dbo.ClassResources");
            AlterColumn("dbo.ClassResources", "ClassResourcesId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ClassResources", "ClassResourcesId");
            AddForeignKey("dbo.ClassResources", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassResources", "ClassId", "dbo.Classes");
            DropPrimaryKey("dbo.ClassResources");
            AlterColumn("dbo.ClassResources", "ClassResourcesId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ClassResources", "ClassResourcesId");
            RenameIndex(table: "dbo.ClassResources", name: "IX_ClassId", newName: "IX_ClassResourcesId");
            RenameColumn(table: "dbo.ClassResources", name: "ClassId", newName: "ClassResourcesId");
            AddColumn("dbo.ClassResources", "ClassId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ClassResources", "ClassResourcesId", "dbo.Classes", "ClassId");
        }
    }
}
