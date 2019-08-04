namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "Requirements", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "Requirements", c => c.String(nullable: false));
        }
    }
}
