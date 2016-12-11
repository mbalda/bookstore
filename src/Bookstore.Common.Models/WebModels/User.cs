using System.Collections.Generic;

namespace Bookstore.Common.Models.WebModels
{
	public class User
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string Email { get; set; }

		public List<Link> Links { get; set; }
	}
}
