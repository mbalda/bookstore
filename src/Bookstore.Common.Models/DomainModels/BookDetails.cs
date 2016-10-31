using System.Collections.Generic;

namespace Bookstore.Common.Models.DomainModels
{
	public class BookDetails : Book
	{
		public BookDetails()
		{
			Images = new List<Image>();
		}

		public int Pages { get; set; }

		public List<Image> Images { get; set; }
	}
}
