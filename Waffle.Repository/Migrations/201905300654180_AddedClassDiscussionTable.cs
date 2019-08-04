namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClassDiscussionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassDiscussions",
                c => new
                    {
                        ClassDiscussionId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false),
                        UserId = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassDiscussionId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassDiscussions", "ClassId", "dbo.Classes");
            DropIndex("dbo.ClassDiscussions", new[] { "ClassId" });
            DropTable("dbo.ClassDiscussions");
        }
    }
}
