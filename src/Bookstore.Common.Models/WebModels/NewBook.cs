namespace Bookstore.Common.Models.WebModels
{
	public class NewBook
	{
		public string Author { get; set; }

		public string Title { get; set; }

		public string Isbn { get; set; }

		public decimal Price { get; set; }

		public int Pages { get; set; }

		public string Description { get; set; }

		public int Amount { get; set; }

		public decimal Discount { get; set; }
	}
}
