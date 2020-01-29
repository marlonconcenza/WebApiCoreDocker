﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Entities;

namespace WebAPI.Data.Mapping
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.CPF)
				.IsRequired()
				.HasColumnName("CPF");

			builder.Property(c => c.BirthDate)
				.IsRequired()
				.HasColumnName("BirthDate");

			builder.Property(c => c.Name)
				.IsRequired()
				.HasColumnName("Name");
		}
	}
}
