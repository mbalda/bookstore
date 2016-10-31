namespace Bookstore.Common.Models.DomainModels
{
	class Store
	{
		public int Id { get; set; }

		public int BookId { get; set; }

		public int Ammount { get; set; }

		public bool IsAvailable { get; set; }

		public bool IsInDiscount { get; set; }

		public decimal Price { get; set; }

		public decimal? Discount { get; set; }
	}
}
