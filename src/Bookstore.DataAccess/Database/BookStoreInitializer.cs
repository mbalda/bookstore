using System.Data.Entity;

namespace Bookstore.DataAccess.Database
{
	public class BookstoreInitializer : CreateDatabaseIfNotExists<BookstoreContext>
	{
	}
}