using Bookstore.DataAccess.Database;

namespace Bookstore.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;

	public sealed class Configuration : DbMigrationsConfiguration<BookstoreContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(BookstoreContext context)
		{
			TestData.Seed(context);
		}
	}
}
