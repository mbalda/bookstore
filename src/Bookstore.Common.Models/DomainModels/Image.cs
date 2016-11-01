namespace Bookstore.Common.Models.DomainModels
{
	public class Image
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Location { get; set; }

		public virtual int BookId { get; set; }

		public virtual BookDetails Book { get; set; }
	}
}
