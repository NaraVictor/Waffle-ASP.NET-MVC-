namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewFieldsToClassTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "LevelId", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "TypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "TargetStudents", c => c.String());
            AddColumn("dbo.Classes", "Requirements", c => c.String(nullable: false));
            AddColumn("dbo.Classes", "ResourcesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "ResourcesId");
            DropColumn("dbo.Classes", "Requirements");
            DropColumn("dbo.Classes", "TargetStudents");
            DropColumn("dbo.Classes", "TypeId");
            DropColumn("dbo.Classes", "LevelId");
        }
    }
}
