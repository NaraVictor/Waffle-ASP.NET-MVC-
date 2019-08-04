namespace Waffle.Repository.Migrations
	{
	using System;
	using System.Data.Entity.Migrations;

	public partial class PopulatingClassTypesAndLevels : DbMigration
		{
		public override void Up()
			{
			//Classtypes
			Sql("INSERT INTO ClassTypes VALUES('Free')");
			Sql("INSERT INTO ClassTypes VALUES('Premium')");

			//class levels
			Sql("INSERT INTO ClassLevels VALUES('Beginner')");
			Sql("INSERT INTO ClassLevels VALUES('Intermediate')");
			Sql("INSERT INTO ClassLevels VALUES('Advanced')");
			Sql("INSERT INTO ClassLevels VALUES('All Levels')");

			}

		public override void Down()
			{
			}
		}
	}
