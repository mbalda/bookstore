using System.Data.Entity;

namespace Bookstore.DataAccess.Database
{
	public class BookStoreInitializer : CreateDatabaseIfNotExists<BookstoreContext>
	{
		protected override void Seed(BookstoreContext context)
		{
			base.Seed(context);
		}
	}
}