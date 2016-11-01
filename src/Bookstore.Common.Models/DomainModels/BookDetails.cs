using System.Collections.Generic;

namespace Bookstore.Common.Models.DomainModels
{
	public class BookDetails : Book
	{
		public BookDetails()
		{
			Images = new List<Image>();
			Orders = new List<Order>();
		}

		public int Pages { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Image> Images { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}
