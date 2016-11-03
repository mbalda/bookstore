﻿using Bookstore.Common.Models.DomainModels;
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

			Property(x => x.Isbn).HasMaxLength(13)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName, new IndexAnnotation(
						new IndexAttribute { IsUnique = true }));
		}
	}
}