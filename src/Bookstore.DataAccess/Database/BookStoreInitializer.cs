using System.Data.Entity;

namespace Bookstore.DataAccess.Database
{
	public class BookstoreInitializer : MigrateDatabaseToLatestVersion<BookstoreContext, Migrations.Configuration>
	{
	}
}