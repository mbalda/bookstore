using Bookstore.Common.Models.DomainModels;
using System.Data.Entity;

namespace Bookstore.DataAccess.Database
{
	public class BookstoreInitializer : CreateDatabaseIfNotExists<BookstoreContext>
	{
		protected override void Seed(BookstoreContext context)
		{
			context.Users.Add(new User
			{
				Id = 1,
				Login = "mbalda",
				Email = "mbalda@future-processing.com"
			});

			base.Seed(context);
		}
	}
}