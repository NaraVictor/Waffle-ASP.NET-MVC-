namespace Waffle.Repository.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class AddedClassResourcesTable : DbMigration
	{
		public override void Up()
		{
			DropForeignKey("dbo.Topics", "ClassId", "dbo.Classes");
			DropPrimaryKey("dbo.Classes");
			CreateTable(
				"dbo.ClassResources",
				c => new
					{
						ClassResourcesId = c.Int(nullable: false),
						Title = c.String(),
						Path = c.String(),
						ClassId = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.ClassResourcesId)
				.ForeignKey("dbo.Classes", t => t.ClassResourcesId)
				.Index(t => t.ClassResourcesId);

			DropColumn("dbo.Classes", "Id");
			AddColumn("dbo.Classes", "ClassId", c => c.Int(nullable: false, identity: true));
			AddColumn("dbo.Classes", "ClassResourcesId", c => c.Int());
			AddPrimaryKey("dbo.Classes", "ClassId");
			AddForeignKey("dbo.Topics", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
			DropColumn("dbo.Classes", "ResourcesId");
		}
		
		public override void Down()
		{
			AddColumn("dbo.Classes", "ResourcesId", c => c.Int(nullable: false));
			AddColumn("dbo.Classes", "Id", c => c.Int(nullable: false, identity: true));
			DropForeignKey("dbo.Topics", "ClassId", "dbo.Classes");
			DropForeignKey("dbo.ClassResources", "ClassResourcesId", "dbo.Classes");
			DropIndex("dbo.ClassResources", new[] { "ClassResourcesId" });
			DropPrimaryKey("dbo.Classes");
			DropColumn("dbo.Classes", "ClassResourcesId");
			DropColumn("dbo.Classes", "ClassId");
			DropTable("dbo.ClassResources");
			AddPrimaryKey("dbo.Classes", "Id");
			AddForeignKey("dbo.Topics", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
		}
	}
}
