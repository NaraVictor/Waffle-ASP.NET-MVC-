namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitleFieldToPlaylistTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Playlists", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Playlists", "Title");
        }
    }
}
