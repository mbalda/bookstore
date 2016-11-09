using Bookstore.Common.Models.DomainModels;

namespace Bookstore.DataAccess.Database
{
	public class TestData
	{
		public static void Seed(BookstoreContext context)
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
					Id = 1,
					Author = "Uncle Bob",
					Title = "Clean Code",
					Isbn = "ISBN-1234-5",
					Pages = 255,
					Description = "Great book"
				},
				new BookDetails
				{
					Id = 2,
					Author = "Martin Fowler",
					Title = "Planning Extreme Programming",
					Isbn = "ISBN-1234-6",
					Pages = 350,
					Description = "I have never read"
				},
				new BookDetails
				{
					Id = 3,
					Author = "Roy Osherove",
					Title = "Art of Unit Testing",
					Isbn = "9781617290893",
					Pages = 296,
					Description = "It is worth to read."
				}
			});

			context.BooksInStore.AddRange(new[]
			{
				new BookInStore
				{
					Id = 1,
					BookId = 1,
					Ammount = 50,
					Discount = 0,
					IsAvailable = true,
					IsInDiscount = false,
					Price = 55m
				},
				new BookInStore
				{
					Id = 2,
					BookId = 2,
					Ammount = 10,
					Discount = 10,
					IsAvailable = true,
					IsInDiscount = true,
					Price = 30m
				},
				new BookInStore
				{
					Id = 3,
					BookId = 3,
					Ammount = 0,
					Discount = 0,
					IsAvailable = false,
					IsInDiscount = false,
					Price = 27.50m
				}
			});
		}
	}
}