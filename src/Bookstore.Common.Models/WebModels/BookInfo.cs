namespace Bookstore.Common.Models.WebModels
{
	public class BookInfo
	{
		public int Id { get; set; }

		public string Author { get; set; }

		public string Title { get; set; }

		public string Isbn { get; set; }

		public bool IsAvailable { get; set; }

		public bool IsInDiscount { get; set; }

		public decimal Price { get; set; }

		public decimal? Discount { get; set; }
	}
}
