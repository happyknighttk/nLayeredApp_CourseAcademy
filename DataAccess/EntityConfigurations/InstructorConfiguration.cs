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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.InstructorName).HasColumnName("InstructorName").IsRequired();

            builder.HasIndex(indexExpression: b => b.InstructorName, name: "UK_Instructors_InstructorName");

            builder.HasMany(b => b.Courses);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
