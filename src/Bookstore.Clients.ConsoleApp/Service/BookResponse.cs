namespace Bookstore.Clients.ConsoleApp.Service
{
	public class BookResponse
	{
		public int Id { get; set; }

		public string Author { get; set; }

		public string Title { get; set; }

		public string Isbn { get; set; }

		public bool IsAvailable { get; set; }

		public bool IsInDiscount { get; set; }

		public decimal Price { get; set; }

		public decimal? Discount { get; set; }

		public int Pages { get; set; }

		public string Description { get; set; }

		public int Amount { get; set; }
	}
}