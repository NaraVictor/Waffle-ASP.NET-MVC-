namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDateCreatedFieldToRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "DateCreated", c => c.DateTime());
        }
    }
}
