﻿using Bookstore.Common.Models.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore.DataAccess.Database.Configurations
{
	public class UserEntityConfiguration : EntityTypeConfiguration<User>
	{
		public UserEntityConfiguration()
		{
			ToTable("Users");

			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(x => x.Login).HasMaxLength(20);
			Property(x => x.Email).HasMaxLength(100);
		}
	}
}
