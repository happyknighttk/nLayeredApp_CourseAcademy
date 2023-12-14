﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("CategoryName").IsRequired();

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Categories_CategoryName").IsUnique();

            builder.HasMany(b => b.Courses);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}