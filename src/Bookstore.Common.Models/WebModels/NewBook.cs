using System.ComponentModel.DataAnnotations;

namespace Bookstore.Common.Models.WebModels
{
	public class NewBook
	{
		[Required]
		[MaxLength(50)]
		public string Author { get; set; }

		[Required]
		[MaxLength(100)]
		public string Title { get; set; }

		[Required]
		[MaxLength(13)]
		public string Isbn { get; set; }

		[Required]
		public decimal Price { get; set; }

		public int Pages { get; set; }

		public string Description { get; set; }

		public int Amount { get; set; }
	}
}
