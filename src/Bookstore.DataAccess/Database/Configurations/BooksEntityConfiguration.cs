using Bookstore.Common.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class BooksEntityConfiguration : EntityTypeConfiguration<Book>
	{
		public BooksEntityConfiguration()
		{
			ToTable("Books");

			Property(x => x.Isbn).HasMaxLength(13)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName, new IndexAnnotation(
						new IndexAttribute { IsUnique = true }));

			//Map<BookDetails>(x => x.)
		}
	}
}
