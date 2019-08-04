namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedVideoSrcToVideoPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Playlists", "VideoPath", c => c.String());
            DropColumn("dbo.Playlists", "VideoSrc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlists", "VideoSrc", c => c.String());
            DropColumn("dbo.Playlists", "VideoPath");
        }
    }
}
