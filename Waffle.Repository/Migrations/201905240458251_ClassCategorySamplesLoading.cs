namespace Waffle.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassCategorySamplesLoading : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO ClassCategories (Name) VALUES ('WASSCE')");
			Sql("INSERT INTO ClassCategories (Name) VALUES ('BECE')");
			Sql("INSERT INTO ClassCategories (Name) VALUES ('ACCA')");
			Sql("INSERT INTO ClassCategories (Name) VALUES ('MBA')");

			}

		public override void Down()
        {
        }
    }
}
