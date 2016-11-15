using Bookstore.Common.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class BookEntityConfiguration : EntityTypeConfiguration<Book>
	{
		public BookEntityConfiguration()
		{
			ToTable("Books");

			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(x => x.Author).HasMaxLength(50);

			Property(x => x.Title).HasMaxLength(100);

			Property(x => x.Isbn).HasMaxLength(13)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName, new IndexAnnotation(
						new IndexAttribute { IsUnique = true }));
		}
	}
}
