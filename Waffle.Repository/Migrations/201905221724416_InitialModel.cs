namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        PosterSrc = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        Topic = c.String(nullable: false, maxLength: 50),
                        Order = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.TopicId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        VideoSrc = c.String(),
                        Order = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.PlaylistId)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "ClassId", "dbo.Classes");
            DropIndex("dbo.Playlists", new[] { "TopicId" });
            DropIndex("dbo.Topics", new[] { "ClassId" });
            DropTable("dbo.Playlists");
            DropTable("dbo.Topics");
            DropTable("dbo.Classes");
        }
    }
}
