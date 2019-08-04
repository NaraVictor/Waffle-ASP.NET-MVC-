namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassTitleRangeChangedToMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "Title", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "Title", c => c.String(nullable: false));
        }
    }
}
