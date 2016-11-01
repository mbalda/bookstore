using Bookstore.Common.Models.DomainModels;

namespace Bookstore.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<Bookstore.DataAccess.Database.BookstoreContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Bookstore.DataAccess.Database.BookstoreContext context)
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