using Bookstore.Common.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class ImageEntityConfiguration : EntityTypeConfiguration<Image>
	{
		public ImageEntityConfiguration()
		{
			ToTable("Images");

			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			HasRequired<BookDetails>(x => x.Book).WithMany(x => x.Images);
		}
	}
}
