namespace Bookstore.Common.Models.WebModels
{
	public class BookInfoWithDetails : BookInfo
	{
		public int Pages { get; set; }

		public string Description { get; set; }

		public int Amount { get; set; }
	}
}
