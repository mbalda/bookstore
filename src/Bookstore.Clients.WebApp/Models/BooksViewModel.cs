using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;

namespace Bookstore.Clients.WebApp.Models
{
	public class BooksViewModel
	{
		public IList<BookInfo> Books { get; set; }
	}
}