namespace Bookstore.Common.Models.DomainModels
{
	public class BookInStore
	{
		public int Id { get; set; }

		public int BookId { get; set; }

		public int Amount { get; set; }

		public bool IsAvailable { get; set; }

		public bool IsInDiscount { get; set; }

		public decimal Price { get; set; }

		public decimal? Discount { get; set; }

		public virtual BookDetails Book { get; set; }
	}
}
