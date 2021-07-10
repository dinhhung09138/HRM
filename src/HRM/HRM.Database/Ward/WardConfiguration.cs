using HRM.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Database
{
    public sealed class WardConfiguration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ward> builder)
        {
            builder.ToTable(nameof(Ward), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            builder.Property(m => m.IsActive).IsRequired();

        }
    }
}
