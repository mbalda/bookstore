using System;
using System.Collections.Generic;

namespace Bookstore.Common.Models.DomainModels
{
	public class Order
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public virtual ICollection<BookDetails> OrderedBooks { get; set; }

		public int UserId { get; set; }
	}
}
