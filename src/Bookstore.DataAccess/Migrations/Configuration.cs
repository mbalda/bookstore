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

		protected override void Seed(Database.BookstoreContext context)
		{
			context.Users.Add(
				new User
				{
					Login = "mbalda",
					Email = "mbalda@future-processing.com"
				});

			context.Books.AddRange(new[]
			{
				new BookDetails
				{
					Author = "Uncle Bob",
					Title = "Clean Code",
					Isbn = "ISBN-1234-5",
					Pages = 255,
					Description = "Great book"
				},
				new BookDetails
				{
					Author = "Martin Fowler",
					Title = "Planning Extreme Programming",
					Isbn = "ISBN-1234-6",
					Pages = 350,
					Description = "I have never read"
				}
			});

			base.Seed(context);
		}
	}
}