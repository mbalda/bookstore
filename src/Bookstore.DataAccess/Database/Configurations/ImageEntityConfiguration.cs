using Bookstore.Common.Models.DomainModels;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class ImageEntityConfiguration : EntityTypeConfiguration<Image>
	{
		public ImageEntityConfiguration()
		{
			ToTable("Images");

			HasRequired<BookDetails>(x => x.Book).WithMany(x => x.Images);
		}
	}
}
